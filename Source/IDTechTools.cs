using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDTechSDK;
namespace USDKDemo
{
    class IDTechTools
    {
        public static String GetTimestamp()
        {
            DateTime value = DateTime.Now;
            return value.ToString("HH:mm:ss.fff");
        }

        public static string getDate( string date)
        {
            if (date.Length <= 0)
                return "";
            byte[] buf = Common.getByteArray(date);
            int len = buf.Length;
            string str = "";

            for (int i = 0; i < len; i++)
            {
                if (i < (len - 1))
                {
                    str = str + String.Format("{0:X}", buf[i])+"/";
                }
                else
                {
                    str = str + String.Format("{0:X}", buf[i]);
                }

            }
            
            return str;
        }
        public static string getTime(string time)
        {
            if (time.Length <= 0)
                return "";
            byte[] buf = Common.getByteArray(time);
            int len = buf.Length;
            string str = "";

            for (int i = 0; i < len; i++)
            {
                if (i < (len - 1))
                {
                    str = str + String.Format("{0:X}", buf[i]) + ":";
                }
                else
                {
                    str = str + String.Format("{0:X}", buf[i]);
                }

            }

            return str;
        }
        static string getAmount(string amount,string exponent)
        {

            //
            float fAccount = 0.0f;
            int iAccount = 0;
            if (exponent.Length  <= 0) return "#";
            int iExponent = int.Parse(exponent);
            for (int i = 0; i < 6; i++)
            {
                //
                amount.TrimStart('0');
                amount.TrimEnd(' ');
            }
            amount.Replace(" ", "");
            if (amount.Length  > 0)
            {
                //get integer from string
                iAccount = int.Parse(amount);

                int n = (int)Math.Pow(10, iExponent);

                fAccount = (float)(iAccount / (float)n);
            }
            string str = string.Format("{0:N2}", fAccount) ;
            return str;
        }

        public static string tlvToValues(byte[] tlv)
        {
            string text = "";
            Dictionary<string, string> dict = Common.processTLVUnencrypted(tlv);

            string merchantName = "";
            string merchantID = "";
            string ternimalID = "";
            string PAN = "";
            string transType = "";
            string amount = "";

            string transDate = "";
            string transTime = "";
            string signature = "Cardholder Signature:\r\n   _ _ _ _ _ _ _ _ _ _ _";
            bool enableSignature = false;
            string totalTags = "";

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                totalTags += kvp.Key + ": " + kvp.Value + "\r\n";

                if (kvp.Key.Contains("9F4E") == true)
                    merchantName = Common.getASCIIArray(kvp.Value);
                if (kvp.Key.Contains("9F16") == true)
                    merchantID = Common.getASCIIArray(kvp.Value);

                if (kvp.Key.Contains("9F1C") == true)
                    ternimalID = Common.getASCIIArray(kvp.Value);

                if (kvp.Key.Contains("5A") == true)
                    PAN = kvp.Value;
                else
                {
                    if (kvp.Key.Contains("57") == true)
                    {
                        PAN = kvp.Value.Split('d')[0];
                    }
                    else
                    {
                        if (kvp.Key.Contains("9F6B") == true)
                        {
                            PAN = kvp.Value.Split('d')[0];
                        }

                    }

                }

                if (kvp.Key.Contains("9C") == true)
                {
                    //  00 - Goods / Service
                    //  01 - Cash
                    //  09 - With Cashback
                    byte[] val = Common.getByteArray(kvp.Value);
                    if (val[0] == 0x00)
                        transType = "Goods / Service";
                    if (val[0] == 0x01)
                        transType = "Cash";
                    if (val[0] == 0x09)
                        transType = "With Cashback";
                }


                if (kvp.Key.Contains("9F02") == true)
                    amount = getAmount(kvp.Value, "02");//eric, need read terminal config

                if (kvp.Key.Contains("9A") == true)
                    transDate = getDate(kvp.Value);
                if (kvp.Key.Contains("9F21") == true)
                    transTime = getTime(kvp.Value);

                if (kvp.Key.Contains("9F34") == true)
                {
                    byte[] rec = Common.getByteArray(kvp.Value);
                    if ((rec[0] & 0x3F) == 0x1E || (rec[0] & 0x3F) == 0x03 || (rec[0] & 0x3F) == 0x05)
                    {
                        enableSignature = true;
                    }

                    //       text += kvp.Key + ": " + kvp.Value + "\r\n";

                }
            }
            text += merchantName + "\r\n";
            text += "- - - - - - - - - - - - - - " + "\r\n";
            text += "MERCHANT ID: " + "\t" + merchantID + "\r\n";
            text += "TERMINAL ID: " + "\t" + ternimalID + "\r\n";
            text += "CARD NO: " + "\t" + PAN + "\r\n";
            text += "TRANS TYPE: " + "\t" + transType + "\r\n";
            text += "AMOUNT: " + "\t" + amount + "\r\n";
            text += "DATE: " + "\t\t" + transDate + "\r\n";
            text += "TIME: " + "\t\t" + transTime + "\r\n";
            if (enableSignature == true)
                text += signature;
            text += "\r\nTAGS:\r\n" +  totalTags + "\r\n";


            return text;
        }
        public static string getASCIIArrayTagFromTLVs(byte[] tlv, string tag)
        {
            Dictionary<string, string> dict = Common.processTLVUnencrypted(tlv);
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (String.Compare(kvp.Key, tag, true) == 0)
                    return Common.getASCIIArray(kvp.Value);
            }
            return "";
        }
        public static string getHexArrayTagFromTLVs(byte[] tlv,string tag)
        {
            Dictionary<string, string> dict = Common.processTLVUnencrypted(tlv);
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (String.Compare(kvp.Key, tag,true) == 0)
                    return  kvp.Value ;
            }
            return "";
        }


        public static int convertHexStringToBytes(string str, out byte[]byData, out int nDataLen)
        {
           byData = null;
           int len = str.Length;
            if (len < 1)
            {
                nDataLen = 0;
                return 0;
            }
             

            //remove the space/":"/"-"
            string strData = "";
            for (int n = 0; n < len; n++)
            {
                if ((' ' == str[n]) || (':' == str[n]) || ('-' == str[n]))
                {
                }
                else
                {
                    strData += str[n];
                }
            }

            len = strData.Length;

            if (1 == (len % 2))
            {
                nDataLen = 0;
                byData = null;
                return 2; //format not good
            }
            byData = new byte[len/2];
            nDataLen = 0;
            bool bRet = true;
            byte byTmp1 = 0, byTmp2 = 0;
            for (int i = 0; i < len; i = i + 2)
            {
                if (str2Hex(strData[i], out byTmp1))
                {
                    if (str2Hex(strData[i + 1], out byTmp2))
                    {
                         byData[nDataLen] = (byte)(byTmp1 * 16 + byTmp2);
                        nDataLen++;
                    }
                    else
                    {
                        bRet = false;
                        break;
                    }
                }
                else
                {
                    bRet = false;
                    break;
                }
            }
            if (!bRet)
            {
                byData = null;
                return 3; //have error char
            }
         //   byData = null;

            return 1;
        }


        public static bool str2Hex(char x, out byte by)
        {
            switch (x)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    by = (byte)(x - '0');
                    break;
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                    by = (byte)(10 + x - 'A');
                    break;
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                    by = (byte)(10 + x - 'a');
                    break;
                default:
                    by = 0;
                    return false;
            }
            return true;
        }
        public  const int NUM_BITS_EC = 21;

        public static int GetFirstRightSetBitPos(int auiBitmap)
        {
            for (int luiPos = 0; luiPos < NUM_BITS_EC; luiPos++)
            {
                if ((auiBitmap & (1 << luiPos))!=0)
                {
                    return ((NUM_BITS_EC - 1) - luiPos);
                }
            }
            return 0;
        }
        public static void UpdateKSN(int auiEncCntr, byte[] aucmpKsnReg)
        {
            aucmpKsnReg[9] = (byte)(auiEncCntr);
            aucmpKsnReg[8] = (byte)(auiEncCntr >> 8);
            aucmpKsnReg[7] = (byte)((aucmpKsnReg[7] & 0xE0)|((auiEncCntr >> 16) & 0x1F));
        }

 
    }
}

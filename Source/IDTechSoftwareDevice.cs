using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using IDTechSDK;
namespace USDKDemo
{


    //Language Info
    //Message Line info
    public struct LINE_INFO
    {
        public int line;
        public int type;//Message ID or Message String
        public int language;//0:raw, 1: language select code
        public char[] message;
        //	unsigned char message[100]; 
    }
    public struct PIN_INFO
    {
        public int KSN_len;
        public byte[] KSN;//[20];
        public int PAN_Len;
        public byte[] PAN;//[1024];
    }
    ;


    public enum MSG_TX { MSG_TX_NONE = 0, MSG_TX_Send = 1, MSG_TX_Response };
    public enum MSG_ID { MSG_NONE = 0, MSG_LCD_DISP, MSG_PIN, MSG_MSR };
    public enum Mode_LCD { DispNone = 0, MenuDisp = 1, NormalDisp = 2, DispOnly = 3, ClearLCD = 16 };
    public enum Mode_PIN { PIN_NONE = 0, PIN_Cancel = 1, PIN_ONLINE_DUKPT = 2, PIN_ONLINE_MKSK = 3, PIN_OFFLINE_PIN = 4 };
    public enum MSG_TYPE { MSG_TYPE_UNKOWN = 0, MSG_TYPE_ID = 1, MSG_TYPE_String = 2 };

    public struct MESSAGE_INFO
    {
        public MSG_ID MessageID;   //0:none, 1: Language, 2: PIN, 3: MSR
        public int Mode;           //0:none, 
                                   //1: Language, 1,3
                                   //2: PIN, 0,1,2,3


        public int timeoutInput;   //Language, PIN, MSR
        public int timeoutInputOpt;//Language:LCD BackLight
                                   //PIN: entry interval
                                   //MSR: none

        public MSG_TX MessageTrans;//send or reposne
        public bool needResponse;
        public bool languageSelect;

        public char[] Language; //'EN'-English, 'ES'-Spanish, 'ZH'-Chinese, 'FR'-French
                                //        CArray<LINE_INFO, LINE_INFO&>* m_pMessageLine;

        public PIN_INFO dataPIN;

    }
    ;


    class IDTechSoftwareDevice
    {
        // CStimulator dialog
        const int WM_USER = 100;
        const int WM_SIMULATOR_CHECK_AMOUNT = WM_USER + 200;
        const int WM_SIMULATOR_INPUT_AMOUNT = WM_USER + 201;
        const int WM_SIMULATOR_INPUT_AMOUNT_OTHER = WM_USER + 202;

        //#define WM_SIMULATOR_INPUT_LANGUAGE		WM_USER+203
        //#define WM_SIMULATOR_INPUT_PIN			WM_USER+204
        const int WM_SIMULATOR_DISP_MESSAGE = WM_USER + 205;
        const int WM_SIMULATOR_PRINT_MESSAGE = WM_USER + 206;

        const int WM_SIMULATOR_CALLBACK_MESSAGE = WM_USER + 207;
        const int WM_SIMULATOR_READING_DATA = WM_USER + 208;
        const int WM_SIMULATOR_CHECKVALIE_DATA = WM_USER + 209;//added by Nianlong Yu 2015.09.11

        //public static MESSAGE_INFO messageInfo;
        public static int m_nMessageID = 0;
        public static string m_posOnlinePIN = "";
        public static EMV_Callback emvCallbackInfo;
        public static void UpdateEMVResponse(EMV_Callback _emvCallbackInfo)
        {
            emvCallbackInfo = _emvCallbackInfo;
        }
        static string SKSN = "62994900000000000001";
        static Int32 uiEncrytionCounter = 0;

        public static byte[] getPINData(bool offline)
        {
            byte[] PINData = null;
            //offline PIN
            if (offline == true)
            {

                PINData = System.Text.Encoding.UTF8.GetBytes(m_posOnlinePIN);

            }
            else
            {
                //online PIN

                int strLen = m_posOnlinePIN.Length;
                int i = 0;
                int Buflen = 0;

                if (strLen > 0)
                {
                    //PIN:		m_posOnlinePIN
                    //get the ascii code of the PIN
                    byte[] BufData = null;
                    //package to 16 PAN with prefix '0'
                    m_posOnlinePIN.Replace(" ", "");
                    int PinLen = m_posOnlinePIN.Length;
                    char[] AClearPIN = new char[10];
                    string PINLen = string.Format("{0:X2}", PinLen);
                    m_posOnlinePIN = PINLen + m_posOnlinePIN;
                    if (m_posOnlinePIN.Length < 16)
                    {
                        int diff = 16 - m_posOnlinePIN.Length;
                        for (i = 0; i < diff; i++)
                            m_posOnlinePIN = m_posOnlinePIN + "F";
                    }
                    BufData = Common.getByteArray(m_posOnlinePIN);
                    Buflen = BufData.Length;
                    string StrTmpPIN = "";
                    //Account:	m_posPAN
                    byte[] BufDataPAN;
                    //package to 16 PAN with prefix '0'
                    string posPAN = Common.getHexStringFromBytes(emvCallbackInfo.pin_truncatedPAN);

                    if (posPAN.Length == 16)
                    {
                        posPAN = "0" + posPAN;
                        posPAN = posPAN.Substring(0, 16);
                    }
                    if (posPAN.Length < 16)
                    {
                        int diff = 16 - posPAN.Length;
                        for (i = 0; i < diff; i++)
                            posPAN = "0" + posPAN;
                    }

                    BufDataPAN = Common.getByteArray(posPAN);
                    Buflen = BufData.Length;

                    BufDataPAN[0] = 0;
                    BufDataPAN[1] = 0;
                    //memxor
                    for (i = 0; i < 8; i++)
                    {
                        BufData[i] = (byte)(BufDataPAN[i] ^ BufData[i]);
                    }

                    StrTmpPIN = Common.getHexStringFromBytes(BufData);
                    //Key
                    string SKey = "0123456789abcdeffedcba9876543210";

                    //pacakge KSN

                    if (emvCallbackInfo.pin_KSN != null)
                        if (emvCallbackInfo.pin_KSN.Length > 0)
                            SKSN = Common.getHexStringFromBytes(emvCallbackInfo.pin_KSN);

                    //encryption

                    int IEncryptType = 1; //TDES

                    BufData = Common.getByteArray(StrTmpPIN);
                    byte[] BBufKSN = Common.getByteArray(SKSN);
                    byte[] BBufKey = Common.getByteArray(SKey);
                    if (1 == IEncryptType)
                    {
                        if (0 != (Buflen % 8))
                            Buflen = 8 * ((Buflen / 8) + 1);
                    }
                    else
                    {
                        if (0 != (Buflen % 16))
                            Buflen = 16 * ((Buflen / 16) + 1);
                    }

                    PIN_EncryptDLL(IEncryptType, BBufKSN, BBufKey, BufData, Buflen);

                    PINData = null;
                    PINData = new byte[BufData.Length];
                    System.Array.Copy(BufData, PINData, BufData.Length);


                    //	memcpy(BufData+Buflen,BBufKSN,10);
                    System.Diagnostics.Debug.WriteLine("m_posOnlinePIN: = " + m_posOnlinePIN);

                    string encryptedPIN = Common.getHexStringFromBytes(BufData);

                    System.Diagnostics.Debug.WriteLine("encryptedPIN Data: = " + encryptedPIN);

                    //=======Update KSN========

                    IDTechTools.convertHexStringToBytes(SKSN, out BufData, out Buflen);

                    uiEncrytionCounter = BufData[9];
                    uiEncrytionCounter = uiEncrytionCounter | (BufData[8] << 8);
                    uiEncrytionCounter = uiEncrytionCounter | (BufData[7] << 8);
                    uiEncrytionCounter = uiEncrytionCounter & 0x001FFFFF;

                    //update the KSN number
                    if (true)
                    {
                        int luiPosition = IDTechTools.GetFirstRightSetBitPos(uiEncrytionCounter);
                        // set the corresponding bit in shift reg
                        int luiShiftReg = 1 << ((IDTechTools.NUM_BITS_EC - 1) - luiPosition);
                        // Generate new future keys and delete current encrypt key
                        int liNumOfOnes = 0;//int liNumOfOnes = 0;
                                            // For each bit in encryption counter
                        for (int luii = 0; luii < 21; luii++)
                        {
                            if ((uiEncrytionCounter & (1 << luii)) != 0)
                            {
                                liNumOfOnes++;
                            }
                        }
                        if (liNumOfOnes < 10)
                        {
                            // Generating new keys:
                            luiShiftReg >>= 1;
                            // Increment encryption counter and update it in key serial num register
                            uiEncrytionCounter++;
                            IDTechTools.UpdateKSN(uiEncrytionCounter, BufData);
                        }
                        else
                        {
                            // Increment encryption counter and update it in key serial num register
                            uiEncrytionCounter += luiShiftReg;
                            IDTechTools.UpdateKSN(uiEncrytionCounter, BufData);
                        }
                    }
                    SKSN = Common.getHexStringFromBytes(BufData);
                    //=======END Update KSN========
                    //memcpy(bufBody+sum ,BufData,Buflen);
                }
            }
            return PINData;
        }

        public static byte[] getKSNData()
        {
            byte[] ksn = Common.getByteArray(SKSN);
            return ksn;
        }
        public static void WarringBeep()
        {
            Beep(3000, 100);
        }

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        //        [DllImport("PIN_TDES_Decryption.dll")]
        //        public static extern byte PIN_EncryptDLL(Int32 EType, byte[] KSN, byte[] Key, byte[] Edata, Int32 DataLen);
        [DllImport("DecryptDLL.dll")]
        public static extern byte PIN_EncryptDLL(Int32 EType, byte[] KSN, byte[] Key, byte[] Edata, Int32 DataLen);
    }


}
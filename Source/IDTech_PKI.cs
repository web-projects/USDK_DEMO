using System;
using IDTechSDK;
using RKIUtility;
using System.Security.Cryptography.X509Certificates;
namespace USDKDemo
{
    public static class IDTech_PKI
    {
        //RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
        //RETURN_CODE.RETURN_CODE_DO_SUCCESS)

        public static string getUTCDate(ref byte[] _utcdate)
        {
            DateTime mydate = System.DateTime.Now;
            string dateparse = mydate.Year.ToString();
            string _HH = Int16.Parse(mydate.Hour.ToString()).ToString("X2");
            string _MI = Int16.Parse(mydate.Minute.ToString()).ToString("X2");
            string _YY1 = mydate.Year.ToString();
            string _YY2 = "";
            _YY2 = Int16.Parse(dateparse.Substring(2, dateparse.Length - 2)).ToString("X2");
            _YY1 = Int16.Parse(dateparse.Substring(0, dateparse.Length - 2)).ToString("X2");
            string _MM = Int16.Parse(mydate.Month.ToString()).ToString("X2");
            string _DD = Int16.Parse(mydate.Day.ToString()).ToString("X2");
            string result = _HH + _MI + _YY1 + _YY2 + _MM + _DD;
            _utcdate = Common.getByteArray(result);

            return mydate.ToString();
        }

        //************************************************************************
        //*** 90-00 / UMFG - Device Reset
        //************************************************************************
        public static RETURN_CODE UMFG_DeviceReset(byte[] _devicenonce)
        {
            byte[] response = null;
            byte[] data = null;
            int _timeout = 15000;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("90")[0], Common.getByteArray("00")[0], _devicenonce, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 90-01 / UMFG - Set Device RTC
        //************************************************************************
        public static RETURN_CODE UMFG_setRTC(ref string rtcdate)
        {
            byte[] response = null;
            byte[] data = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rtcdate = getUTCDate(ref data);
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("90")[0], Common.getByteArray("01")[0], data, ref response, _timeout, false);
            }
            return rt;
        }
       
        //************************************************************************
        //*** 90-02 / UMFG - Activate Device Security
        //************************************************************************
        public static RETURN_CODE UMFG_ActivateDeviceSecurity(ref byte[] certCSK)
        {
            byte[] response = null;
            byte[] data = { 0x00 };
            byte[] command2 = { 0x00 };
            byte[] command = { 0x00 };
            byte[] certCEK = null;
            int _timeout = 30000;

            RETURN_CODE rt;
            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();
            if (protType == DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("90")[0], Common.getByteArray("02")[0], data, ref response, _timeout, false);

                if (rt == RETURN_CODE.RETURN_CODE_DO_SUCCESS)
                {

                    if (response[0] != 0x06 || response.Length < 2)
                    {
                        if ((response.Length == 3 || response.Length == 6 || response.Length == 7) && response[0] == 0x15) return (RETURN_CODE)((response[1] << 8) + response[2]);
                        return RETURN_CODE.RETURN_CODE_FAILED;
                    }
                    certCEK = new byte[response[6] + (response[7] * 0x100)];
                    certCSK = new byte[response[8 + certCEK.Length] + (response[9 + certCEK.Length] * 0x100)];
                    Array.Copy(response, 8, certCEK, 0, certCEK.Length);
                    Array.Copy(response, 10 + certCEK.Length, certCSK, 0, certCSK.Length);
                }

            }
            else
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            return rt;

        }
        
        //************************************************************************
        //*** 90-04 / UMFG - Validate Certificate Tree
        //************************************************************************
        public static RETURN_CODE UMFG_validateCertTree(ref string strResponse)
        {
            byte[] response = null;
            byte[] data = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("90")[0], Common.getByteArray("04")[0], data, ref response, _timeout, false);
            }
            return rt;
        }
       
        //************************************************************************
        //*** 90-05 / UMFG - Lock Device
        //************************************************************************
        public static RETURN_CODE UMFG_ActivateLock()
        {
            byte[] data = { 0x00 };
            byte[] subcommand = { 0x00 };
            byte[] command = { 0x00 };
            int _timeout = 15000;

            RETURN_CODE rt;
            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();
            if (protType == DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                _timeout = 30000;
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("90")[0], Common.getByteArray("05")[0], command, ref data, _timeout, false);
            }
            else
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            return rt;

        }

        //************************************************************************
        //*** 90-07 / UMFG - Refresh Memory
        //************************************************************************
        public static RETURN_CODE UMFG_StartSecureTask(ref string strResponse)
        {
            byte[] response = { 0x00 };
            byte[] subcommand = { 0x00 };
            byte[] command = { 0x00 };

            RETURN_CODE rt;
            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();
            string commandstring = "5669564F74656368320090070001008FB4";

            rt = RETURN_CODE.RETURN_CODE_FAILED;
            bool isValid = IDTech_PKI.RunDeviceSendCommand(commandstring, ref response, ref strResponse);
            if (isValid)
            {
                rt = RETURN_CODE.RETURN_CODE_DO_SUCCESS;
            }
            else
            {
                strResponse = "UMFG Start Secure Task Command failed. Error Code: " + "0x" + String.Format("{0:X}", (ushort)rt) + ": " + IDTechSDK.errorCode.getErrorString(rt) + "\r\n";
            }
            return rt;

        }

        //************************************************************************
        //*** 90-10 / UMFG - Set SerialNumber
        //************************************************************************
        public static RETURN_CODE UMFG_SetSerialNumber(byte[] _data)
        {
            byte[] response = null;
            //byte[] _data = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;

            }
            else
            {

                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("90")[0], Common.getByteArray("10")[0], _data, ref response, _timeout, false);

            }
            return rt;
        }


        //************************************************************************
        //*** 91-00 / SMFG - Master Reset
        //************************************************************************
        public static RETURN_CODE SMFG_MasterReset(byte[] data)
        {
            byte[] response = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("91")[0], Common.getByteArray("00")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 91-08 / SMFG - Get Device Nonce
        //************************************************************************
        public static RETURN_CODE SMFG_GetDeviceNonce(string _serialnum, ref byte[] devicenonce )
        {
            byte[] data = { 0x00 };
            byte[] command = { 0x00 };

            int _timeout = 3000;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                byte[] byteData = { 0x00 };

                //string seriesnumHex = "48406F6919B199B3AFEBA66CA816F618"; //StringHelper.ASCIItoHex("1234567890123456");
                string seriesnumHex = StringHelper.ASCIItoHex("000000" + _serialnum);
                byteData = Common.getByteArray(seriesnumHex);

                rt = IDT_Device.sharedController.device_getNonce(byteData, ref devicenonce);
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("91")[0], Common.getByteArray("08")[0], command, ref devicenonce, _timeout, false);
            }
            return rt;
        }


        //************************************************************************
        //*** 91-10 / SMFG - Set MSR Whitelist
        //************************************************************************
        public static RETURN_CODE SMFG_SetMSRWhitelist(string[] ArrayString, ref string strResponse)
        {
            
            byte[] response = null;
            byte[] data = null;
            int _timeout = 3000;
            bool IsSuccess = false;

            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                if (String.IsNullOrEmpty(ArrayString[0]))
                {
                    strResponse = "No signature found.";
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                string commandstring = "";
                RKIUtility.CommandHelper cmd = new RKIUtility.CommandHelper();
                IsSuccess = cmd.create_IDGCommandString(ArrayString, ref commandstring, ref strResponse);
                if (!IsSuccess)
                {
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                data = Common.getByteArray(commandstring);

                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("91")[0], Common.getByteArray("10")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 91-11 / SMFG - Clear MSR Whitelist
        //************************************************************************
        public static RETURN_CODE SMFG_ClearMSRWhitelist(byte[] data)
        {
            byte[] response = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("91")[0], Common.getByteArray("11")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 91-12 / SMFG - Set Key parameters
        //************************************************************************
        public static RETURN_CODE SMFG_SetKeyparameters(byte[] data)
        {
            byte[] response = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("91")[0], Common.getByteArray("12")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 91-13 / SMFG - Set Pass Through Whitelist
        //************************************************************************
        public static RETURN_CODE SMFG_SetPassThroughWhitelist(string[] ArrayString, ref string strResponse)
        {
            byte[] response = null;
            byte[] data = null;
            int _timeout = 3000;
            bool IsSuccess = false;

            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                if (String.IsNullOrEmpty(ArrayString[0]))
                {
                    strResponse = "No signature found.";
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                string commandstring = "";
                RKIUtility.CommandHelper cmd = new RKIUtility.CommandHelper();
                IsSuccess = cmd.create_IDGCommandString(ArrayString, ref commandstring, ref strResponse);
                if (!IsSuccess)
                {
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                data = Common.getByteArray(commandstring);

                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("91")[0], Common.getByteArray("13")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 91-14 / SMFG - Clear Pass Through Whitelist
        //************************************************************************
        public static RETURN_CODE SMFG_ClearPassThroughWhitelist(byte[] data)
        {
            byte[] response = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("91")[0], Common.getByteArray("14")[0], data, ref response, _timeout, false);
            }
            return rt;
        }



        //************************************************************************
        //*** 91-15 / SMFG - Activate Front Removal Sensor
        //************************************************************************
        public static RETURN_CODE SMFG_ActivateFrontRemovalSensor(byte[] data)
        {
            byte[] response = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("91")[0], Common.getByteArray("15")[0], data, ref response, _timeout, false);
            }
            return rt;
        }


        //************************************************************************
        //*** 12-00 / SMFG - Start PCI Secure CMD
        //************************************************************************
        public static RETURN_CODE SMFG_StartSecureTask(ref string strResponse)
        {
            byte[] response = null;
            string commandstring = "5669564F7465636832001200000100B8CA";
            RETURN_CODE rt;

            rt = RETURN_CODE.RETURN_CODE_FAILED;
            bool isValid = IDTech_PKI.RunDeviceSendCommand(commandstring, ref response, ref strResponse);
            if (isValid)
            {
                rt = RETURN_CODE.RETURN_CODE_DO_SUCCESS;
            }
            else
            {
                strResponse = "SMFG Start Secure Task Command failed. Error Code: " + "0x" + String.Format("{0:X}", (ushort)rt) + ": " + IDTechSDK.errorCode.getErrorString(rt) + "\r\n";
            }
            return rt;
        }


        //**************************************************************************************************************************
        //**************************************************************************************************************************

        //************************************************************************
        //*** 92-00 / RKI - Get Device Certificate
        //************************************************************************
        public static RETURN_CODE RKI_GetDeviceCert(ref byte[] certCSK)
        {
            byte[] certCEK = { 0x00 };

            byte[] _data = null;
            int _timeout = 45000;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                //object[] parameters = new object[] { version };
                //rt = executeDLL(CallerName(), ref parameters);
                //version = (string)parameters[0];
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("92")[0], Common.getByteArray("00")[0], _data, ref certCSK, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 92-01 / RKI - Load Host Certificates
        //************************************************************************
        public static RETURN_CODE RKI_SendCertificates(byte[] rkmsCEK, byte[] rkmsCSK, ref byte[] response)
        {
            byte[] data = { 0x00 };
            byte[] command = { 0x00 };

            if (rkmsCEK == null) return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
            if (rkmsCEK.Length < 10) return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
            if (rkmsCSK == null) return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
            if (rkmsCSK.Length < 10) return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
            //#if (SPECTRUMPRO)
            int lencertCEK = rkmsCEK.Length;
            int lencertCSK = rkmsCSK.Length;

            command = new byte[4 + lencertCEK + lencertCSK];
            // command[0] = (byte)((command.Length-5) & 0xff);
            // command[1] = (byte)(((command.Length - 5) >> 8) & 0xff);
            command[0] = (byte)((lencertCEK >> 8) & 0xff);
            command[1] = (byte)(lencertCEK & 0xff);
            Array.Copy(rkmsCEK, 0, command, 2, lencertCEK);
            command[2 + lencertCEK] = (byte)((lencertCSK >> 8) & 0xff);
            command[3 + lencertCEK] = (byte)(lencertCSK & 0xff);
            Array.Copy(rkmsCSK, 0, command, 4 + lencertCEK, lencertCSK);
            //#endif

            int _timeout = 30000;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                //object[] parameters = new object[] { version };
                //rt = executeDLL(CallerName(), ref parameters);
                //version = (string)parameters[0];
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("92")[0], Common.getByteArray("01")[0], command, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 92-02 / RKI - Key Request
        //************************************************************************
        public static RETURN_CODE RKI_KeyRequest(byte[] _data, ref byte[] response)
        {
            //  byte[] response = null;
            // byte[] _data = null;
            int _timeout = 30000;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("92")[0], Common.getByteArray("02")[0], _data, ref response, _timeout, false);
            }
            return rt;
        }
        
        //************************************************************************
        //*** 92-03 / RKI - SET Keys
        //************************************************************************
        public static RETURN_CODE RKI_SetKeys(byte[] data, ref byte[] response)
        {
            int _timeout = 3000;

            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();
            if (protType == DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("92")[0], Common.getByteArray("03")[0], data, ref response, _timeout, false);
            }
            else
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            return rt;

        }

        //************************************************************************
        //*** 93-00 / SMSG - Activated Removal
        //************************************************************************
        public static RETURN_CODE SMSG_ActivatedRemoval(string[] ArrayString, ref string strResponse)
        {
            byte[] response = null;
            byte[] data = null;
            int _timeout = 3000;
            bool IsSuccess = false;

            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                if (String.IsNullOrEmpty(ArrayString[0]))
                {
                    strResponse = "No signature found.";
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                string commandstring = "";
                RKIUtility.CommandHelper cmd = new RKIUtility.CommandHelper();
                IsSuccess = cmd.create_IDGCommandString(ArrayString, ref commandstring, ref strResponse);
                if (!IsSuccess)
                {
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                data = Common.getByteArray(commandstring);

                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("93")[0], Common.getByteArray("00")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 93-01 / SMSG - Set MSR Whitelist
        //************************************************************************
        public static RETURN_CODE SMSG_SetMSRWhitelist(string[] ArrayString, ref string strResponse)
        {
            byte[] response = null;
            byte[] data = null;
            int _timeout = 3000;
            bool IsSuccess = false;

            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                if (String.IsNullOrEmpty(ArrayString[0]))
                {
                    strResponse = "No signature found.";
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                string commandstring = "";
                RKIUtility.CommandHelper cmd = new RKIUtility.CommandHelper();
                IsSuccess = cmd.create_IDGCommandString(ArrayString, ref commandstring, ref strResponse);
                if (!IsSuccess)
                {
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                data = Common.getByteArray(commandstring);

                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("93")[0], Common.getByteArray("01")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 93-02 / SMSG - Clear MSR Whitelist
        //************************************************************************
        public static RETURN_CODE SMSG_ClearMSRWhitelist(byte[] data)
        {
            byte[] response = null;
            int _timeout = 5000;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("93")[0], Common.getByteArray("02")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 93-03 / SMSG - Set Passthrough Whitelist
        //************************************************************************
        public static RETURN_CODE SMSG_SetPassthroughWhitelist(string[] ArrayString, ref string strResponse)
        {
            byte[] response = null;
            byte[] data = null;
            int _timeout = 3000;
            bool IsSuccess = false;

            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                if (String.IsNullOrEmpty(ArrayString[0]))
                {
                    strResponse = "No signature found.";
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                string commandstring = "";
                RKIUtility.CommandHelper cmd = new RKIUtility.CommandHelper();
                IsSuccess = cmd.create_IDGCommandString(ArrayString, ref commandstring, ref strResponse);
                if (!IsSuccess)
                {
                    return RETURN_CODE.RETURN_CODE_ERR_INVALID_PARAMETER;
                }
                data = Common.getByteArray(commandstring);

                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("93")[0], Common.getByteArray("03")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 93-04 / SMSG - Clear Passthrough Whitelist
        //************************************************************************
        public static RETURN_CODE SMSG_ClearPassthroughWhitelist(byte[] data)
        {
            byte[] response = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("93")[0], Common.getByteArray("04")[0], data, ref response, _timeout, false);
            }
            return rt;
        }

        //************************************************************************
        //*** 12-01 / Get Device Certificate
        //************************************************************************
        public static RETURN_CODE device_getSerialNumber(ref string serialnum)
        {
            byte[] response = null;
            byte[] _data = null;
            int _timeout = 3000;
            RETURN_CODE rt;

            DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                SpectrumInfo info = new SpectrumInfo();
                rt = IDT_SpectrumPro.SharedController.device_setUID(IDT_Device.Spectrum_UID, 2, ref info);
                if (rt == RETURN_CODE.RETURN_CODE_DO_SUCCESS)
                {
                    serialnum = info.serialNumber;
                }
            }
            else
            {
                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("12")[0], Common.getByteArray("01")[0], _data, ref response, _timeout, false);

                if (rt == RETURN_CODE.RETURN_CODE_DO_SUCCESS)
                {
                    serialnum = Common.getHexStringFromBytes(response);
                    serialnum = Common.getASCIIArray(serialnum);
                    System.Diagnostics.Debug.WriteLine("Send Get Serial Number");
                }
            }
            return rt;
        }

        public static RETURN_CODE device_checkProtocol(ref string serialnum, DEVICE_PROTOCOL_Types protType)
        {
            byte[] response = null;
            byte[] _data = null;
            int _timeout = 1500;
            RETURN_CODE rt;

            //DEVICE_PROTOCOL_Types protType = IDT_Device.getProtocolType();

            if (protType != DEVICE_PROTOCOL_Types.DEVICE_PROTOCOL_IDG)
            {
                //object[] parameters = new object[] { serialnum };
                //rt = executeDLL(CallerName(), ref parameters);
                //serialnum = (string)parameters[0];
                rt = RETURN_CODE.RETURN_CODE_NO_DATA_AVAILABLE;

            }
            else
            {

                rt = IDT_Device.SharedController.device_sendVivoCommandP2_ext(Common.getByteArray("12")[0], Common.getByteArray("01")[0], _data, ref response, _timeout, false);

                if (rt == RETURN_CODE.RETURN_CODE_DO_SUCCESS)
                {
                    serialnum = Common.getHexStringFromBytes(response);
                    serialnum = Common.getASCIIArray(serialnum);
                    System.Diagnostics.Debug.WriteLine("Send Get Serial Number");
                }
            }
            return rt;
        }
        public static byte[] getByteArray(String hex)
        {
            if (hex == null) return new byte[] { };
            if (hex.Length == 0) return new byte[] { };

            hex = hex.ToUpper();
            hex = hex.Replace(" ", "");
            byte[] bytes = new byte[] { };
            foreach (char c in hex)
            {
                if (c < '0' || c > 'F') return bytes;
                if (c > '9' && c < 'A') return bytes;
            }
            int NumberChars = hex.Length;
            bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                if ((i + 1) < NumberChars)
                {

                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

                }
                else
                {
                    return bytes;
                }


            }

            return bytes;
        }
        public static string getASCIIArray(String hex)
        {
            byte[] bytedata = getByteArray(hex);
            string str = System.Text.Encoding.ASCII.GetString(bytedata);
            return str;
        }
        public static bool RunDeviceSendCommand(string hexString, ref byte[] response, ref string strResponse)
        {
            RETURN_CODE rt = IDT_Device.SharedController.device_sendDataCommand_ext(hexString, false, ref response, 15000, false);
            if (rt == RETURN_CODE.RETURN_CODE_DO_SUCCESS)
            {

                return true;
            }
            else
            {
                strResponse = "Command failed. Error Code: " + "0x" + String.Format("{0:X}", (ushort)rt) + ": " + IDTechSDK.errorCode.getErrorString(rt) + "\r\n";
            }
            return false;

        }

    }
}

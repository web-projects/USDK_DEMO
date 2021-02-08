using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDTechSDK;
namespace USDKDemo
{
    class SoftwareController
    {
        public static bool softwareControlMSRLED = false;
        public static bool softwareControlBeeper = false;
        static int pauseForFirmwareDelay = 20;
        static int pauseForMSRLEDLast = 500;//ms
        public static void MSR_LED_BLUE_BLINK()
        {
            //MSR waiting for swipe
            Common.pause(300);
            if (SoftwareController.softwareControlMSRLED)
                IDT_Device.SharedController.device_setLED(1, 0x22,"");
            Common.pause(300);
        }
        public static void MSR_LED_RED_SOLID()
        {
            //MSR stop/cancel swipe and failed to swipe
            if (SoftwareController.softwareControlMSRLED)
            {
                Common.pause(pauseForFirmwareDelay);
                IDT_Device.SharedController.device_controlLED(1, 0x01, 0, 0);
                Common.pause(pauseForMSRLEDLast);
                MSR_LED_BACK_TO_IDLE();
            }
        }
        public static void MSR_LED_GREEN_SOLID()
        {
            //MSR swipe succeeded
            if (SoftwareController.softwareControlBeeper)
            {
                Common.pause(pauseForFirmwareDelay);
                IDT_Device.SharedController.device_controlBeep(1, 4000, 500);
            }
            if (SoftwareController.softwareControlMSRLED)
            {
                Common.pause(pauseForFirmwareDelay);
                IDT_Device.SharedController.device_controlLED(1, 0x11, 0, 0);
                Common.pause(pauseForMSRLEDLast);
                MSR_LED_BACK_TO_IDLE();

            }
        }
        private static void MSR_LED_BACK_TO_IDLE()
        {
            //MSR swipe succeeded
            if (SoftwareController.softwareControlMSRLED)
            {
                IDT_Device.SharedController.device_controlLED(1, 0x21, 0, 0);
            }
        }


        public static void getConfiguration()
        {

            if (IDT_Device.getDeviceType() == IDT_DEVICE_Types.IDT_DEVICE_AUGUSTA && IDT_Device.getConnectionType() == DEVICE_INTERFACE_Types.DEVICE_INTERFACE_USB)
            {
                RETURN_CODE rt = 0;
                bool enable = false;
                Common.pause(pauseForFirmwareDelay);
                rt = IDT_Device.SharedController.config_getBeeperController(ref enable);
                SoftwareController.softwareControlBeeper = !enable;
                Common.pause(pauseForFirmwareDelay);
                bool msrLED = false;
                bool iccLED = false;
                rt = IDT_Device.SharedController.config_getLEDController(ref msrLED, ref iccLED);
                SoftwareController.softwareControlMSRLED = !msrLED;
            }
        }
        public static void setFirmwareAsController()
        {
            if (IDT_Device.getDeviceType() == IDT_DEVICE_Types.IDT_DEVICE_AUGUSTA && IDT_Device.getConnectionType() == DEVICE_INTERFACE_Types.DEVICE_INTERFACE_USB)
            {
                RETURN_CODE rt = 0;

                rt = IDT_Device.SharedController.config_setLEDController(true);
                if (rt == RETURN_CODE.RETURN_CODE_DO_SUCCESS)
                {
                    SoftwareController.softwareControlMSRLED = false;
                }
                Common.pause(pauseForFirmwareDelay);
                rt = IDT_Device.SharedController.config_setBeeperController(true);
                if (rt == RETURN_CODE.RETURN_CODE_DO_SUCCESS)
                {
                    SoftwareController.softwareControlBeeper = false;
                }
                Common.pause(pauseForFirmwareDelay);
            }
        }

    }
}

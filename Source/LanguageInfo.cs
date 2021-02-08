using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDTechSDK;
namespace USDKDemo
{
    class DeviceTerminalInfo
    {
        //const message ID


        public const int MSC_ID_PROCESS_WAIT = 0x11;

        public const int MSC_ID_WELCOME = 0x23;

        public const int MSC_ID_AMOUNT = 0x01;
        public const int MSC_ID_AMOUNT_OTHER = 0x24;

        public const int MSC_ID_CANCELLED = 0x21;
        public const int MSC_ID_CANCEL_OR_ENTER = 0x05;

        public const int MSC_ID_ENTER_AMOUNT = 0x08;
        public const int MSC_ID_ENTER_AMOUNT_OTHER = 0x25;
        public const int MSC_ID_ENTER_PIN = 0x09;

        public const int MSC_ID_SWIPE_OR_INSERT = 0x0B;
        public const int MSC_ID_TIME_OUT = 0x19;
        public const int MSC_ID_TERMINATE = 0x17;
        public const int MSC_ID_USE_CHIP_READER = 0x0E;
        public const int MSC_ID_APPROVED = 0x03;
        public const int MSC_ID_TRY_AGAIN = 0x14;
        public const int MSC_ID_CAPK_HASH_VALUE_FAIL = 0x26;


        public static string terminalLanguage = "";
        public static string merchantName = "";
        public static string merchantID = "";
        public static string terminalID = "";

        public static string transType = "";
        public static string amount = "";
        public static int exponent = 2;
        public static string transDate = "";
        public static string transTime = "";


        public static void initialTerminal(bool emvICC)
        {
            byte[] tlv = null;
            RETURN_CODE rt = 0;
            Common.pause(300);
            if (emvICC==true) rt = IDT_Device.SharedController.emv_retrieveTerminalData(ref tlv);
            else rt = IDT_Device.SharedController.ctls_retrieveTerminalData(ref tlv);
            if (rt == RETURN_CODE.RETURN_CODE_DO_SUCCESS)
            {
                string hexValueTerminalLanguage = IDTechTools.getASCIIArrayTagFromTLVs(tlv,"df10");
                if (hexValueTerminalLanguage.Length > 1)   terminalLanguage = hexValueTerminalLanguage.Substring(0, 2);
                System.Diagnostics.Debug.WriteLine("Retrieve Terminal Successful");
                merchantName = IDTechTools.getASCIIArrayTagFromTLVs(tlv, "9F4E");
                merchantID = IDTechTools.getASCIIArrayTagFromTLVs(tlv, "9F16");
                terminalID = IDTechTools.getASCIIArrayTagFromTLVs(tlv, "9F1C");
                string exp = IDTechTools.getHexArrayTagFromTLVs(tlv, "5F36");
                if(exp.Length>0)
                    exponent = Int32.Parse(IDTechTools.getHexArrayTagFromTLVs(tlv, "5F36"));
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Retrieve Terminal failed Error Code: " + "0x" + String.Format("{0:X}", (ushort)rt));
            }




        }

        public static void setLanguage(byte[] language)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            terminalLanguage = encoding.GetString(language, 0, 2);
        }
        public static void setLanguage(string language)
        {
            terminalLanguage = language;
        }
        public static string getDisplayMessage(int id)
        {
            if (id == 0x15)
            {
                int ssss = 0;
                ssss = 2;
            }
            //english
            if (String.Compare(terminalLanguage, "en", true) == 0)
            {
                if (id < languageEN.Length)
                    return languageEN[id];
                else return "UNKNOWN MESSAGE";
            }            
            //french
            else if (String.Compare(terminalLanguage, "fr", true) == 0)
            {
                if (id < languageFR.Length)
                    return languageFR[id];
                else return "UNKNOWN MESSAGE";
            }
          
            //spanish
            else if (String.Compare(terminalLanguage, "sp", true) == 0 || String.Compare(terminalLanguage, "es", true) == 0)
            {
                if (id < languageSP.Length)
                    return languageSP[id];
                else return "UNKNOWN MESSAGE";
            }
      
            //chinese
            else if (String.Compare(terminalLanguage, "zh", true) == 0)
            {
                if (id < languageZH.Length)
                    return languageZH[id];
                else return "UNKNOWN MESSAGE";
            }
            else
            {
                if (id < languageEN.Length)
                    return languageEN[id];
                else return "UNKNOWN MESSAGE";
            }

        }
        public static string  getLanguageCode(string sLanguage)
        {
            if (String.Compare(sLanguage, "es", true) == 0)
                sLanguage = "sp";

            if (String.Compare(sLanguage, "en", true) == 0)
            {
                terminalLanguage = sLanguage;
                return "ENGLISH";
            }
            else if (String.Compare(sLanguage, "fr", true) == 0)
            {
                terminalLanguage = sLanguage;
                return "FRANCAIS";
            }
            else if (String.Compare(sLanguage, "sp", true) == 0 || String.Compare(sLanguage, "es", true) == 0)
            {
                terminalLanguage = sLanguage;
                return "ESPANOL";
            }
            else if (String.Compare(sLanguage, "zh", true) == 0)
            {
                terminalLanguage = sLanguage;
                return "中文";
            }
            else
             return  "(Unsupported)";
        }
        public static string getDisplayMessage(byte[] language, int id)
        {
            if (id > languageEN.Length) return "";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string sLanguage = encoding.GetString(language, 0, 2);
            if (String.Compare(sLanguage, "en", true) == 0)
            {
                terminalLanguage = sLanguage;
                return languageEN[id];
            }
            else if (String.Compare(sLanguage, "fr", true) == 0)
            {
                terminalLanguage = sLanguage;
                return languageFR[id];
            }
            else if (String.Compare(sLanguage, "sp", true) == 0 || String.Compare(sLanguage, "es", true) == 0)
            {
                terminalLanguage = sLanguage;
                return languageSP[id];
            }
            else if (String.Compare(sLanguage, "zh", true) == 0)
            {
                terminalLanguage = sLanguage;
                return languageZH[id];
            }
            else
            {
                terminalLanguage = "en";
                return languageEN[id];
            }

        }
        static string[] languageEN = { "","AMOUNT",
                                "AMOUNT OK ? ",
                                "APPROVED",
                                "CALL YOUR BANK",
                                "CANCEL OR ENTER",
                                "CARD ERROR",
                                "DECLINED",
                                "ENTER AMOUNT",
                                "ENTER PIN:",
                                "INCORRECT PIN",
                                "SWIPE OR INSERT",
                                "CARD",
                                "INSERT CARD",
                                "USE CHIP READER",
                                "NOT ACCEPTED",
                                "GET PIN OK",
                                "PLEASE WAIT...",
                                "PROCESSING ERROR",
                                "USE MAGSTRIPE",
                                "TRY AGAIN",
                                "GO ONLINE",
                                "TRANSACTION ERR",
                                "TERMINATE",
                                "ADVICE",
                                "TIME OUT",
                                "PROCESSING...",
                                "PIN TRY LIMIT EX",
                                "ISSUER AUTH FAIL",
                                "CONTINUE PROCESS",
                                "GET PIN ERROR",
                                "GET PIN FAIL",
                                "NO KEY GET PIN",
                                "CANCELLED",
                                "LAST PIN TRY",
                                "WELCOME",
                                "AMOUNT OTHER",
                                "ENTER AMOUNT OTHER",
                                "CAPK HASH VALUE FAIL",
                                "REMOVE CARD",
        "","","","","","","","","GO ONLINE","","","","","","","","","","","","","","","","TRY MSR AGAIN","LAST MSR TRY","TRY ICC AGAIN","REMOVE CARD","THANK YOU","NOT AUTHORIZED","TRANSACTION COMPLETED","FAIL","ERROR","STOP","SEE MOBILE PHONE","PLEASE SIGN RECEIPT","SIGNATURE REQUIRED","NOT CONNECTED","TOO MANY TAPS","FORM ERROR","OFFLINE AMOUNT","BALANCE:","REFUND","SWIPE CARD","PRESENT CARD","PLEASE TAP OR SWIPE CARD","INSERT/PRESENT CARD","INSERT/PRESENT/SWIPE CARD","USE CHIP & PIN","TRY OTHER INTERFACE","USE OTHER CARD","PLEASE USE OTHER VISA CARD","USE ALTERNATIVE PAYMENT METHOD","NO CARD","PRESENT ONE CARD ONLY","INTERNATIONAL CARD ONLY","SWIPE CARD AGAIN","LAST SWIPE CARD","INSERT CARD AGAIN","CARD BLOCKED","CORRECT PIN","ENTER PIN AGAIN","UNABLE TO ENTER PIN","SELECT NEXT CANDIDATE","CARD READ OK - REMOVE CARD","AVAILABLE:","PLEASE WAIT","INITIALIZING - PLEASE WAIT...","APPROVED, BAL:","DECLINED, BAL:","PIN REQUIRED","PAYMENT TYPE NOT ACCEPTED","AMOUNT","","","","","","","","","","","","","","",""
            ,"APPROVED AVAIL","APPROVED AVAILABLE","AUTHORIZED","AUTHORIZING PLEASE WAIT","CALIBRATION IN PROGRESS PLEASE REMOVE ALL OBJECTS FROM THE KEYPAD","CANCEL","CANCEL TO REJECT","CANCELLED","CARD READ FAILED TRY AGAIN","CARD READ OK","CASH","CASH BACK?","CASHBACK","CHIP CARD READ ERROR","CHOOSE TRANSACTION TYPE","CLEAR","CONFIRM AMOUNT","CONNECTING ONLINE","CONVERT TO CREDIT?","COPYRIGHT","CREDIT","DEBIT","DO NOT REMOVE CARD","DONE","END OF KEY LIFE","ENTER CONFIGURATION ID","ENTER DATE AND TIME","ENTER FORCE TRANSACTION ONLINE","FAIL TO PASSTHRU","FAILED TRY AGAIN","FARE","FATAL ERROR","FEE","INITIALIZING","INPUT DATE OF BIRTH AND PRESS ENTER","INPUT JOINT APPLICANT DATE OF BIRTH AND PRESS ENTER","INPUT JOINT APPLICANT SOCIAL SECURITY NUMBER AND PRESS ENTER","INSERT OR SWIPE CARD","INTERNATIONAL CARD","INTERNATIONAL CARD PLEASE INSERT","INTERNATIONAL CARD PLEASE SWIPE","INTRUSION DETECTED KEYPAD LOCKED","INVALID ENTRY","IS AMOUNT OK?","TRANSACTION COMPLETE","KEYS NOT FOUND","NOT AUTHORIZED, AVAILABLE","OFFLINE","OFFLINE AVAILABLE FUND","OTHER","OTHER AMOUNT","OUT OF ORDER","PAYMENT","PIN TRY LIMIT EXCEEDED","PLEASE ENTER AMOUNT","PLEASE ENTER CASH BACK AMOUNT","PLEASE ENTER PHONE NUMBER","PLEASE ENTER SOCIAL SECURITY NUMBER","PLEASE ENTER TIP","PLEASE ENTER TIP AMOUNT USING KEYPAD","PLEASE ENTER TIP OPTION USING KEYPAD","PLEASE ENTER ZIP CODE","PLEASE INSERT CARD","PLEASE INSERT OR SWIPE CARD","PLEASE INSERT SWIPE OR TRY ANOTHER CARD","PLEASE PRESENT CARD","PLEASE PRESENT ONE CARD ONLY","PLEASE PRESS ENTER ON KEYPAD TO CONTINUE","PLEASE PRESS ENTER TO CONTINUE","PLEASE PUSH ENTER","PLEASE RE-ENTER PHONE NUMBER","PLEASE RE-ENTER ZIP CODE","PLEASE REMOVE CARD","PLEASE SEE ATTENDANT","PLEASE SELECT 1 CARD","PLEASE SELECT OPTION","PLEASE SIGN ON THE SCREEN","PLEASE SIGN THE RECEIPT","PLEASE SWIPE CARD","PLEASE TRY AGAIN","PLEASE TAP CARD","PLEASE USE CHIP READER","PLEASE USE KEYPAD TO CONFIRM","PLEASE USE KEYPAD TO CONFIRM OR CANCEL","PLEASE USE KEYPAD TO SELECT ACCOUNT","PLEASE USE KEYPAD TO SELECT OPTION","PRESS CANCEL TO REJECT","PRESS ENTER TO ACCEPT","PROCESSING","PURCHASE","PURCHASE WITH CASHBACK","PUSH ENTER","RECEIPT?","SIGNATURE REQUIRED TRANSACTION NOT COMPLETED","SUBTOTAL","SWIPE AGAIN","TAP AGAIN","TAP CARD","TAP OR INSERT CARD","TAP OR SWIPE CARD","TAP, INSERT OR SWIPE CARD","TIP","TIP AMOUNT","TOTAL","TOTAL CHARGED TO CARD","TRANSACTION NOT COMPLETED","UNIT DISABLED","VIVOTECH, INC.","VOUCHER","WOULD YOU LIKE A RECEIPT?","AUTHORIZING,","AVAILABLE","BALANCE","REMOVE CARD PLEASE WAIT","SEE PHONE FOR INSTRUCTIONS","SELECT APPLICATION","SELECT LANGUAGE","TRANSACTION CANCELLED","TRANSACTION TIMED OUT","TRANSACTION DECLINED"
        };

        static string[] languageFR = { "","MONTANT",
                                "MONTANT OK?",
                                "APPROUVE",
                                "APPE VOTRE BANQE",
                                "ANNULE OU ENTRER",
                                "ERREUR CARTE",
                                "REFUSE",
                                "ENTREZ MONTANT",
                                "ENTREZ PIN:",
                                "NIP INCORRECT",
                                "PASSER OU INSERT",
                                "CARTE",
                                "INSERT CARTE",
                                "UTI LECTEUR CHIP",
                                "PAS ACCEPTE",
                                "CODE OK",
                                "ATTENDRE...",
                                "ERREUR DE TRAITE",
                                "USE MAGSTRIPE",
                                "REESSAYER",
                                "GO LIGNE",
                                "ERREUR DE TRANS",
                                "RESILIER",
                                "CONSEILS",
                                "TIMEOUT",
                                "PROCESSUS...",
                                "PIN TRY DEPASSE",
                                "EMETTEUR FAIL",
                                "CONTINUER LA",
                                "GET PIN ERROR",
                                "GET PIN FAIL",
                                "NO KEY GET PIN",
                                "ANNULE",
                                "LAST PIN TRY",
                                "BIENVENUE",
                                "MONTANT AUTRES",
                                "ENTRER MONTANT AUTRES",
                                "CAPK HASH VALEUR FAIL",
                                "RETIRER LA CARTE",
        "","","","","","","","","ALLEZ EN LIGNE","","","","","","","","","","","","","","","","TRY MSR AGAIN","LAST MSR TRY","INSERER VOTRE CARTE","RETIRER VOTRE CARTE","MERCI","PAS AUTORISÉ","TRANSACTION TERMINÉE","ECHEC","ERREUR","ARRÊTEZ","VOYEZ VOTRE MOBILE","SIGNEZ LE REÇU","SIGNATURE REQUISE","PAS CONNECTÉ","TROP D'ESSAIS","ERREUR DE FORME","MONTANT HORS LIGNE","SOLDE:","REMBOURSEMENT","PASSEZ VOTRE CARTE","PRÉSENTEZ VOTRE CARTE","PRESENTEZ/PASSEZ VOTRE CARTE","INSÉREZ OU PRES. VOTRE CARTE","INSÉREZ OU PRES. /PASSEZ CARTE","INSÉREZ VOTRE CARTE","ESSAYER UNE AUTRE INTERFACE","UTILISEZ UNE AUTRE CARTE","UTILISEZ UNE AUTRE CARTE VISA","UTILISEZ AUTRE MODE DE PAIEMENT","PAS DE CARTE","PRESENTEZ UNE SEULE CARTE","CARTE INTERNATI- ONALE SEULEMENT","PASSEZ LA CARTE A NOUVEAU","PASSEZ VOTRE DERNIERE CARTE","INSÉREZ VOTRE CARTE A NOUVEAU","CARTE BLOQUÉE","CORRIGER CODE","RE-ENTREZ VOTRE CODE","IMPOSSIBLE D'ENTRER CODE","CHOISIR LE CANDIDAT SUIVANT","LECTURE CARTE OK RETIREZ CARTE","DISPONIBLE:","ATTENDEZ SVP","INITIALISATION ATTENDEZ SVP","APPROUVÉ, SOLDE:","REFUSE, SOLDE:","CODE REQUIS","TYPE DE PAIEMENT PAS ACCEPTÉ","AMOUNT","","","","","","","","","","","","","","",""
                        ,"APPROVED AVAIL","APPROVED AVAILABLE","AUTHORIZED","AUTHORIZING PLEASE WAIT","CALIBRATION IN PROGRESS PLEASE REMOVE ALL OBJECTS FROM THE KEYPAD","CANCEL","CANCEL TO REJECT","CANCELLED","CARD READ FAILED TRY AGAIN","CARD READ OK","CASH","CASH BACK?","CASHBACK","CHIP CARD READ ERROR","CHOOSE TRANSACTION TYPE","CLEAR","CONFIRM AMOUNT","CONNECTING ONLINE","CONVERT TO CREDIT?","COPYRIGHT","CREDIT","DEBIT","DO NOT REMOVE CARD","DONE","END OF KEY LIFE","ENTER CONFIGURATION ID","ENTER DATE AND TIME","ENTER FORCE TRANSACTION ONLINE","FAIL TO PASSTHRU","FAILED TRY AGAIN","FARE","FATAL ERROR","FEE","INITIALIZING","INPUT DATE OF BIRTH AND PRESS ENTER","INPUT JOINT APPLICANT DATE OF BIRTH AND PRESS ENTER","INPUT JOINT APPLICANT SOCIAL SECURITY NUMBER AND PRESS ENTER","INSERT OR SWIPE CARD","INTERNATIONAL CARD","INTERNATIONAL CARD PLEASE INSERT","INTERNATIONAL CARD PLEASE SWIPE","INTRUSION DETECTED KEYPAD LOCKED","INVALID ENTRY","IS AMOUNT OK?","TRANSACTION COMPLETE","KEYS NOT FOUND","NOT AUTHORIZED, AVAILABLE","OFFLINE","OFFLINE AVAILABLE FUND","OTHER","OTHER AMOUNT","OUT OF ORDER","PAYMENT","PIN TRY LIMIT EXCEEDED","PLEASE ENTER AMOUNT","PLEASE ENTER CASH BACK AMOUNT","PLEASE ENTER PHONE NUMBER","PLEASE ENTER SOCIAL SECURITY NUMBER","PLEASE ENTER TIP","PLEASE ENTER TIP AMOUNT USING KEYPAD","PLEASE ENTER TIP OPTION USING KEYPAD","PLEASE ENTER ZIP CODE","PLEASE INSERT CARD","PLEASE INSERT OR SWIPE CARD","PLEASE INSERT SWIPE OR TRY ANOTHER CARD","PLEASE PRESENT CARD","PLEASE PRESENT ONE CARD ONLY","PLEASE PRESS ENTER ON KEYPAD TO CONTINUE","PLEASE PRESS ENTER TO CONTINUE","PLEASE PUSH ENTER","PLEASE RE-ENTER PHONE NUMBER","PLEASE RE-ENTER ZIP CODE","PLEASE REMOVE CARD","PLEASE SEE ATTENDANT","PLEASE SELECT 1 CARD","PLEASE SELECT OPTION","PLEASE SIGN ON THE SCREEN","PLEASE SIGN THE RECEIPT","PLEASE SWIPE CARD","PLEASE TRY AGAIN","PLEASE TAP CARD","PLEASE USE CHIP READER","PLEASE USE KEYPAD TO CONFIRM","PLEASE USE KEYPAD TO CONFIRM OR CANCEL","PLEASE USE KEYPAD TO SELECT ACCOUNT","PLEASE USE KEYPAD TO SELECT OPTION","PRESS CANCEL TO REJECT","PRESS ENTER TO ACCEPT","PROCESSING","PURCHASE","PURCHASE WITH CASHBACK","PUSH ENTER","RECEIPT?","SIGNATURE REQUIRED TRANSACTION NOT COMPLETED","SUBTOTAL","SWIPE AGAIN","TAP AGAIN","TAP CARD","TAP OR INSERT CARD","TAP OR SWIPE CARD","TAP, INSERT OR SWIPE CARD","TIP","TIP AMOUNT","TOTAL","TOTAL CHARGED TO CARD","TRANSACTION NOT COMPLETED","UNIT DISABLED","VIVOTECH, INC.","VOUCHER","WOULD YOU LIKE A RECEIPT?","AUTHORIZING,","AVAILABLE","BALANCE","REMOVE CARD PLEASE WAIT","SEE PHONE FOR INSTRUCTIONS","SELECT APPLICATION","SELECT LANGUAGE","TRANSACTION CANCELLED","TRANSACTION TIMED OUT","TRANSACTION DECLINED"

        };
        static string[] languageSP = { "", "CANTIDAD",
                                "MONTO ES CORRECTO?",
                                "APROVADO",
                                "LLAME A SU BANCO",
                                "CANCELAR O ENTRAR",
                                "ERROR DE TARJETA",
                                "DECLINADO",
                                "INGRESE MONTO",
                                "ENTRAR NPI:",
                                "NPI INCORRECTO",
                                "MOVER O INSERT",
                                "TARJETA",
                                "INSERTAR TARJETA",
                                "USO CHIP  LECTOR",
                                "NO ACEPTADO",
                                "PIN ACEPTADO",
                                "POR FAVOR ESPERE",
                                "ERROR PROCESANDO",
                                "USO DE MAGSTRIPE",
                                "VUELV INTENTARLO",
                                "GO LINEA",
                                "ERROR DE TRANSAC",
                                "TERMINAR",
                                "CONSEJOS",
                                "TIEMPO DE ESPERA",
                                "PROCESANDO...",
                                "TRY PIN SUPERADA",
                                "EMISOR FALLA",
                                "CONTINUAR PROCES",
                                "OBTENER PIN ERR",
                                "OBTENER PIN FALL",
                                "NO CLAVE GET PIN",
                                "CANCELADO",
                                "LAST PIN TRY",
                                "BIENVENIDOS",
                                "IMPORTE OTRAS",
                                "ENTRAR IMPORTE OTRAS",
                                "CAPK HASH VALOR FAIL" ,
                                "RETIRE LA TARJETA",
        "","","","","","","","","GO LINEA","","","","","","","","","","","","","","","","TRY MSR AGAIN","LAST MSR TRY","RETIRER VOTRE CARTE","QUITE TARJETA","GRACIAS","NO AUTORIZADO","TRANSACCIÓN CONCLUIDA","FALLA","ERROR","PARE","VER TELÉFONO","POR FAVOR FIRMAR RECIBO","FIRMA REQUERIDA","NO CONECTADO","TENTATIVAS EXCEDIDO","ERROR DE FORMA","VALOR OFFLINE","BALANCE:","REEMBOLSO","PASE LA TARJETA","PRESENTE TARJETA","PRESENTE/PASE LA TARJETA","INSIRA/PRESENTE LA TARJETA","INSIRA/PRESENTE/ PASE TARJETA","USAR CHIP & PIN","TENTE OTRA FORMA DE PAGO","USE OTRA TARJETA","FAVOR USE OTRA TARJETA VISA","USE OTRA FORMA DE PAGO","SIN TARJETA","PRESENTE SOLO UNA TARJETA","SOLO TARJETAS INTERNACIONALES","PASE LA TARJETA DE NOVO","ÚLTIMO PASE DE LA TARJETA","INSIRA TARJETA DE NOVO","TARJETA BLOQUEADA","CORREGIR PIN","ENTRAR PIN DE NOVO","NO SE PUEDE ENTRAR PIN","ELIGE PRÓXIMO CANDIDATO","TARJETA OK RETIRE TARJETA","DISPONIBLE:","POR FAVOR ESPERE","INICIALIZANDO POR FAVOR ESPERE","APROBADO, BAL:","RECHAZADO, BAL:","PIN REQUERIDO","TIPO DE PAGO NO ACEPTADO","AMOUNT","","","","","","","","","","","","","","",""
                        ,"APPROVED AVAIL","APPROVED AVAILABLE","AUTHORIZED","AUTHORIZING PLEASE WAIT","CALIBRATION IN PROGRESS PLEASE REMOVE ALL OBJECTS FROM THE KEYPAD","CANCEL","CANCEL TO REJECT","CANCELLED","CARD READ FAILED TRY AGAIN","CARD READ OK","CASH","CASH BACK?","CASHBACK","CHIP CARD READ ERROR","CHOOSE TRANSACTION TYPE","CLEAR","CONFIRM AMOUNT","CONNECTING ONLINE","CONVERT TO CREDIT?","COPYRIGHT","CREDIT","DEBIT","DO NOT REMOVE CARD","DONE","END OF KEY LIFE","ENTER CONFIGURATION ID","ENTER DATE AND TIME","ENTER FORCE TRANSACTION ONLINE","FAIL TO PASSTHRU","FAILED TRY AGAIN","FARE","FATAL ERROR","FEE","INITIALIZING","INPUT DATE OF BIRTH AND PRESS ENTER","INPUT JOINT APPLICANT DATE OF BIRTH AND PRESS ENTER","INPUT JOINT APPLICANT SOCIAL SECURITY NUMBER AND PRESS ENTER","INSERT OR SWIPE CARD","INTERNATIONAL CARD","INTERNATIONAL CARD PLEASE INSERT","INTERNATIONAL CARD PLEASE SWIPE","INTRUSION DETECTED KEYPAD LOCKED","INVALID ENTRY","IS AMOUNT OK?","TRANSACTION COMPLETE","KEYS NOT FOUND","NOT AUTHORIZED, AVAILABLE","OFFLINE","OFFLINE AVAILABLE FUND","OTHER","OTHER AMOUNT","OUT OF ORDER","PAYMENT","PIN TRY LIMIT EXCEEDED","PLEASE ENTER AMOUNT","PLEASE ENTER CASH BACK AMOUNT","PLEASE ENTER PHONE NUMBER","PLEASE ENTER SOCIAL SECURITY NUMBER","PLEASE ENTER TIP","PLEASE ENTER TIP AMOUNT USING KEYPAD","PLEASE ENTER TIP OPTION USING KEYPAD","PLEASE ENTER ZIP CODE","PLEASE INSERT CARD","PLEASE INSERT OR SWIPE CARD","PLEASE INSERT SWIPE OR TRY ANOTHER CARD","PLEASE PRESENT CARD","PLEASE PRESENT ONE CARD ONLY","PLEASE PRESS ENTER ON KEYPAD TO CONTINUE","PLEASE PRESS ENTER TO CONTINUE","PLEASE PUSH ENTER","PLEASE RE-ENTER PHONE NUMBER","PLEASE RE-ENTER ZIP CODE","PLEASE REMOVE CARD","PLEASE SEE ATTENDANT","PLEASE SELECT 1 CARD","PLEASE SELECT OPTION","PLEASE SIGN ON THE SCREEN","PLEASE SIGN THE RECEIPT","PLEASE SWIPE CARD","PLEASE TRY AGAIN","PLEASE TAP CARD","PLEASE USE CHIP READER","PLEASE USE KEYPAD TO CONFIRM","PLEASE USE KEYPAD TO CONFIRM OR CANCEL","PLEASE USE KEYPAD TO SELECT ACCOUNT","PLEASE USE KEYPAD TO SELECT OPTION","PRESS CANCEL TO REJECT","PRESS ENTER TO ACCEPT","PROCESSING","PURCHASE","PURCHASE WITH CASHBACK","PUSH ENTER","RECEIPT?","SIGNATURE REQUIRED TRANSACTION NOT COMPLETED","SUBTOTAL","SWIPE AGAIN","TAP AGAIN","TAP CARD","TAP OR INSERT CARD","TAP OR SWIPE CARD","TAP, INSERT OR SWIPE CARD","TIP","TIP AMOUNT","TOTAL","TOTAL CHARGED TO CARD","TRANSACTION NOT COMPLETED","UNIT DISABLED","VIVOTECH, INC.","VOUCHER","WOULD YOU LIKE A RECEIPT?","AUTHORIZING,","AVAILABLE","BALANCE","REMOVE CARD PLEASE WAIT","SEE PHONE FOR INSTRUCTIONS","SELECT APPLICATION","SELECT LANGUAGE","TRANSACTION CANCELLED","TRANSACTION TIMED OUT","TRANSACTION DECLINED"

        };

        static string[] languageZH = { "",
                                "金额",
                                "确定金额?",
                                "通过",
                                "请联系您的银行",
                                "取消或确定",
                                "读卡错误",
                                "卡被拒",
                                "输入金额",
                                "请输入密码:",
                                "密码错误",
                                "请刷卡或插卡",
                                "卡",
                                "请插卡",
                                "使用芯片卡",
                                "无法接受",
                                "获取密码正确",
                                "等候中",
                                "处理错误",
                                "使用磁条卡",
                                "请重试",
                                "在线",
                                "交易错误",
                                "终止",
                                "建议",
                                "超时",
                                "处理中...",
                                "密码尝试次数过多",
                                "与发卡机构认证",
                                "继续处理",
                                "密码错误",
                                "获取密码错误",
                                "无法输入密码",
                                "取消",
                                "最后一次输入密码",
                                "欢迎使用",
                                "返现",
                                "输入返现",
                                "公钥哈希值错误",
                                 "请取卡",
       "","","","","","","","","在线","","","","","","","","","","","","","","","","再次使用磁条卡","最后一次使用磁条卡","公钥哈希值错误","请取卡","谢谢您","未授权","交易完成","失败","错误","停止","请查看手机","请签收据","需要签名","未连接","过多尝试","格式错误","线下金额","余额：","退款","请刷卡","请拍卡","请拍卡或刷卡","请插卡或拍卡","请插卡或拍卡或刷卡","使用芯片及密码","请尝试其他界面","请用其他卡","请用其他VISA卡","请用另外一种支付方式","无卡","请拍一张卡","请用国际卡","请再次刷卡","最后一次刷卡","请再次插卡","卡被锁","请更正密码","请再次输入密码","无法输入密码","请选择下一个候选","读卡成功 请移卡","可用：","请等待","初始化中 请等待","通过，余额：","拒绝，余额：","需要密码","不接受此支付方式","AMOUNT","","","","","","","","","","","","","","",""
                        ,"APPROVED AVAIL","APPROVED AVAILABLE","AUTHORIZED","AUTHORIZING PLEASE WAIT","CALIBRATION IN PROGRESS PLEASE REMOVE ALL OBJECTS FROM THE KEYPAD","CANCEL","CANCEL TO REJECT","CANCELLED","CARD READ FAILED TRY AGAIN","CARD READ OK","CASH","CASH BACK?","CASHBACK","CHIP CARD READ ERROR","CHOOSE TRANSACTION TYPE","CLEAR","CONFIRM AMOUNT","CONNECTING ONLINE","CONVERT TO CREDIT?","COPYRIGHT","CREDIT","DEBIT","DO NOT REMOVE CARD","DONE","END OF KEY LIFE","ENTER CONFIGURATION ID","ENTER DATE AND TIME","ENTER FORCE TRANSACTION ONLINE","FAIL TO PASSTHRU","FAILED TRY AGAIN","FARE","FATAL ERROR","FEE","INITIALIZING","INPUT DATE OF BIRTH AND PRESS ENTER","INPUT JOINT APPLICANT DATE OF BIRTH AND PRESS ENTER","INPUT JOINT APPLICANT SOCIAL SECURITY NUMBER AND PRESS ENTER","INSERT OR SWIPE CARD","INTERNATIONAL CARD","INTERNATIONAL CARD PLEASE INSERT","INTERNATIONAL CARD PLEASE SWIPE","INTRUSION DETECTED KEYPAD LOCKED","INVALID ENTRY","IS AMOUNT OK?","TRANSACTION COMPLETE","KEYS NOT FOUND","NOT AUTHORIZED, AVAILABLE","OFFLINE","OFFLINE AVAILABLE FUND","OTHER","OTHER AMOUNT","OUT OF ORDER","PAYMENT","PIN TRY LIMIT EXCEEDED","PLEASE ENTER AMOUNT","PLEASE ENTER CASH BACK AMOUNT","PLEASE ENTER PHONE NUMBER","PLEASE ENTER SOCIAL SECURITY NUMBER","PLEASE ENTER TIP","PLEASE ENTER TIP AMOUNT USING KEYPAD","PLEASE ENTER TIP OPTION USING KEYPAD","PLEASE ENTER ZIP CODE","PLEASE INSERT CARD","PLEASE INSERT OR SWIPE CARD","PLEASE INSERT SWIPE OR TRY ANOTHER CARD","PLEASE PRESENT CARD","PLEASE PRESENT ONE CARD ONLY","PLEASE PRESS ENTER ON KEYPAD TO CONTINUE","PLEASE PRESS ENTER TO CONTINUE","PLEASE PUSH ENTER","PLEASE RE-ENTER PHONE NUMBER","PLEASE RE-ENTER ZIP CODE","PLEASE REMOVE CARD","PLEASE SEE ATTENDANT","PLEASE SELECT 1 CARD","PLEASE SELECT OPTION","PLEASE SIGN ON THE SCREEN","PLEASE SIGN THE RECEIPT","PLEASE SWIPE CARD","PLEASE TRY AGAIN","PLEASE TAP CARD","PLEASE USE CHIP READER","PLEASE USE KEYPAD TO CONFIRM","PLEASE USE KEYPAD TO CONFIRM OR CANCEL","PLEASE USE KEYPAD TO SELECT ACCOUNT","PLEASE USE KEYPAD TO SELECT OPTION","PRESS CANCEL TO REJECT","PRESS ENTER TO ACCEPT","PROCESSING","PURCHASE","PURCHASE WITH CASHBACK","PUSH ENTER","RECEIPT?","SIGNATURE REQUIRED TRANSACTION NOT COMPLETED","SUBTOTAL","SWIPE AGAIN","TAP AGAIN","TAP CARD","TAP OR INSERT CARD","TAP OR SWIPE CARD","TAP, INSERT OR SWIPE CARD","TIP","TIP AMOUNT","TOTAL","TOTAL CHARGED TO CARD","TRANSACTION NOT COMPLETED","UNIT DISABLED","VIVOTECH, INC.","VOUCHER","WOULD YOU LIKE A RECEIPT?","AUTHORIZING,","AVAILABLE","BALANCE","REMOVE CARD PLEASE WAIT","SEE PHONE FOR INSTRUCTIONS","SELECT APPLICATION","SELECT LANGUAGE","TRANSACTION CANCELLED","TRANSACTION TIMED OUT","TRANSACTION DECLINED"

        };

    }
}

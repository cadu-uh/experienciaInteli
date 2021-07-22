using System;
using QuickFix;
using log4net;

namespace AppQuickFix
{
    class MyAplicationQuickFix : MessageCracker, IApplication
    {

        private log4net.ILog logger = LogManager.GetLogger(typeof(MyAplicationQuickFix));

        public void OnCreate(SessionID sessionID)
        {
            Console.WriteLine("Passou pelo Oncreate");
            log4net.Config.BasicConfigurator.Configure();
        }

        public void OnLogon(SessionID sessionID) { Console.WriteLine("Passou pelo Onlogon"); }

        public void OnLogout(SessionID sessionID) { Console.WriteLine("Passou Pelo Onlogout"); }

        public void FromAdmin(QuickFix.Message message, SessionID sessionID)
        {

        }

        public void FromApp(QuickFix.Message message, SessionID sessionID)
        {
            char[] delimiterChars = { '=', '\u0001' };
            string[] msgSplit = message.ToString().Split(delimiterChars);

            var result = "BeginString: " + msgSplit[1] + "\n" +
                         "BodyLength: " + msgSplit[3] + "\n" +
                         "MsgType: " + msgSplit[5] + "\n" +
                         "MsgSeqNun: " + msgSplit[7] + "\n" +
                         "SenderCompID: " + msgSplit[9] + "\n" +
                         "SendingTime: " + msgSplit[11] + "\n" +
                         "TargetCompID: " + msgSplit[13] + "\n" +
                         "ClOrdID: " + msgSplit[15] + "\n" +
                         "HandlInst: " + msgSplit[17] + "\n" +
                         "OrderQty: " + msgSplit[19] + "\n" +
                         "OrdType: " + msgSplit[21] + "\n" +
                         "Price: " + msgSplit[23] + "\n" +
                         "Side: " + msgSplit[25] + "\n" +
                         "Symbol: " + msgSplit[27] + "\n" +
                         "TransactTime: " + msgSplit[29] + "\n" +
                         "NoPartyIDs: " + msgSplit[31] + "\n" +
                         "CheckSum: " + msgSplit[33] + "\n";

            logger.Debug("FromApp: \n" + result);
        }

        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
        {

        }

        public void ToApp(QuickFix.Message message, SessionID sessionId)
        {

        }
    }
}

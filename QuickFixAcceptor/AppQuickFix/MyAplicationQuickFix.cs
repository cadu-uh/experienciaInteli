using System;
using QuickFix;
using log4net;
using Newtonsoft.Json;

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

            var valores = new TagDescription
            {
                BeginString = msgSplit[1],
                BodyLength = msgSplit[3],
                MsgType = msgSplit[5],
                MsgSeqNun = msgSplit[7],
                SenderCompID = msgSplit[9],
                SendingTime = msgSplit[11],
                TargetCompID = msgSplit[13],
                ClOrdID = msgSplit[15],
                HandlInst = msgSplit[17],
                OrderQty = msgSplit[19],
                OrdType = msgSplit[21],
                Price = msgSplit[23],
                Side = msgSplit[25],
                Symbol = msgSplit[27],
                TransactTime = msgSplit[29],
                NoPartyIDs = msgSplit[31],
                CheckSum = msgSplit[33],
            };

            valores = TagDescription.Description(valores);
            var output = JsonConvert.SerializeObject(valores, Formatting.Indented);

            logger.Debug("FromApp: \n" + output);
        }

        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
        {

        }

        public void ToApp(QuickFix.Message message, SessionID sessionId)
        {

        }
    }
}

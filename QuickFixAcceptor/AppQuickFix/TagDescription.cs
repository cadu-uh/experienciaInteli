
namespace AppQuickFix
{
    public class TagDescription
    {
        public string BeginString { get; set; }
        public string BodyLength { get; set; }
        public string MsgType { get; set; }
        public string MsgSeqNun { get; set; }
        public string SenderCompID { get; set; }
        public string SendingTime { get; set; }
        public string TargetCompID { get; set; }
        public string ClOrdID { get; set; }
        public string HandlInst { get; set; }
        public string OrderQty { get; set; }
        public string OrdType { get; set; }
        public string Price { get; set; }
        public string Side { get; set; }
        public string Symbol { get; set; }
        public string TransactTime { get; set; }
        public string NoPartyIDs { get; set; }
        public string CheckSum { get; set; }

        public static TagDescription Description(TagDescription tags)
        {
            if (tags.MsgType.Equals("D"))
            {
                tags.MsgType = "Oder Single";
            }

            if (tags.HandlInst.Equals("1"))
            {
                tags.HandlInst = "Automated Execution Order Private";
            }
            if (tags.OrdType.Equals("2"))
            {
                tags.OrdType = "Limit";
            }
            if (tags.Side.Equals("1"))
            {
                tags.Side = "Buy";
            }
            return tags;
        }       
    }


}

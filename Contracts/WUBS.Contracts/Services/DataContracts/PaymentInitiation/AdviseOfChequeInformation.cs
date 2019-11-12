namespace WUBS.Contracts.Services.DataContracts
{
    public class AdviseOfChequeInformation
    {
        private string sendersReference;
        /// <summary>
        /// :20:
        /// </summary>
        public string SendersReference
        {
            get { return sendersReference; }
            set { sendersReference = string.Format(":20:{0}", value); }
        }

        private string sendersCorrespondent;
        /// <summary>
        /// :53B:
        /// </summary>
        public string SendersCorrespondent
        {
            get { return sendersCorrespondent; }
            set { sendersCorrespondent = value == null ? string.Empty : string.Format(":53B:/{0}", value); }
        }

        private string receiversCorrespondent;
        /// <summary>
        /// :54A:
        /// </summary>
        public string ReceiversCorrespondent
        {
            get { return receiversCorrespondent; }
            set { receiversCorrespondent = value == null ? string.Empty : string.Format(":54A:/{0}", value); }
        }

        private string senderToReceiverInformation;
        /// <summary>
        /// :72:/ACC/
        /// </summary>
        public string SenderToReceiverInformation
        {
            get { return senderToReceiverInformation; }
            set { senderToReceiverInformation = value == null ? string.Empty : string.Format(":72:/ACC/{0}", value); }
        }

        private string chequeNumber;
        /// <summary>
        /// :21:
        /// </summary>
        public string ChequeNumber
        {
            get { return chequeNumber; }
            set { chequeNumber = value == null ? string.Empty : string.Format(":21:{0}", value); }
        }

        private string dateOfIssue;
        /// <summary>
        /// :30:
        /// </summary>
        public string DateOfIssue
        {
            get { return dateOfIssue; }
            set { dateOfIssue = value == null ? string.Empty : string.Format(":30:{0}", value); }
        }

        private string amountA;
        /// <summary>
        /// :32A:
        /// </summary>
        public string AmountA
        {
            get { return amountA; }
            set { amountA = value == null ? string.Empty : string.Format(":32A:{0}", value); }
        }

        private string amountB;
        /// <summary>
        /// :32B:
        /// </summary>
        public string AmountB
        {
            get { return amountB; }
            set { amountB = value == null ? string.Empty : string.Format(":32B:{0}", value); }
        }

        private string payerId;

        /// <summary>
        /// :50K:
        /// </summary>
        public string PayerId
        {
            get { return payerId; }
            set { payerId = value == null ? string.Empty : string.Format(":50K:/{0}", value); }
        }
        
        public string PayerDetails { get; set; }
        
        private string drawerBank;
        /// <summary>
        /// :52B:
        /// </summary>
        public string DrawerBank
        {
            get { return drawerBank; }
            set { drawerBank = value == null ? string.Empty : string.Format(":52B:/{0}", value); }
        }

        private string payee;
        /// <summary>
        /// :59:
        /// </summary>
        public string Payee
        {
            get { return payee; }
            set { payee = value == null ? string.Empty : string.Format(":59:{0}", value); }
        }
    }
}

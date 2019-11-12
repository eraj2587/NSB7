﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class CustomerCreditTransferInitiation
    {
        [XmlElement("GrpHdr")]
        public GroupHeader GroupHeader { get; set; }

        [XmlElement("CdtTrfTxInf")]
        public List<CreditTransferTransactionInformation> CreditTransferTransactionInformations { get; set; }
    }
}

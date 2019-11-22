using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.LineItems;

namespace NSB.Contracts.Services.DataContracts.Orders
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class OrderForRepurchaseResult
    {
        [DataMember]
        public string ConfirmationNumber;
        [DataMember]
        public DateTimeOffset? OrderDate;
        [DataMember]
        public Entities.Entity Payer;
        [DataMember]
        public int RequestedBy;
        [DataMember]
        public Money BranchOriginalProfitMoney;
        [DataMember]
        public List<OrderForRepurchaseLineItem> LineItems;
        [DataMember]
        public List<User> Contacts;
        [DataMember]
        public List<string> RepurchaseConfirmationNumberChain;
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.LineItems;

namespace WUBS.Contracts.Services.DataContracts.Repurchase
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class FindOrderForRepurchaseResult
    {
        [DataMember]
        public Money BranchOriginalProfitMoney;

        [DataMember]
        public Entities.Entity Payer;
        
        [DataMember]
        public DateTime BookingDate;

        [DataMember]
        public List<OrderForRepurchaseLineItem> OriginalLineItems;

        [DataMember]
        public List<string> RepurchaseConfirmationNumberChain;

        [DataMember]
        public List<User> Contacts;

        [DataMember]
        public int RequestedById;
    }
}
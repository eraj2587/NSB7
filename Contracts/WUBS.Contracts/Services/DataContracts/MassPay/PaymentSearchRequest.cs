﻿using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class PaymentSearchRequest
    {
        [DataMember] public string PartnerCustomerId;
        [DataMember] public decimal? Amount;
        [DataMember] public string Currency;
        [DataMember] public DateTime? StartDate;
        [DataMember] public DateTime? EndDate;
        [DataMember] public int MaxResults;
    }
}

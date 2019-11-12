using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class LineItemSearchResultItem : LineItem
    {
        [DataMember] public Entities.Entity Payer;
        [DataMember] public string PayerProcessingCenter;
        [DataMember] public Entities.Entity Payee;
        [DataMember] public string PayeeProcessingCenter;
        [DataMember] public OrderInfoForLineItemSearchResult OrderInfo;
    }
}
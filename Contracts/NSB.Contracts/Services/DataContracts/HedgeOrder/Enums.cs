
using System.ComponentModel;
namespace NSB.Contracts.Services.DataContracts
{
    public enum LimitOrderStatus : byte
    {
        Build = 0,
        Created = 1,
        Pending = 2,
        Active = 3,
        Filled = 4,
        Rejected = 6,
        Cancelled = 7,
        Expired = 9,
        PendingCancel = 10,
        Modified =11,
        ExpiryPending = 12
    }

    public enum LimitOrderStatusRequest : byte
    {
        //Undefined = 0,
        Build = 0,
        Created = 1,
        Pending = 2,
        Active = 3,
        Filled = 4,
        Rejected = 6,
        Cancelled = 7,
        Expired = 9,
        PendingCancel = 10,
        Modified = 11,
        ExpiryPending = 12
    }

    public enum LimitOrderTradeDirectionRequest : byte
    {
        Buy = 1,
        Sell = 2
    }

    public enum LimitOrderSortColumn : byte
    {
        Undefined = 0,  
        Status = 1,
        ProcessType = 2,
        Office = 3,
        OrderType = 4,
        ExpiryDateTime = 5,
        LastUpdatedAt = 6
    }

    public enum LimitOrderBySort : byte
    {
        Desc = 0,
        Asc = 1
    }

    public enum LimitOrderProcessType : byte
    {
        Auto = 0,
        Manual = 1
    }

    public enum LimitOrderProcessTypeRequest : byte
    {
        Undefined = 0,
        Auto = 1,
        Manual = 2
    }

    public enum LimitOrderType : byte
    {
        TakeProfit = 0,
        StopLoss = 1
    }

    public enum LimitOrderTypeRequest : byte
    {
        Undefined = 0,
        TakeProfit = 1,
        StopLoss = 2
    }

    public enum NoteType : byte
    {
        PublicVisible = 0,
        TreasuryVisible = 1,
    }

    public enum UserType : byte
    {
        Dealer = 0,
        Treasury = 1
    }


    public enum LimitOrderEvent : byte
    {
        Undefined = 0,
        Built = 1,
        Submitted = 2,
        Processed = 3,
        Approved = 4,
        Rejected = 5,
        Cancelled = 6,
        ApprovedCancel = 7,
        RejectedCancel = 8,
        Modified = 9,
        Filled = 10,
        Expired = 11,
        ReBuilt = 12,
        Quoted = 13,
        Calculated = 14,
        RatesRefreshed = 15,
        Updated = 16,
        ExpiryPending=17,
        RejectedExpiry = 18
    }

    public enum SortDirection
    {
        [Description("Ascending")]
        Ascending,
        [Description("Descending")]
        Descending
    }
}

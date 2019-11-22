namespace NSB.Contracts.Events
{
    public interface ICctOrderReleased
    {
        int OpsLogId { get; set; }
        int CctStatusId { get; set; }
        int OrderDetailId { get; set; }
        bool IsHold { get; set; }
        string HoldReason { get; set; }
        int ClientOrderId { get; set; }
    }
}

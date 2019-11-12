namespace WUBS.Contracts.Events
{
    [Endpoint("WUBS.Endpoints.CtxProcessing")]
	public interface INeedCtxData
	{
		long PaymentBatchId { get; set; }
	}
}

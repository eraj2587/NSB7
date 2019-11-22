namespace NSB.Contracts.Events
{
    [Endpoint("NSB.Endpoints.CtxProcessing")]
	public interface INeedCtxData
	{
		long PaymentBatchId { get; set; }
	}
}

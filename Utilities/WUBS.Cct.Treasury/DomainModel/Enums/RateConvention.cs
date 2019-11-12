namespace WUBS.Cct.Treasury.DomainModel.Enums
{

    /// <summary>
    /// Convention is direct when rate says how much of 
    /// settlement currency must be paid for one unit of
    /// trade currency.
    /// It's indirect otherwise.
    /// </summary>
    public enum RateConvention
    {
        Direct = 0, //In Home currency IsPer = 0
        Indirect = 1, //Per Home currency IsPer = 1
        Default = 2 //Reuters default
    }
}

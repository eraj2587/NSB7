namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface IBankAccountMapper
    {
        string GetBankListCodeByToAccountId(int? toAccountId);
    }
}
using WUBS.Cct.Treasury.DomainModel.Enums.Utility;

namespace WUBS.Cct.Treasury.DomainModel.Enums
{
    public enum ItemType
    {
        [CctCode("Undefined")]
        Undefined,
        [CctCode("SaleLockIn")]
        LockInSaleToClient,
        [CctCode("LockSAdj")]
        LockInSaleAdjustment,
        [CctCode("Draft")]
        Draft,
        [CctCode("EFT")]
        EFT,
        [CctCode("Acct2Cash")]
        Acct2Cash,
        [CctCode("Acct2Mobile")]
        Acct2Mobile,
        [CctCode("RepoOfFee")]
        RepoOfFee,
        [CctCode("RefundItem")]
        RefundItem,
        [CctCode("RepoFee")]
        RepoFee,
        [CctCode("Acct2Cash_R")]
        Acct2CashRepo,
        [CctCode("Acct2Mobile_R")]
        Acct2MobileRepo,
        [CctCode("FTSweepNostroToOps")]
        FtSweepNostroToOps,
        [CctCode("FTSweepOpsToNostro")]
        FtSweepOpsToNostro,
        [CctCode("FTSweepNostroToOps_R")]
        FtSweepNostroToOpsReversal,
        [CctCode("FTSweepOpsToNostro_R")]
        FtSweepOpsToNostroReversal,
        [CctCode("FutHldg")]
        FutureIntoHolding,
        [CctCode("IntoHldg")]
        IntoHolding,
        [CctCode("SaleLockIn_R")]
        LockInSaleToClientRepo
    }
}
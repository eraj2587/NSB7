using WUBS.Cct.Treasury.DomainModel.Enums.Utility;

namespace WUBS.Cct.Treasury.DomainModel.Enums
{
    public enum PickListType
    {
        [CctCode("FundedBy")] LineItemFundingMethod,

        [CctCode(("EntSprdTyp"))] MarkupType,

        [CctCode(("CurrCapab"))] CurrencyCapability,

        [CctCode(("StateCapab"))] StateBasedCapability,

        [CctCode(("ChrgTyp"))] EftChargeType,

        [CctCode("PayPurpose")] PaymentPurpose,

        [CctCode("NtfyMeth")] ConfirmationDeliveryMethod,

        [CctCode(("EntityId"))] EntityIdentification,

        [CctCode(("DebitSecur"))] DirectDebitAccountSecurityScheme,

        [CctCode(("PmtMeth"))] PaymentMethod,

        [CctCode("DEPMethod")] DepositHandlingMethod,

        [CctCode(("ITCapab"))] ItemTypeCapability,

        [CctCode(("FwdDelType"))] ForwardDeliveryType,

        [CctCode(("TypeClass"))] ClientTypeClassification,

        [CctCode("TranType")] RemitterType,

        [CctCode("StmntInit")] ClientSettlementInitiationPreference,

        [CctCode("ClientCat")] ClientCategory,

        [CctCode("GatewayQEC")] GatewayQuoteErrorCode,

        [CctCode("PayWuTAF")] TestAnswerFlag,

        [CctCode("LegOLApp")] OrderCaptureSystem,

        [CctCode(("InvLang"))] InvoiceLanguage,
    }
}

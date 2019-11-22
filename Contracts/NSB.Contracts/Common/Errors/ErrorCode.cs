using System;

namespace NSB.Contracts.Common.Errors
{
    public enum ErrorCode
    {
        [ErrorException(typeof(ApplicationException))]
        Unknown = 0,
        [ErrorException(typeof(Exception))]
        MissingStringDefinition = 1000,
        [ErrorException(typeof(Exception))]
        ExceptionDoesNotContainProperConstructor_String = 1001,

        // Business rules
        TransientOrderShouldHaveAssignedQuote = 10001,
        TransientOrderShouldHaveAssignedPayor = 10002,
        TransientOrderShouldHaveAssignedPayee = 10003,
        TransientOrderPaymentMethodMustBeHolding = 10004,
        TransientOrderSettlementMethodMustBeHolding = 10005,
        TransientOrderMustHaveAssignedPurpose = 10006,
        TransientOrderMustHaveAssignedSettlementCurrency = 10007,
        TransientOrderMustHaveTradeableSettlementCurrency = 10008,
        TransientOrderMustUseSettlementCurrencyEnabledForHolding = 10009,
        TransientOrderMustHaveAssignedTradeCurrency = 10010,
        TransientOrderMustHaveTradeableTradeCurrency = 10011,
        TransientOrderMustUseTradeCurrencyEnabledForHolding = 10012,
        TransientOrderMustHaveAssignedAmount = 10013,
        TransientOrderMustHavePositiveAmount = 10014,
        TransientOrderAmountMustBeLessThanTradeCurrencyMaximum = 10015,
        TransientOrderAmountMustBeGreaterThanTradeCurrencyMinimum = 10016
    }
}

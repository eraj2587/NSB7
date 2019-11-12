using System;
using System.ComponentModel;

namespace WUBS.Contracts.Services.DataContracts.Payments
{
    public class SortingByColumn
    {
        public static string GetSortBy(Type type, string value, string defaultSortColumn = null)
        {
            string columnName = string.Empty;
            switch (type.Name)
            {
                case "PaymentStoreRequest":
                    SearchPaymentsRequestSortColumnEnum sortColumnEnum;
                    if (Enum.TryParse(value, out sortColumnEnum))
                    {
                        columnName = sortColumnEnum.ToDescription();
                    }
                    break;
            }

            return !string.IsNullOrEmpty(defaultSortColumn) && string.IsNullOrEmpty(columnName) ? defaultSortColumn : columnName;
        }
    }

    public static class EnumsHelperExtension
    {
        public static string ToDescription(this Enum value)
        {
            DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : value.ToString();
        }
    }

}

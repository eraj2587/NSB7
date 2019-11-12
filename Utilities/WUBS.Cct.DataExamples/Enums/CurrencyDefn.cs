namespace WUBS.Cct.DataExamples.Enums
{
    public class CurrencyDefn
    {
        public int ID { get; set; }
        public string Code { get; set; }

        public static CurrencyDefn AUD = new CurrencyDefn(35, "AUD");
        public static CurrencyDefn CAD = new CurrencyDefn(37, "CAD");
        public static CurrencyDefn CHF = new CurrencyDefn(38, "CHF");
        public static CurrencyDefn CZK = new CurrencyDefn(39, "CZK");
        public static CurrencyDefn EUR = new CurrencyDefn(43, "EUR");
        public static CurrencyDefn GBP = new CurrencyDefn(48, "GBP");
        public static CurrencyDefn HKD = new CurrencyDefn(50, "HKD");
        public static CurrencyDefn MXN = new CurrencyDefn(56, "MXN");
        public static CurrencyDefn MYR = new CurrencyDefn(57, "MYR");
        public static CurrencyDefn NOK = new CurrencyDefn(60, "NOK");
        public static CurrencyDefn USD = new CurrencyDefn(66, "USD");
        public static CurrencyDefn ZAR = new CurrencyDefn(68, "ZAR");
        public static CurrencyDefn IDR = new CurrencyDefn(79, "IDR");
        public static CurrencyDefn ILS = new CurrencyDefn(80, "ILS");
        public static CurrencyDefn SGD = new CurrencyDefn(64, "SGD");
        public static CurrencyDefn CNH = new CurrencyDefn(275, "CNH");

        public CurrencyDefn(int id, string code)
        {
            ID = id;
            Code = code;
        }
    }
}
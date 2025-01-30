namespace Omi.Fix.Specification;

public static partial class Convert
{
    /// <summary>
    ///  Convert Fix type field to Omi Fix intermediate type
    /// </summary>
    public static Omi.Fix.Specification.DataType TypeFor(string type)
    {
        switch (type.Trim())
        {
            case "Char":
            case "char":
                return DataType.Char;

            case "Boolean":
            case "bool":
                return DataType.Boolean;

            case "data":
                return DataType.Data;

            case "float":
                return DataType.Float;

            case "Amt":
                return DataType.Amt;

            case "Price":
            case "price":
                return DataType.Price;

            case "PriceOffset":
                return DataType.PriceOffset;

            case "Qty":
            case "qty":
                return DataType.Qty;

            case "Int":
            case "int":
            case "long":
                return DataType.Int;

            case "day-of-month":
            case "dayofmonth":
            case "DayOfMonth":
                return DataType.DayOfMonth;

            case "String":
            case "string":
                return DataType.String;

            case "Currency":
                return DataType.Currency;

            case "Exchange":
            case "exchange":
                return DataType.String;

            case "LocalMktDate":
                return DataType.LocalMktDate;

            case "MonthYear":
            case "monthyear":
                return DataType.MonthYear;

            case "MultipleValueString":
                return DataType.MultipleValueString;

            case "UTCDate":
            case "UtcDate":
            case "utcdate":
            case "date":
                return DataType.UtcDate;

            case "UTCTimeOnly":
            case "UtcTimeOnly":
            case "utctime":
            case "time":
                return DataType.UtcTimeOnly;

            case "UTCTimestamp":
            case "datetime":
                return DataType.UtcTimestamp;

            default:
                return DataType.None;
        }
    }
}

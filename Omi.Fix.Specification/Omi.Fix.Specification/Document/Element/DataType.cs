namespace Omi.Fix.Specification;

/// <summary>
///  Normalized Fix specification data type
/// </summary>

public enum DataType
{
    /// <summary>
    ///  Invalid Fix data ype
    /// </summary>
    None,

    /// <summary>
    ///  Alpha-numeric free format strings, can include any character or punctuation except the delimiter. All char fields are case sensitive (i.e. omi != Omi).
    /// </summary>
    String,

    /// <summary>
    ///  String Type one or more single character space delimited values.
    /// </summary>
    MultipleCharValue,

    /// <summary>
    ///  String Type containing one or more space delimited values.
    /// </summary>
    MultipleValueString,

    /// <summary>
    ///  String Type representing a country using ISO 3166 Country [421] code (2 character) values.
    /// </summary>
    Country,

    /// <summary>
    ///  String Type representing a currency.
    /// </summary>
    Currency,

    /// <summary>
    ///  String Type representing a market or exchange.
    /// </summary>
    Exchange,

    /// <summary>
    ///  String Type representing month of a year in YYYYMM format. Valid values: YYYY = 0000-9999, MM = 01-12.
    /// </summary>
    MonthYear,

    /// <summary>
    ///  String Type date/time combination represented in UTC (Universal Time Coordinated, also known as "GMT") in either YYYYMMDD-HH:MM:SS (whole seconds) or YYYYMMDD-HH:MM:SS.sss (milliseconds) format, colons, dash, and period required.
    /// </summary>
    UtcTimestamp,

    /// <summary>
    ///  String Type time represented in UTC (Universal Time Coordinated, also known as "GMT") in either HH:MM:SS (whole seconds) or HH:MM:SS.sss (milliseconds) format, colons, and period required.
    /// </summary>
    UtcTimeOnly,

    /// <summary>
    ///  String Type date Date represented in UTC (Universal Time Coordinated, also known as “GMT”) in YYYYMMDD format.
    /// </summary>
    UtcDateOnly,

    /// <summary>
    ///  String Type date represented in UTC (Universal Time Coordinated, also known as "GMT") in YYYYMMDD format. Valid values: YYYY = 0000-9999, MM = 01-12, DD = 01-31.
    /// </summary>
    UtcDate,

    /// <summary>
    ///  String Type date of local market (vs. UTC) in YYYYMMDD format. Valid values: YYYY = 0000-9999, MM = 01-12, DD = 01-31.
    /// </summary>
    LocalMktDate,

    /// <summary>
    ///  String Type representing time field that contains the time represented based on ISO 8601. This is the time with a UTC offset to allow identification of local time and time zone of that time. 
    /// </summary>
    TzTimeOnly,

    /// <summary>
    ///  String Type representing a time/date combination representing local time with an offset to UTC to allow identification of local time and timezone offset of that time.
    /// </summary>
    TzTimestamp,

    /// <summary>
    ///  Raw data with no format or content restrictions. Data fields are always immediately preceded by a length field. The length field should specify the number of bytes of the value of the data field (up to but not including the terminating SOH).
    /// </summary>
    Data,

    /// <summary>
    ///  Contains an XML document raw data with no format or content restrictions. XMLData fields are always immediately preceded by a length field. The length field should specify the number of bytes of the value of the data field (up to but not including the terminating SOH).
    /// </summary>
    XmlData,

    /// <summary>
    ///  String Type identifier for a national language - uses ISO 639-1 standard
    /// </summary>
    Language,

    /// <summary>
    ///  Single character value, can include any alphanumeric character or punctuation except the delimiter. All char fields are case sensitive (i.e. m != M).
    /// </summary>
    Char,

    /// <summary>
    ///  Char Type containing one of two values: 'Y' = True/Yes, 'N' = False/No.
    /// </summary>
    Boolean,

    /// <summary>
    ///  Sequence of digits with optional decimal point and sign character (ASCII characters "-", "0" - "9" and "."); the absence of the decimal point within the string will be interpreted as the float representation of an integer value. All float fields must accommodate up to fifteen significant digits.
    /// </summary>
    Float,

    /// <summary>
    ///  Float Type typically representing a Price [44] times a Qty.
    /// </summary>
    Amt,

    /// <summary>
    ///  Float Type representing a percentage.
    /// </summary>
    Percentage,

    /// <summary>
    ///  Float Type typically representing a Price.
    /// </summary>
    Price,

    /// <summary>
    ///  Float Type typically representing representing a price offset, which can be mathematically added to a Price [44].
    /// </summary>
    PriceOffset,

    /// <summary>
    ///  Float Type capable of storing either a whole number of "shares" or a decimal value containing decimal places for non-share quantity asset classes.
    /// </summary>
    Qty,

    /// <summary>
    ///  Sequence of digits without commas or decimals and optional sign character. 
    /// </summary>
    Int,

    /// <summary>
    ///  Int Type representing a particular day of a month. Valid values: 1-31.
    /// </summary>
    DayOfMonth,

    /// <summary>
    ///  Int Type representing the length in bytes. Value must be positive.
    /// </summary>
    Length,

    /// <summary>
    ///  Int Type representing the number of repeating values in a group
    /// </summary>
    NumInGroup,

    /// <summary>
    ///  Int Type representing a message sequence number. Value must be positive.
    /// </summary>
    SeqNum,

    /// <summary>
    ///  Int Type representing a field's tag number when using FIX "Tag=Value" syntax. Value must be positive and may not contain leading zeros.
    /// </summary>
    TagNum
}

public static partial class Extensions
{
    /// <summary>
    ///  Convert Fix to FIX standard display for intermediate datatype
    /// </summary>
    public static string DisplayAsFixStandard(this DataType type)
        => type switch
        {
            DataType.MultipleCharValue => "MultipleCharValue",
            DataType.MultipleValueString => "MultipleStringValue",
            DataType.Country => "Country",
            DataType.Currency => "Currency",
            DataType.Exchange => "Exchange",
            DataType.MonthYear => "MonthYear",
            DataType.UtcTimestamp => "UTCTimestamp",
            DataType.UtcTimeOnly => "UTCTimeOnly",
            DataType.UtcDateOnly => "UTCDateOnly",
            DataType.UtcDate => "UTCDate",
            DataType.LocalMktDate => "LocalMktDate",
            DataType.TzTimeOnly => "TZTimeOnly",
            DataType.TzTimestamp => "TZTimestamp",
            DataType.Data => "data",
            DataType.XmlData => "XMLdata",
            DataType.Language => "Language",
            DataType.Char => "char",
            DataType.Boolean => "Boolean",
            DataType.Float => "float",
            DataType.Qty => "Qty",
            DataType.Amt => "Amt",
            DataType.Percentage => "Percentage",
            DataType.Price => "Price",
            DataType.PriceOffset => "PriceOffset",
            DataType.Int => "int",
            DataType.Length => "Length",
            DataType.SeqNum => "SeqNum",
            DataType.TagNum => "TagNum",
            DataType.NumInGroup => "NumInGroup",
            DataType.DayOfMonth => "DayOfMonth",

            _ => "String",
        };
}

namespace SRFixBase
{
using System.Collections.Generic;
    public static partial class FixTag
    {
        public static class iLink3
        {

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Unique identifier for Order as assigned by the buy-side (institution, broker, intermediary etc.). Uniqueness must be guaranteed within a single trading day. Firms, particularly those which electronically submit multi-day orders, trade globally or throughout market close periods, should ensure uniqueness across days, for example by embedding a date within the ClOrdID field </para>
        ///</summary>
        public const ushort ClOrdID = 11;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Total quantity filled </para>
        ///</summary>
        public const ushort CumQty = 14;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Identifies the currency for the price </para>
        ///</summary>
        public const ushort Currency = 15;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Unique identifier of execution message as assigned by the exchange and is unique per day across all instruments and across all good till orders. </para>
        ///</summary>
        public const ushort ExecID = 17;

        ///<summary>
        ///<para> Datatype: MultipleCharValue</para>
        ///<para> Instructions for order handling on exchange. Since more than one instruction is applicable to an order, this field can represent those using a bitset. </para>
        ///</summary>
        public const ushort ExecInst = 18;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Identifies class or source of the SecurityID (Tag 48) value. Constant value </para>
        ///</summary>
        public const ushort SecurityIDSource = 22;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> Price of this (last) fill </para>
        ///</summary>
        public const ushort LastPx = 31;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Quantity of shares bought/sold on this (last) fill </para>
        ///</summary>
        public const ushort LastQty = 32;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique identifier for order as assigned by the exchange. Uniqueness is guaranteed within a single trading day across all instruments. </para>
        ///</summary>
        public const ushort OrderID = 37;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Number of shares or contracts ordered </para>
        ///</summary>
        public const ushort OrderQty = 38;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Identifies status of order as new. Constant value </para>
        ///</summary>
        public const ushort OrdStatus = 39;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Order type </para>
        ///</summary>
        public const ushort OrdType = 40;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Contains the ClOrd of the cancelled order </para>
        ///</summary>
        public const ushort OrigCIOrdID = 41;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> Price per share or contract. Conditionally required if the order type requires a price (not market orders). </para>
        ///</summary>
        public const ushort Price = 44;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Tag 9726 - SeqNum of the rejected message </para>
        ///</summary>
        public const ushort RefSeqNum = 45;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Security ID as defined by CME. For the security ID list, see the security definition messages </para>
        ///</summary>
        public const ushort SecurityID = 48;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Side of order </para>
        ///</summary>
        public const ushort Side = 54;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Instrument Short Name for TM Repo  </para>
        ///</summary>
        public const ushort Symbol = 55;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Reject reason details. Will be used only for descriptive rejects </para>
        ///</summary>
        public const ushort Text = 58;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Specifies how long the order remains in effect </para>
        ///</summary>
        public const ushort TimeInForce = 59;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Time the transaction represented by this ExecutionReport (35=8) occurred. Expressed as nanoseconds since epoch time </para>
        ///</summary>
        public const ushort TransactTime = 60;

        ///<summary>
        ///<para> Datatype: LocalMktDate</para>
        ///<para> Specific date of trade settlement </para>
        ///</summary>
        public const ushort SettlDate = 64;

        ///<summary>
        ///<para> Datatype: LocalMktDate</para>
        ///<para> Indicates date of trading day (expressed in local time at place of trade). </para>
        ///</summary>
        public const ushort TradeDate = 75;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Total quantity cancelled for this order. </para>
        ///</summary>
        public const ushort CxlQuantity = 84;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> The stop price of a stop protect or stop limit order. (Conditionally required if OrdType = 3 or 4). </para>
        ///</summary>
        public const ushort StopPx = 99;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Code to identify reason for cancel rejection </para>
        ///</summary>
        public const ushort CxlRejReason = 102;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Code to identify reason for order rejection </para>
        ///</summary>
        public const ushort OrdRejReason = 103;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Minimum quantity of an order to be executed </para>
        ///</summary>
        public const ushort MinQty = 110;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique identifier for mass quote populated by the client system </para>
        ///</summary>
        public const ushort QuoteID = 117;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Reason for execution rejection </para>
        ///</summary>
        public const ushort DKReason = 127;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique identifier for quote request being responded to </para>
        ///</summary>
        public const ushort QuoteReqID = 131;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> Bid price/rate. This goes together with bid size (tag 134). Note that either BidPx, OfferPx or both must be specified for a new quote. Resting quote can be cancelled by not providing either of these four parameters. </para>
        ///</summary>
        public const ushort BidPx = 132;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> Offer price/rate. This goes together with offer size (tag 135). Note that either BidPx, OfferPx or both must be specified for a new quote. Resting quote can be cancelled by not providing either of these four parameters. </para>
        ///</summary>
        public const ushort OfferPx = 133;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Quantity of bid. This goes together with bid price (tag 132). </para>
        ///</summary>
        public const ushort BidSize = 134;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Quantity of offer. This goes together with offer price (tag 133). </para>
        ///</summary>
        public const ushort OfferSize = 135;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Specifies the number of repeating symbols specified. </para>
        ///</summary>
        public const ushort NoRelatedSym = 146;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Describes the specific ExecutionRpt as new. Constant value </para>
        ///</summary>
        public const ushort ExecType = 150;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Quantity open for further execution;  LeavesQty = OrderQty (38) - CumQty (14); Only present for outrights and spreads and not spread legs </para>
        ///</summary>
        public const ushort LeavesQty = 151;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Indicates type of security </para>
        ///</summary>
        public const ushort SecurityType = 167;

        ///<summary>
        ///<para> Datatype: MonthYear</para>
        ///<para> Instrument expiration; earliest leg maturity in the options strategy  </para>
        ///</summary>
        public const ushort MaturityMonthYear = 200;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> The number of quoute entries for a quote set </para>
        ///</summary>
        public const ushort NoQuoteEntries = 295;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> The number of sets of quotes in the message. Conditionally required if 298=100 </para>
        ///</summary>
        public const ushort NoQuoteSets = 296;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Identifies the status of the quote acknowledgement. </para>
        ///</summary>
        public const ushort QuoteStatus = 297;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Identifies the type of Quote Cancel. A working quote can be cancelled by providing either it's instrument, instrument group or by cancelling all. </para>
        ///</summary>
        public const ushort QuoteCancelType = 298;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique identifier for a quote. The QuoteEntryID stays with the quote as a static identifier even if the quote is updated. For fills this value is transposed into client order ID (tag 11) </para>
        ///</summary>
        public const ushort QuoteEntryID = 299;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Contains reason (error code) the corresponding MassQuote message has been rejected. When this tag is returned, all quotes in the corresponding Mass Quote message are rejected. </para>
        ///</summary>
        public const ushort QuoteRejectReason = 300;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique id for the Quote Set </para>
        ///</summary>
        public const ushort QuoteSetID = 302;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Total number of quotes for the quote set across all messages. Should be the sum of all NoQuoteEntries in each message that has repeating quotes that are part of the same quote set. Required if NoQuoteEntries > 0. Since fragmentation is not supported in practice this will always be equal to the value of NoQuoteEntries </para>
        ///</summary>
        public const ushort TotNoQuoteEntries = 304;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Underlying Security ID. This value will be the same as that contained in Security Definition Tag 48-SecurityID of the underlying instrument </para>
        ///</summary>
        public const ushort UnderlyingSecurityID = 309;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique identifier for a security definition request. It is incumbent on the market participant to maintain uniqueness </para>
        ///</summary>
        public const ushort SecurityReqID = 320;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Type of Security Definition Request. Constant value </para>
        ///</summary>
        public const ushort SecurityReqType = 321;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique ID of a SecurityDefinition message </para>
        ///</summary>
        public const ushort SecurityResponseID = 322;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Type of security definition message response.  </para>
        ///</summary>
        public const ushort SecurityResponseType = 323;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The tag number of the FIX/FIXP field being referenced which is invalid </para>
        ///</summary>
        public const ushort RefTagID = 371;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> The MsgType of the FIX message being referenced. </para>
        ///</summary>
        public const ushort RefMsgType = 372;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Will be present when trade at fixing is assigned fixing price </para>
        ///</summary>
        public const ushort ExecRestatementReason = 378;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The value of the business-level ID field on the message being referenced. Required unless the corresponding ID field was not specified. </para>
        ///</summary>
        public const ushort BusinessRejectRefID = 379;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Code to identify reason for a Business Message Reject message </para>
        ///</summary>
        public const ushort BusinessRejectReason = 380;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Total amount traded (in notional) in base currency for the Spot </para>
        ///</summary>
        public const ushort GrossTradeAmt = 381;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates total number of leg fills for the spread; Will represent total number of ExecutionReportTradeSpreadLeg messages sent for the spread and will be set to 0 when spread leg fills are consolidated with spread fill </para>
        ///</summary>
        public const ushort TotalNumSecurities = 393;

        ///<summary>
        ///<para> Datatype: LocalMktDate</para>
        ///<para> Date of order expiration (last day the order can trade), always expressed in terms of the local market date. Applicable only to GTD orders which expire at the end of the trading session specified. This has to be a future or current session date and cannot be in the past. </para>
        ///</summary>
        public const ushort ExpireDate = 432;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Identifies the type of request that a Cancel Reject is in response to; Constant value </para>
        ///</summary>
        public const ushort CxlRejResponseTo = 434;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Required if NoPartyIDs(453) > 0. Used to identify classification source. Constant value </para>
        ///</summary>
        public const ushort PartyIDSource = 447;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Required if NoPartyIDs(453) > 0. Identification of the PartyDetailsListRequestID of PartyDetailsDefinitionRequestAck </para>
        ///</summary>
        public const ushort PartyID = 448;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Required if NoPartyIDs(453) > 0. Identifies the type of PartyID(448) </para>
        ///</summary>
        public const ushort PartyRole = 452;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Number of PartyID (448), PartyIDSource (447), and PartyRole (452) entries. Applicable only if specific PartyDetailsDefinitions are being requested otherwise set to 0 </para>
        ///</summary>
        public const ushort NoPartyIDs = 453;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> For derivatives a date and time stamp to indicate when this order was booked with the agent prior to submission to the exchange. Indicates the time at which the order was finalized between the buyer and seller prior to submission. Expressed as nanoseconds since epoch time  </para>
        ///</summary>
        public const ushort TransBkdTime = 483;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique identifier that allows linking id spread summary fill notice with leg fill notice and trade cancel messages </para>
        ///</summary>
        public const ushort SecExecID = 527;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Total number of orders affected by the Order Mass  Action Request. Will be returned as zero for rejects or if request is accepted but no orders could be cancelled. If fragmented then this is the sum of NoAffectedOrders across all messages with the same MassActionReportID. Otherwise will have same value as NoAffectedOrders when one or more orders is cancelled. </para>
        ///</summary>
        public const ushort TotalAffectedOrders = 533;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Total number of order identifiers affected by the OrderMass Action Request. Only used if orders could actually be cancelled otherwise will be set to zero. Must be followed by OrigCIOrdID </para>
        ///</summary>
        public const ushort NoAffectedOrders = 534;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Order ID of an order cancelled by a mass action request. </para>
        ///</summary>
        public const ushort AffectedOrderID = 535;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Type of quote requested  </para>
        ///</summary>
        public const ushort QuoteType = 537;

        ///<summary>
        ///<para> Datatype: LocalMktDate</para>
        ///<para> Date of maturity </para>
        ///</summary>
        public const ushort MaturityDate = 541;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Identifier for a cross order. Will be present if execution report is in response to a cross order </para>
        ///</summary>
        public const ushort CrossID = 548;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> ype of cross being submitted to a market. (if in response to a cross order) </para>
        ///</summary>
        public const ushort CrossType = 549;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Constant. Indicates if one side or the other of a cross order should be prioritized </para>
        ///</summary>
        public const ushort CrossPrioritization = 550;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Number of Side repeating group instances  </para>
        ///</summary>
        public const ushort NoSides = 552;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Number of Leg executions; Will currently be set to 0 and in future will contain the leg fills for the spread when spread leg fills are consolidated with the spread fill as a single message </para>
        ///</summary>
        public const ushort NoLegs = 555;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Capacity of customer placing the order. Used by futures exchanges to indicate the CTICode (customer type indicator) as required by the US CFTC (Commodity Futures Trading Commission) </para>
        ///</summary>
        public const ushort CustOrderCapacity = 582;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique ID of OrderMassStatusRequest as assigned by the customer and present in Execution Report as well </para>
        ///</summary>
        public const ushort MassStatusReqID = 584;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Specifies the scope of the OrderMassStatusRequest within the context of working orders only. Status will be returned for all orders matching the criteria specified here for Session and Firm </para>
        ///</summary>
        public const ushort MassStatusReqType = 585;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Multileg instrument's individual security's SecurityID </para>
        ///</summary>
        public const ushort LegSecurityID = 602;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The side of this individual leg of a multileg security </para>
        ///</summary>
        public const ushort LegSide = 624;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> Execution price assigned to a leg of a multileg instrument </para>
        ///</summary>
        public const ushort LegLastPx = 637;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> This field is being added to report whether incoming new order/cancel replace entered the book or subsequently rests on the book with either large or standard order size priority </para>
        ///</summary>
        public const ushort PriorityIndicator = 638;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Identifies specific type of UDS; valid values are COMBO, COVERED and REPO </para>
        ///</summary>
        public const ushort SecuritySubType = 762;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Represents the term code </para>
        ///</summary>
        public const ushort TerminationType = 788;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Used to uniquely identify a specific Order Status Request message </para>
        ///</summary>
        public const ushort OrdStatusReqID = 790;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> Underlying price associated with a derivative instrument. Price for the future used in calculating the conversion of vol. to premium for the option. Only applicable for vol quoted option trades. </para>
        ///</summary>
        public const ushort UnderlyingPx = 810;

        ///<summary>
        ///<para> Datatype: float</para>
        ///<para> The rate of change in the price of a derivative with respect to the movement in the price of the underlying instrument(s) upon which the derivative instrument price is based. Calculated delta, expressed as a decimal between -1 and 1. Only applicable for vol quoted option trades. </para>
        ///</summary>
        public const ushort OptionDelta = 811;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Average pricing indicator </para>
        ///</summary>
        public const ushort AvgPxIndicator = 819;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Contains the workup ID; unique per instrument per day </para>
        ///</summary>
        public const ushort TradeLinkID = 820;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> For tag 827-ExpirationCycle=2, instrument expires as indicated in market data Security Definition (tag 35-MsgType=d) repeating block:  Tag 865-EventType=7 (Last Eligible Trade Date) Tag 1145-EventTime </para>
        ///</summary>
        public const ushort ExpirationCycle = 827;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Represents a trade at fixing price </para>
        ///</summary>
        public const ushort TrdType = 828;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> The presence of DiscretionPrice on an order indicates that the trader wishes to display one price but will accept trades at another price </para>
        ///</summary>
        public const ushort DiscretionPrice = 845;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates whether the message is the last message in a sequence of messages to support fragmentation </para>
        ///</summary>
        public const ushort LastFragment = 893;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates whether this message is the last report message in response to an Order Mass Status Request. Required if responding to a Order Mass Status Request. </para>
        ///</summary>
        public const ushort LastRptRequested = 912;

        ///<summary>
        ///<para> Datatype: LocalMktDate</para>
        ///<para> Start date of a financing deal, i.e. the date the buyer pays the seller cash and takes control of the collateral </para>
        ///</summary>
        public const ushort StartDate = 916;

        ///<summary>
        ///<para> Datatype: LocalMktDate</para>
        ///<para> End date of a financing deal, i.e. the date the seller reimburses the buyer and takes back control of the collateral </para>
        ///</summary>
        public const ushort EndDate = 917;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Host assigned entity ID that can be used to reference all components of a cross; sides +  strategy + legs. The HostCrossID will also be used to link together components of the  cross order. For example, each individual execution report associated with the order will carry HostCrossID in order to tie them back together to the original cross order. </para>
        ///</summary>
        public const ushort HostCrossID = 961;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates how long the order as specified in the side stays in effect. SideTimeInForce allows a two-sided cross order to specify order behavior separately for each side. Defaults to Day if absent. </para>
        ///</summary>
        public const ushort SideTimeInForce = 962;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates if the order was initially received manually (as opposed to electronically) </para>
        ///</summary>
        public const ushort ManualOrderIndicator = 1028;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Codes that apply special information that the Broker / Dealer needs to report, as specified by the customer. Defines source of the order  </para>
        ///</summary>
        public const ushort CustOrderHandlingInst = 1031;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates the status of the execution acknowledgement </para>
        ///</summary>
        public const ushort ExecAckStatus = 1036;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Total amount traded (in notional) in counter currency for the Spot </para>
        ///</summary>
        public const ushort CalculatedCcyLastQty = 1056;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates if order was incoming or resting for the match event </para>
        ///</summary>
        public const ushort AggressorIndicator = 1057;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The quantity to be displayed . Required for iceberg orders. On orders specifies the qty to be displayed, on execution reports the currently displayed quantity </para>
        ///</summary>
        public const ushort DisplayQty = 1138;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Specifies the Product Group for which working orders should be cancelled. Conditionally required if MassActionScope=?Product Group? (Tag1374=10). Will be ignored if present for any other criteria specified in MassActionScope besides Product Group  </para>
        ///</summary>
        public const ushort SecurityGroup = 1151;

        ///<summary>
        ///<para> Datatype: float</para>
        ///<para> Annualized volatility for option model calculations. Only applicable for vol quoted option trades. </para>
        ///</summary>
        public const ushort Volatility = 1188;

        ///<summary>
        ///<para> Datatype: float</para>
        ///<para> Time to expiration in years calculated as the number of days remaining to expiration divided by 365 days per year. This value is expressed as a decimal portion of a year, typically the days to expiration divided by the days in a year. Currently the year assumption is 365. Only applicable for vol quoted option trades. </para>
        ///</summary>
        public const ushort TimeToExpiration = 1189;

        ///<summary>
        ///<para> Datatype: float</para>
        ///<para> Interest rate. Usually some form of short term rate. </para>
        ///</summary>
        public const ushort RiskFreeRate = 1190;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Specifies the market segment (physical match engine partition) for which working orders should be cancelled. Conditionally Required if MassActionScope=?Market Segment? (Tag 1374=9). Will be ignored if present for any other criteria specified in MassActionScope besides Market Segment </para>
        ///</summary>
        public const ushort MarketSegmentID = 1300;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Indicates if all of the information sent in this message with a unique new PartyDetailsListRequestID is a new addition or deletion of existing information associated with an existing PartyDetailsListRequestID. For PartyDetailsListRequestID=FFFFFFFF this should always be set to "A" </para>
        ///</summary>
        public const ushort ListUpdateAction = 1324;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Specifies the number of fill reasons included in this Execution Report </para>
        ///</summary>
        public const ushort NoFills = 1362;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Used as an identifier for each fill reason or allocation reported in single Execution Report. Required if NoFills(1362) > 0. Append FillExecID with ExecID to derive unique identifier for each fill reason or allocation </para>
        ///</summary>
        public const ushort FillExecID = 1363;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> Price of this fill reason or allocation. Required if NoFills(1362) > 0. Same as LastPx(31) </para>
        ///</summary>
        public const ushort FillPx = 1364;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Quantity bought/sold for this fill reason </para>
        ///</summary>
        public const ushort FillQty = 1365;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique ID of Order Mass Action Report as assigned by CME. If fragmented then all messages must have the same value. </para>
        ///</summary>
        public const ushort MassActionReportID = 1369;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Specifies the type of action requested; Constant value </para>
        ///</summary>
        public const ushort MassActionType = 1373;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Specifies the scope of the action    </para>
        ///</summary>
        public const ushort MassActionScope = 1374;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Specifies the action taken by CME when it received the Order Mass Action Request. </para>
        ///</summary>
        public const ushort MassActionResponse = 1375;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Reason Order Mass Action Request was rejected. Required if Mass Action Response=0. </para>
        ///</summary>
        public const ushort MassActionRejectReason = 1376;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Fill quantity for the leg instrument </para>
        ///</summary>
        public const ushort LegLastQty = 1418;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Refers to the ID of the related PartyDetailsDefinitionRequest message which will logically be tied to this message </para>
        ///</summary>
        public const ushort PartyDetailsListReqID = 1505;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The unique ID assigned to the trade once it is received or matched by the exchange </para>
        ///</summary>
        public const ushort SideTradeID = 1506;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Refers back to the unique ID assigned to the corrected trade </para>
        ///</summary>
        public const ushort OrigSideTradeID = 1507;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Refers to the unique identifier of the PartyDetailsListRequest(35=CF) message used to request this PartyDetailsListReport </para>
        ///</summary>
        public const ushort PartyDetailsListReportID = 1510;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Status of party details list request </para>
        ///</summary>
        public const ushort RequestResult = 1511;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates total number of PartyDetailsListReports being returned in response to PartyDetailsListRequest </para>
        ///</summary>
        public const ushort TotNumParties = 1512;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates to recipient whether trade is clearing at execution prices LastPx (tag 31) or alternate clearing price (prior day settlement price) </para>
        ///</summary>
        public const ushort ClearingTradePriceType = 1598;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Provides the name of the application system being used to generate FIX application messages. </para>
        ///</summary>
        public const ushort TradingSystemName = 1603;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Provides the version of the application system being used to initiate FIX application messages. </para>
        ///</summary>
        public const ushort TradingSystemVersion = 1604;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Provides the vendor of the application system </para>
        ///</summary>
        public const ushort TradingSystemVendor = 1605;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Enumeration of the Fill Reason field using Integer. This identifies the type of match algorithm </para>
        ///</summary>
        public const ushort FillYieldType = 1622;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Number of requesting party identifiers. Will be zero if specific PartyDetailsDefinitionID's are being requested. Will be populated only if all PartyDetailsDefinitions are being requested for a specific Firm </para>
        ///</summary>
        public const ushort NoRequestingPartyIDs = 1657;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Party identifier for the requesting party. Required when NoRequestingPartyIDs(1657) > 0 </para>
        ///</summary>
        public const ushort RequestingPartyID = 1658;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Identifies the source of the RequestingPartyID(1658) value. Required when NoRequestingPartyIDs(1657) > 0. Constant value </para>
        ///</summary>
        public const ushort RequestingPartyIDSource = 1659;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Identifies the type or role of the RequestingPartyID(1658) specified. Constant value </para>
        ///</summary>
        public const ushort RequestingPartyRole = 1660;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Number of party details. More than one occurrence of the same party role is not allowed and will be rejected </para>
        ///</summary>
        public const ushort NoPartyDetails = 1671;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Number of party updates. Constant value of 1 </para>
        ///</summary>
        public const ushort NoPartyUpdates = 1676;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> The identification of the party. Required when NoPartyDetails(1671) > 0 </para>
        ///</summary>
        public const ushort PartyDetailID = 1691;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Used to identify source of PartyDetailID value. Required when NoPartyDetails(1671) greater than 0. Constant value of C </para>
        ///</summary>
        public const ushort PartyDetailIDSource = 1692;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Identifies the type of PartyDetailID. Required when NoPartyDetails(1671) > 0 </para>
        ///</summary>
        public const ushort PartyDetailRole = 1693;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Used by submitting firm to group trades being allocated into an average price group. The trades in average price group will be used to calculate an average price for the group </para>
        ///</summary>
        public const ushort AvgPxGroupID = 1731;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Number of fills which comprise fill quantity </para>
        ///</summary>
        public const ushort NoOrderEvents = 1795;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The type of event affecting an order </para>
        ///</summary>
        public const ushort OrderEventType = 1796;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> This is a unique ID which ties together a specific fill between two orders; It will be unique per instrument per day </para>
        ///</summary>
        public const ushort OrderEventExecID = 1797;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Action that caused the event to ocurr. 100=Binary Trade Reporting </para>
        ///</summary>
        public const ushort OrderEventReason = 1798;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> Refers to the fill price; same as LastPx (Tag 31)  </para>
        ///</summary>
        public const ushort OrderEventPx = 1799;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Refers to the specific fill quantity between this order and the opposite order  </para>
        ///</summary>
        public const ushort OrderEventQty = 1800;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Will not be present for BrokerTec US; Will be populated with the firm ID of the opposite order for BrokerTec EU bilateral trades </para>
        ///</summary>
        public const ushort OrderEventText = 1802;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Designates the account type to be used for the order when submitted to clearing </para>
        ///</summary>
        public const ushort ClearingAccountType = 1816;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Status of party details definition request </para>
        ///</summary>
        public const ushort PartyDetailRequestStatus = 1878;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Status of party detail definition for one party </para>
        ///</summary>
        public const ushort PartyDetailDefinitionStatus = 1879;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The ExecID (17) value corresponding to a trade leg. </para>
        ///</summary>
        public const ushort LegExecID = 1893;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The TradeID value corresponding to a trade leg </para>
        ///</summary>
        public const ushort LegTradeID = 1894;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Identifies an order or trade that should not be matched to an opposite order or trade if both buy and sell orders for the same asset contain the same SelfMatchPreventionID (2362) and submitted by the same firm </para>
        ///</summary>
        public const ushort SelfMatchPreventionID = 2362;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Use OrderRequestID to identify a request to enter, modify or delete an order and echo the value on the ExecutionReport representing the response </para>
        ///</summary>
        public const ushort OrderRequestID = 2422;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Number of regulatory publication rules in repeating group. Should always be "1" if being used otherwise set to 0 </para>
        ///</summary>
        public const ushort NoTrdRegPublications = 2668;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Specifies the type of regulatory trade publication. Additional reasons for the publication type will be specified in TrdRegPublicationReason (2670). 2=Exempt from Publication. There are allowable exemptions for the post-trade publication of trade transactions </para>
        ///</summary>
        public const ushort TrdRegPublicationType = 2669;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Additional reason for trade publication type specified in TrdRegPublicationType (2669). Reasons may be specific to regulatory trade publication rules. 12=Exempted due to European System of Central Banks (ESCB) policy transaction </para>
        ///</summary>
        public const ushort TrdRegPublicationReason = 2670;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Long name of the instrument for TM Repo </para>
        ///</summary>
        public const ushort FinancialInstrumentFullName = 2714;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Represents the sender comp which initiated the cancellation of orders or quotes for the original sender comp </para>
        ///</summary>
        public const ushort CancelText = 2807;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> If present ? specifies the scope of the OrderMassStatusRequest within the context of MassStatusRequestType (585) and Session and Firm for working orders only. Status will be returned for all orders matching the criteria specified here for Session and Firm combination </para>
        ///</summary>
        public const ushort OrdStatusReqType = 5000;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> This general purpose text field could be mapped from iLink to Clearing STP for trades. Not available for use with the short format where PartyDetailsListRequestID not equal to FFFFFFFF. Available for use only with the long format where PartyDetailsListRequestID=FFFFFFFF </para>
        ///</summary>
        public const ushort Memo = 5149;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Reserved for future use </para>
        ///</summary>
        public const ushort Reserved = 5187;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Reserved for future use </para>
        ///</summary>
        public const ushort Reserved1 = 5239;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Will be populated with a short code for the person or algo identified in FIX tag 5392 which will be mapped to National ID or Algo at reporting time. Applicable for EU fixed income markets only </para>
        ///</summary>
        public const ushort Executor = 5290;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Time when the message is sent. 64-bit integer expressing the number of nano seconds since midnight January 1, 1970. </para>
        ///</summary>
        public const ushort SendingTimeEpoch = 5297;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Operator ID. Should be unique per Firm ID. Assigned value used to identify specific message originator. Represents last individual or team in charge of the system which modifies the order before submission to the Globex platform, or if not modified from initiator (party role=118), last individual or team in charge of the system, which submit the order to the Globex platform </para>
        ///</summary>
        public const ushort SenderID = 5392;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates the type of short sale. Will not be used for Buy orders but Sell orders should have this tag populated for MiFID </para>
        ///</summary>
        public const ushort ShortSaleType = 5409;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Amount traded (in notional) in base currency for the Spot with this counterparty </para>
        ///</summary>
        public const ushort ContraGrossTradeAmt = 5542;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Represents the source repo instrument on which the new tailor made repo should be modeled on </para>
        ///</summary>
        public const ushort SourceRepoID = 5677;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Not being currently used </para>
        ///</summary>
        public const ushort DelayDuration = 5904;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Identifies whether the order should be treated as passive (will not match when entered) or aggressive (could match when entered); default behavior when absent is aggressive </para>
        ///</summary>
        public const ushort ExecutionMode = 5906;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Amount traded (in notional) in counter currency for the Spot with this counterparty </para>
        ///</summary>
        public const ushort ContraCalculatedCcyLastQty = 5971;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Information carried on a response to convey the time (UTC) when the request was received by the MSGW application. UTC timestamps are sent in number of nanoseconds since the UNIX epoch with microsecond precision </para>
        ///</summary>
        public const ushort RequestTime = 5979;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> If present ? specifies the scope of the OrderMassActionRequest within the context of Session and Firm. If absent then all orders belonging to Session and Firm combination will be cancelled for specified MassActionScope    </para>
        ///</summary>
        public const ushort MassCancelRequestType = 6115;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> The price assigned to an eFIX matched trade which is determined by an automated set market mid-price from a third party market data feed. The Fixing Price will be distributed as soon as practicable after the Fixing Time </para>
        ///</summary>
        public const ushort BenchmarkPrice = 6262;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Defines how user defined tailor made repo contract is to be broken down into different broken dates </para>
        ///</summary>
        public const ushort BrokenDateTermType = 6651;

        ///<summary>
        ///<para> Datatype: LocalMktDate</para>
        ///<para> End date of a financing deal, i.e. the date the seller reimburses the buyer and takes back control of the collateral. </para>
        ///</summary>
        public const ushort BrokenDateEnd = 6741;

        ///<summary>
        ///<para> Datatype: LocalMktDate</para>
        ///<para> Start date of a financing deal, i.e. the date the buyer pays the seller cash and takes control of the collateral </para>
        ///</summary>
        public const ushort BrokenDateStart = 6748;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Boolean: flags a managed order </para>
        ///</summary>
        public const ushort ManagedOrder = 6881;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Specifies the owner of the work up private phase </para>
        ///</summary>
        public const ushort Ownership = 7191;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates the amount of time that a message was delayed as a result of being split (9553=0) or as a result of being out of order due to TCP retransmission (9553=1) or as a result of being queued behind a split message (9553=2). Represented as number of nanoseconds in unix epoch format (since Jan 1, 1970). Subtracting this number from FIFO time will represent original received time of delayed message </para>
        ///</summary>
        public const ushort DelayToTime = 7552;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Used to act upon the outcome when a self-match is detected and an order is prevented from trading against another order with the same SelfMatchPreventionID (Tag 2362). 1=Cancel newest signifies that incoming order is cancelled. 2=Cancel Oldest signifies that the resting order is cancelled. Absence of this field (with Tag 2362) is interpreted as cancel oldest </para>
        ///</summary>
        public const ushort SelfMatchPreventionInstruction = 8000;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> A boolean value indicating if new quotes should be rejected for the sender comp for whom quotes are being cancelled on behalf; also to be used to reset such a block on mass quotes being sent by the blocked sender comp   </para>
        ///</summary>
        public const ushort QuoteEntryOpen = 9182;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> The price at which opposite side orders are listed on the market. Sent only in fill messages for reservation price orders </para>
        ///</summary>
        public const ushort DisplayLimitPrice = 9264;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Field added to capture if an order was submitted for market making obligation or not. Applicable only for EU BrokerTec and EBS MiFID regulated instruments </para>
        ///</summary>
        public const ushort LiquidityFlag = 9373;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Text describing sender's location (i.e. geopraphic location and/or desk) </para>
        ///</summary>
        public const ushort Location = 9537;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates whether a message was delayed as a result of being split among multiple packets (0) or if a message was delayed as a result of TCP re-transmission (1) or if a complete message was delayed due to a previously submitted split or out of order message (2). If absent then the message was not delayed and was neither split nor received out of order </para>
        ///</summary>
        public const ushort SplitMsg = 9553;

        ///<summary>
        ///<para> Datatype: Price</para>
        ///<para> This field specifies the highest (for a buy) or lowest (for a sell) price at which the order may trade. This price must be better than the limit price and should be multiple of reservation price tick </para>
        ///</summary>
        public const ushort ReservationPrice = 9562;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Unique identifier of the fill which is being corrected </para>
        ///</summary>
        public const ushort OrigSecondaryExecutionID = 9703;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Indicates if the order is a give-up or SGX offset. Reject if greater than max length or not containing valid value.  </para>
        ///</summary>
        public const ushort CmtaGiveupCD = 9708;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Sequence number as assigned to message </para>
        ///</summary>
        public const ushort SeqNum = 9726;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Flags message as possible retransmission. This will convey whether a message is an original transmission or duplicate in response to RetransmissionRequest. This will become pertinent when original messages get interleaved with Retransmission responses </para>
        ///</summary>
        public const ushort PossRetransFlag = 9765;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Flag indicating whether the order quantity stipulated on replace request should be entered into the market as stated without reduction for any fills that have occurred. Also once enabled in the order chain it cannot be disabled </para>
        ///</summary>
        public const ushort OFMOverride = 9768;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> CME Globex generated QuoteID  </para>
        ///</summary>
        public const ushort ExchangeQuoteReqID = 9770;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Number of quotes that have been accepted from the corresponding inbound message </para>
        ///</summary>
        public const ushort NoProcessedEntries = 9772;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> When market maker protection is triggered CME will not accept any new quotes from the market maker for that product group until it receives a mass quote message with the MMProtectionReset flag set to true </para>
        ///</summary>
        public const ushort MMProtectionReset = 9773;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Instrument Group cancelled for a Quote Cancel acknowledgement. </para>
        ///</summary>
        public const ushort CancelledSymbol = 9774;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Type of quote cancel generated by CME -- returned only for unsolicited quote cancels </para>
        ///</summary>
        public const ushort UnsolicitedCancelType = 9775;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Boolean flag (0/1) to automatically send a quote request message following the security definition (35=d) message. </para>
        ///</summary>
        public const ushort AutoQuoteRequest = 9776;

        ///<summary>
        ///<para> Datatype: char</para>
        ///<para> Identifies user-defined instruments. Constant value </para>
        ///</summary>
        public const ushort UserDefinedInstrument = 9779;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Represents the original sender comp for whom orders or quotes are to be cancelled </para>
        ///</summary>
        public const ushort OrigOrderUser = 9937;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Represents the Investment Decision Maker Short Code. Applicable for EU fixed income markets only </para>
        ///</summary>
        public const ushort IDMShortCode = 36023;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Market Data Trade Entry ID. This identifier is assigned to all trades that take place for an instrument at a particular price level </para>
        ///</summary>
        public const ushort MDTradeEntryID = 37711;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Max number of substitutions allowed. The value of 0 indicates that substitutions are not allowed. </para>
        ///</summary>
        public const ushort MaxNoOfSubstitutions = 37715;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Constant value representing type of flow from customer to CME </para>
        ///</summary>
        public const ushort CustomerFlow = 39000;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Session Identifier defined as type long (uInt64); recommended to use timestamp as number of microseconds since epoch (Jan 1, 1970) </para>
        ///</summary>
        public const ushort UUID = 39001;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Time of request; recommended to use timestamp as number of nanoseconds since epoch (Jan 1, 1970) </para>
        ///</summary>
        public const ushort RequestTimestamp = 39002;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Constant value representing CME HMAC version </para>
        ///</summary>
        public const ushort HMACVersion = 39003;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Contains the AccessKeyID assigned to this session on this port. </para>
        ///</summary>
        public const ushort AccessKeyID = 39004;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Contains the HMAC signature. </para>
        ///</summary>
        public const ushort HMACSignature = 39005;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Session ID </para>
        ///</summary>
        public const ushort Session = 39006;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Firm ID </para>
        ///</summary>
        public const ushort Firm = 39007;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Constant value representing type of flow from CME to customer </para>
        ///</summary>
        public const ushort ServerFlow = 39009;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Indicates whether the connection is primary or backup </para>
        ///</summary>
        public const ushort FaultToleranceIndicator = 39010;

        ///<summary>
        ///<para> Datatype: String</para>
        ///<para> Reject reason details </para>
        ///</summary>
        public const ushort Reason = 39011;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Error code for reject reason </para>
        ///</summary>
        public const ushort ErrorCodes = 39012;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Next expected message sequence number </para>
        ///</summary>
        public const ushort NextSeqNo = 39013;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> The longest time in milliseconds the customer or CME could remain silent before sending a keep alive message </para>
        ///</summary>
        public const ushort KeepAliveInterval = 39014;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Refers to the UUID sent in the previous message before this one from CME </para>
        ///</summary>
        public const ushort PreviousUUID = 39015;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> This indicates if the Sequence message being sent by CME is to warn that one keep alive interval has lapsed without any message received from customer (this can also be sent from customer to CME) </para>
        ///</summary>
        public const ushort KeepAliveIntervalLapsed = 39016;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> If RetransmitRequest is for a previous UUID then put that here otherwise put default null value </para>
        ///</summary>
        public const ushort LastUUID = 39017;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Sequence number of the first business message requested. This should not be greater than the latest sequence number from CME </para>
        ///</summary>
        public const ushort FromSeqNo = 39018;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Count of business messages requested </para>
        ///</summary>
        public const ushort MsgCount = 39019;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> Refers to the SeqNum sent in the previous message before this one from CME </para>
        ///</summary>
        public const ushort PreviousSeqNo = 39021;

        ///<summary>
        ///<para> Datatype: int</para>
        ///<para> This indicates in how many days the HMAC secret key will expire </para>
        ///</summary>
        public const ushort SecretKeySecureIDExpiration = 39022;

        ///<summary>
        ///<para> Datatype: groupSize</para>
        ///<para> Used to indicate the number of custom bespoke broken dates for user defined tailor made repo </para>
        ///</summary>
        public const ushort NoBrokenDates = 39026;

        }
    }
}

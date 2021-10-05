using System;
namespace trade_netter
{
    /**
     * This model is used as a message to be passed to the algorithm, 
     * It is a data structure containing the intent, the type and the quantity
     */
    public class Trade
    {
        public readonly TradeDirection direction;
        public readonly int quantity;
        public readonly Fuel underlying;

        public Trade(
            TradeDirection direction,
            int quantity,
            Fuel underlying)
        {
            this.direction = direction;
            this.quantity = quantity;
            this.underlying = underlying;
        }
    }
}

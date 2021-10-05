using System;
namespace trade_netter
{
    /**
     * The model used by the algoithm to calculate PNL
     */
    public class TradeModel
    {
        private readonly TradeDirection direction;
        private readonly int quantity;
        private readonly int price;
        private readonly Fuel underlying;

        public TradeModel(
            TradeDirection direction,
            int quantity,
            int price,
            Fuel underlying)
        {
            this.direction = direction;
            this.quantity = quantity;
            this.price = price;
            this.underlying = underlying; 
        }

        public int CalculatePNL(int price) {
            // Some math
            return 0;
        }
    }
}

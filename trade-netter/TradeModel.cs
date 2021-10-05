using System;
namespace trade_netter
{
    /**
     * The model used by the algoithm to calculate PNL
     */
    public class TradeModel
    {
        public readonly TradeDirection direction;
        public readonly int quantity;
        public readonly int price;
        public readonly Fuel underlying;

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

        public static void PrintRowHeadingsToStdOut() {
            Console.WriteLine($"| Dir | Quan | Price | Fuel |");
        }

        public void PrintDetailsToStdOut()
        {
            Console.WriteLine($"| {direction} | {quantity} | {price} | {underlying} |");
        }

        public bool isSale => this.direction == TradeDirection.Sell;
    }
}

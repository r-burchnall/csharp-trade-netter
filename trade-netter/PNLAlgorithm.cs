using System;
using System.Collections.Generic;
using System.Linq;

namespace trade_netter
{
    public class OverSaleException: Exception
    {

    }

    public class PNLAlgorithm
    {
        private static Dictionary<Fuel, int> underlyingPrices = new Dictionary<Fuel, int>();

        public PNLAlgorithm()
        {
            //Initialise all fuels at a known price.
            foreach(Fuel fuel in Enum.GetValues(typeof(Fuel)))
            {
                PNLAlgorithm.underlyingPrices[fuel] = 100;
            }
        }

        public TradeModel CreateTrade(TradeDirection direction, int quantity, Fuel fuel)
        {
            int price = underlyingPrices[fuel];
            if(direction == TradeDirection.Buy)
            {
                underlyingPrices[fuel] += 2 * quantity;
            } else
            {
                underlyingPrices[fuel] -= 2 * quantity;
            }
            return new TradeModel(direction, quantity, price, fuel);
        }

        public int CalculatePNLFromTrades(List<TradeModel> trades)
        {
            // Generate a list of boughts at prices, queue FIFO
            List<TradeModel> sales = trades.Where(trade => trade.isSale).ToList();
            List<int> purchases = trades.Where(trade => !trade.isSale)
                .SelectMany(i => {
                    List<int> prices = new List<int>();
                    for (int j = 0; j < i.quantity; j++)
                    {
                        prices.Add(i.price);
                    }
                    return prices;
                }).ToList();

            // Sell from first of the list
            int pnl = 0;
            try
            {

                foreach (var trade in sales)
                {
                    for (int i = 0; i < trade.quantity; i++)
                    {
                        if (purchases.Count() == 0)
                        {
                            throw new OverSaleException();
                        }
                        var purchase = purchases.First();
                        purchases.RemoveAt(0);
                        pnl += trade.price - purchase;
                    }

                }
            }
            catch (OverSaleException e)
            {
                Console.Error.WriteLine("Cannot sell more than has been purchased.");
            }

            // Any unsold are not totaled as they do not qualify for PNL (still trading)
            return pnl;
        }
    }
}

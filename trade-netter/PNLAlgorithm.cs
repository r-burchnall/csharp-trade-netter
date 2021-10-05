using System;
using System.Collections.Generic;
using System.Linq;

namespace trade_netter
{
    public class PNLAlgorithm
    {
        public int CalculatePNLFromTrades(List<TradeModel> trades)
        {
            List<TradeModel> sales = trades.Where(trade => trade.isSale).ToList();

            // Flattening purchase trades into list where we can remove instances when sold.
            List<(int, Fuel)> purchases = trades
                .Where(trade => !trade.isSale)
                .SelectMany(i => i.explodedList)
                .ToList();

            int pnl = 0;

            foreach (var trade in sales)
            {
                for (int i = 0; i < trade.quantity; i++)
                {
                    var purchaseIndex = purchases.FindIndex(i => i.Item2 == trade.underlying);

                    if (purchaseIndex > -1)
                    {
                        pnl += trade.price - purchases[purchaseIndex].Item1;
                        purchases.RemoveAt(purchaseIndex);
                    }
                }
            }

            return pnl;
        }
    }
}

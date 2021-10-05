using System;
using System.Collections.Generic;

namespace trade_netter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Program p = new Program();
            p.Example1();
        }

        public int Example1()
        {
            PNLAlgorithm algo = new PNLAlgorithm();

            List<TradeModel> trades = new List<TradeModel>() {
                algo.CreateTrade(TradeDirection.Buy, 1, Fuel.Oil),
                algo.CreateTrade(TradeDirection.Sell, 4, Fuel.Oil),
                algo.CreateTrade(TradeDirection.Buy, 4, Fuel.Oil)
            };

            return algo.CalculatePNLFromTrades(trades);
        }
    }
}
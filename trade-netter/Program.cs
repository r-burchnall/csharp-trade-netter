using System;
using System.Collections.Generic;

namespace trade_netter
{
    class Program
    {
        List<List<TradeModel>> examples = new List<List<TradeModel>>() {
            new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 2, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Buy, 2, 110, Fuel.Oil),
                new TradeModel(TradeDirection.Buy, 3, 102, Fuel.Oil)
            },

            new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 2, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Sell, 2, 110, Fuel.Oil)
            },

            new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 1, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Sell, 4, 110, Fuel.Oil),
            },

            new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 1, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Sell, 4, 110, Fuel.Oil),
                new TradeModel(TradeDirection.Buy, 4, 120, Fuel.Oil)
            },

            new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 1, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Sell, 4, 110, Fuel.Gas),
                new TradeModel(TradeDirection.Buy, 2, 120, Fuel.Gas),
                new TradeModel(TradeDirection.Sell, 5, 115, Fuel.Oil)
            }
        };

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunExamples();
        }

        public void RunExamples()
        {
            PNLAlgorithm algo = new PNLAlgorithm();

            for (int i = 0; i < examples.Count; i++)
            {
                var trades = examples[i];
                TradeModel.PrintRowHeadingsToStdOut();
                foreach (var trade in trades)
                {
                    trade.PrintDetailsToStdOut();
                }

                Console.WriteLine($"\nCalculated profit/loss for Example {i}: {algo.CalculatePNLFromTrades(trades)}\n\n");
            }
        }
    }
}
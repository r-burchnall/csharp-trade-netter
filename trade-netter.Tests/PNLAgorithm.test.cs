using System.Collections.Generic;
using NUnit.Framework;

namespace trade_netter.Tests
{
    public class PNLAlgorithmTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] // Could use test-cases here, however creating a new list of trades in an attibute is ugly.
        public void ShouldCalculatePNLFromExample1()
        {
            PNLAlgorithm algo = new PNLAlgorithm();

            List<TradeModel> trades = new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 2, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Buy, 2, 110, Fuel.Oil),
                new TradeModel(TradeDirection.Buy, 3, 102, Fuel.Oil)
            };

            int pnl = algo.CalculatePNLFromTrades(trades);

            Assert.AreEqual(0, pnl);
        }

        [Test] 
        public void ShouldCalculatePNLFromExample2()
        {
            PNLAlgorithm algo = new PNLAlgorithm();

            List<TradeModel> trades = new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 2, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Sell, 2, 110, Fuel.Oil)
            };

            int pnl = algo.CalculatePNLFromTrades(trades);

            Assert.AreEqual(20, pnl);
        }

        [Test] 
        public void ShouldCalculatePNLFromExample3()
        {
            PNLAlgorithm algo = new PNLAlgorithm();

            List<TradeModel> trades = new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 1, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Sell, 4, 110, Fuel.Oil),
            };

            //TradeModel.PrintRowHeadingsToStdOut();
            //foreach (var trade in trades)
            //{
            //    trade.PrintDetailsToStdOut();
            //}

            int pnl = algo.CalculatePNLFromTrades(trades);

            Assert.AreEqual(10, pnl);
        }

        [Test]
        public void ShouldCalculatePNLFromExample4()
        {
            PNLAlgorithm algo = new PNLAlgorithm();

            List<TradeModel> trades = new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 1, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Sell, 4, 110, Fuel.Oil),
                new TradeModel(TradeDirection.Buy, 4, 120, Fuel.Oil)
            };

            TradeModel.PrintRowHeadingsToStdOut();
            foreach (var trade in trades)
            {
                trade.PrintDetailsToStdOut();
            }

            int pnl = algo.CalculatePNLFromTrades(trades);

            Assert.AreEqual(-20, pnl);
        }

        [Test]
        public void ShouldCalculatePNLFromExample5()
        {
            PNLAlgorithm algo = new PNLAlgorithm();

            List<TradeModel> trades = new List<TradeModel>() {
                new TradeModel(TradeDirection.Buy, 1, 100, Fuel.Oil),
                new TradeModel(TradeDirection.Sell, 4, 110, Fuel.Gas),
                new TradeModel(TradeDirection.Buy, 2, 120, Fuel.Gas),
                new TradeModel(TradeDirection.Sell, 5, 115, Fuel.Oil)
            };

            int pnl = algo.CalculatePNLFromTrades(trades);

            Assert.AreEqual(-5, pnl);
        }
    }
}

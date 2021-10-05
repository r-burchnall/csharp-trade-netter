using System;
using System.Collections.Generic;

namespace trade_netter
{
    public class PNLAlgorithm
    {
        private static Dictionary<Fuel, int> underlyingPrices;

        public PNLAlgorithm()
        {
            //Initialise all fuels at a known price.
            foreach(Fuel fuel in Enum.GetValues(typeof(Fuel)))
            {
                underlyingPrices[fuel] = 100;
            }
        }
    }
}

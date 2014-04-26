using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator.PCL
{
    public class Calculator
    {
        private Calculator() { }

        private static Calculator _Instance;
        public static Calculator Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Calculator();
                return _Instance;
            }
        }

        public TipTotals CalculateTip(string totalAmount, int tip, int totalPeople)
        {
            // calculate the values
            var tipTotals = new TipTotals();
            var total = 0d;
            if (double.TryParse(totalAmount, out total))
            {
                tipTotals.TotalCost = total;
                tipTotals.TipAmount = total * (tip / 100d);
                tipTotals.TotalCost += tipTotals.TipAmount;
				tipTotals.TotalPerPerson = tipTotals.TotalCost / totalPeople;
            }

            return tipTotals;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator.PCL
{
    public abstract class MyLocationBase
    {
        public abstract Task<Location> GetLocation();

        public void Test()
        {
            var t = "test";
        }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
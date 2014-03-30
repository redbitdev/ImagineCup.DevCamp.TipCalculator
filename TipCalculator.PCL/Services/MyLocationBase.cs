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
    }

}
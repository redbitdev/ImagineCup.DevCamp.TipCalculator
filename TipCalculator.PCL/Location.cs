using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator.PCL
{
    public class LocationManager
    {
        private LocationManager() { }

        private static LocationManager _Instance;
        public static LocationManager Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new LocationManager();
                return _Instance;
            }
        }


        public MyLocationBase LocationInstance { get; set; }
    }
}

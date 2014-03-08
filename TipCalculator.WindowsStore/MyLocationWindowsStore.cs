using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.PCL;
using Windows.Devices.Geolocation;

namespace TipCalculator.WindowsStore
{
    public class MyLocationWindowsStore : MyLocationBase
    {
        public async override Task<Location> GetLocation()
        {
            var ret = new Location();

            // create the locator
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                // THIS IS THE ONLY DIFFERENCE
                ret.Latitude = geoposition.Coordinate.Point.Position.Latitude;
                ret.Longitude = geoposition.Coordinate.Point.Position.Longitude;
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                }
                else
                {
                    // something else happened acquring the location
                }
            }

            // return the location
            return ret;
        }
    }
}
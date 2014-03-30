using MonoTouch.CoreLocation;
using MonoTouch.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.PCL;

namespace TipCalculator.iPhone
{
    public class MyLocationiOS : MyLocationBase
    {
        CLLocationManager manager = new CLLocationManager();

        public override Task<Location> GetLocation()
        {
            manager.StartUpdatingLocation();

            return Task.Factory.StartNew<Location>(() =>
            {
                var ret = new Location();
                var locationFound = false;
                // create the locator
                manager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                {
                    if (e.Locations.Length > 0)
                    {
                        ret = new Location()
                        {
                            Latitude = e.Locations[0].Coordinate.Latitude,
                            Longitude = e.Locations[0].Coordinate.Longitude
                        };
                    }

                    locationFound = true;
                };
                manager.Failed += (object sender, NSErrorEventArgs e) =>
                {
                    locationFound = true;
                };                

                // wait till done
                while (!locationFound)
                    Task.Delay(200);

                // stop udpating the location
                manager.StopUpdatingLocation();

                // return the location
                return ret;
            });
           
        }


    }
}

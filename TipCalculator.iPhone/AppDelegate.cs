using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TipCalculator.PCL;

namespace TipCalculator.iPhone
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
		TipCalculatorViewController viewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			// create the location plugin
			LocationManager.Instance.LocationInstance = new MyLocationiOS();

			// create the main view
            window = new UIWindow(UIScreen.MainScreen.Bounds);

			viewController = new TipCalculatorViewController();
            window.RootViewController = viewController;

            window.MakeKeyAndVisible();

            return true;
        }
    }
}


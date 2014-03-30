using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TipCalculator.PCL;

namespace TipCalculator.iPhone
{
	public partial class TipCalculatorViewController : UIViewController
	{
		public TipCalculatorViewController () : base ("TipCalculatorViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            // Init the location manager
            LocationManager.Instance.LocationInstance = new MyLocationiOS();

			// Perform any additional setup after loading the view, typically from a nib.
			InitializeInternal ();

            // Add a tap to get rid of keyboard
            this.View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                this.View.EndEditing(true);
            }));
		}


	}
}


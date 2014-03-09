using System;
using MonoTouch.UIKit;
using System.Drawing;
using TipCalculator.PCL;

namespace TipCalculator.iPhone
{
    public class MyViewController : UIViewController
    {
        UIButton button;
        int numClicks = 0;
        float buttonWidth = 200;
        float buttonHeight = 50;

        public MyViewController()
        {
            LocationManager.Instance.LocationInstance = new MyLocationiOS();
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            button = UIButton.FromType(UIButtonType.RoundedRect);

            button.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2,
                View.Frame.Height / 2 - buttonHeight / 2,
                buttonWidth,
                buttonHeight);

            button.SetTitle("Click me", UIControlState.Normal);

            button.TouchUpInside += (object sender, EventArgs e) =>
            {
                button.SetTitle(String.Format("clicked {0} times", numClicks++), UIControlState.Normal);
            };

            button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(button);

            var lblLoc = new UILabel(new RectangleF(0, button.Frame.Bottom, UIScreen.MainScreen.ApplicationFrame.Width, 50));
            View.AddSubview(lblLoc);
            var lbltip = new UILabel(new RectangleF(0, lblLoc.Frame.Bottom, UIScreen.MainScreen.ApplicationFrame.Width, 50));
            View.AddSubview(lbltip);

            var loc = await LocationManager.Instance.LocationInstance.GetLocation();
            lblLoc.Text = string.Format("{0}, {1}", loc.Latitude, loc.Longitude);
            var tip = Calculator.Instance.CalculateTip("100", 15, 2);
            lbltip.Text = string.Format("{0:C}, {1:C}, {2:C}", tip.TipAmount, tip.TotalCost, tip.TotalPerPerson);
        }

    }
}


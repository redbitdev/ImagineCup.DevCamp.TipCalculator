using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TipCalculator.PCL;

#if WINDOWS_PHONE
namespace TipCalculator
#elif NETFX_CORE
namespace TipCalculator.WindowsStore
#elif __ANDROID__
namespace TipCalculator.Android
#else
namespace TipCalculator.iPhone
#endif
{
#if WINDOWS_PHONE || NETFX_CORE
    public partial class MainPage
#elif __IOS__
    public partial class TipCalculatorViewController
#else
    public partial class Activity1
#endif
    {

        private async void InitializeInternal()
        {
            // set the default value for total
            this.txtAmount.Text = "";

            // clear out the totals
            this.lblTotalCost.Text = "";
            this.lblTipAmount.Text = "";
            this.lblTotalPerPerson.Text = "";

            // wire up some changes
#if __ANDROID__
            this.scrollPeople.ProgressChanged += (s, e) => { Calculate(); };
            this.scrollTip.ProgressChanged += (s, e) => { Calculate(); };
#else
             this.scrollPeople.ValueChanged += (s, e) => { Calculate(); };
            this.scrollTip.ValueChanged += (s, e) => { Calculate(); };
#endif
#if WINDOWS_PHONE || NETFX_CORE || __ANDROID__
            this.txtAmount.TextChanged += (s, e) => { Calculate(); };
#else
            MonoTouch.Foundation.NSNotificationCenter.DefaultCenter.AddObserver
            (MonoTouch.UIKit.UITextField.TextFieldTextDidChangeNotification, (notification) =>
                {
                    Calculate();
                });
#endif

            // grab current location
            if (LocationManager.Instance.LocationInstance != null)
            {
                var loc = await LocationManager.Instance.LocationInstance.GetLocation();
            }
        }

        private void Calculate()
        {
#if __ANDROID__
            var totals = Calculator.Instance.CalculateTip(this.txtAmount.Text, (int)this.scrollTip.Progress, (int)this.scrollPeople.Progress);
#else
            var totals = Calculator.Instance.CalculateTip(this.txtAmount.Text, (int)this.scrollTip.Value, (int)this.scrollPeople.Value);
#endif
            // set the labels
            this.lblTipAmount.Text = string.Format("Total Tip Amount: {0:C}", totals.TipAmount);
            this.lblTotalCost.Text = string.Format("Total Amount: {0:C}", totals.TotalCost);
            this.lblTotalPerPerson.Text = string.Format("Total Per Person: {0:C}", totals.TotalPerPerson, 2);

#if __ANDROID__
            this.lblNumPeople.Text = string.Format("Total People ({0})", (int)this.scrollPeople.Progress);
            this.lblTipPercent.Text = string.Format("Tip Percentage {0}%", Math.Round((decimal)this.scrollTip.Progress));
#else
            this.lblNumPeople.Text = string.Format("Total People ({0})", (int)this.scrollPeople.Value);
            this.lblTipPercent.Text = string.Format("Tip Percentage {0}%", Math.Round(this.scrollTip.Value));
#endif
        }


    }
}



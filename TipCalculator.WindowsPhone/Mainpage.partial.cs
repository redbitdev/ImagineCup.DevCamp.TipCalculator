using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TipCalculator.PCL;

#if WINDOWS_PHONE
namespace TipCalculator
#else
namespace TipCalculator.WindowsStore
#endif
{
    public partial class MainPage 
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
            this.scrollPeople.ValueChanged += (s, e) => { Calculate(); };
            this.scrollTip.ValueChanged += (s, e) => { Calculate(); };
            this.txtAmount.TextChanged += (s, e) => { Calculate(); };

            // grab current location
            var loc = await LocationManager.Instance.LocationInstance.GetLocation();
        }

        private void Calculate()
        {
            var totals = Calculator.Instance.CalculateTip(this.txtAmount.Text, (int)this.scrollTip.Value, (int)this.scrollPeople.Value);

            // set the labels
            this.lblTipAmount.Text = string.Format("Total Tip Amount: {0:C}", totals.TipAmount);
            this.lblTotalCost.Text = string.Format("Total Amount: {0:C}", totals.TotalCost);
            this.lblTotalPerPerson.Text = string.Format("Total Per Person: {0:C}", totals.TotalPerPerson, 2);
            this.lblNumPeople.Text = string.Format("Total People ({0})", (int)this.scrollPeople.Value);
            this.lblTipPercent.Text = string.Format("Tip Percentage {0}%", Math.Round(this.scrollTip.Value));

        }


    }
}

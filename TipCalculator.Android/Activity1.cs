using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TipCalculator.PCL;

namespace TipCalculator.Android
{
    [Activity(Label = "TipCalculator.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public partial class Activity1 : Activity
    {
        internal EditText txtAmount;
        internal TextView lblTotalCost;
        internal TextView lblTipAmount;
        internal TextView lblTotalPerPerson;
        internal TextView lblTipPercent;
        internal TextView lblNumPeople;
        internal SeekBar scrollTip;
        internal SeekBar scrollPeople;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Create the user interface in code
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            layout.SetPadding(50, 25, 50, 25);

            var aLabel = new TextView(this);
            aLabel.Text = "Total Amount";

            txtAmount = new EditText(this);
            txtAmount.InputType = global::Android.Text.InputTypes.ClassNumber;
            

            scrollPeople = new SeekBar(this);
            scrollPeople.Max = 20;
			scrollPeople.Progress = 1;

            scrollTip = new SeekBar(this);
			scrollTip.Progress = 15;
            scrollTip.Max = 100;

            lblTotalCost = new TextView(this);
            lblTipAmount = new TextView(this);
            lblTotalPerPerson = new TextView(this);
            lblTipPercent = new TextView(this);
            lblNumPeople = new TextView(this);

            layout.AddView(aLabel);
            layout.AddView(txtAmount);
            layout.AddView(lblTipPercent);
            layout.AddView(scrollTip);
            layout.AddView(lblNumPeople);
            layout.AddView(scrollPeople);
            layout.AddView(lblTipAmount);
            layout.AddView(lblTotalCost);
            layout.AddView(lblTotalPerPerson);
            
            
            
            // Set our view from the "main" layout resource
            


            SetContentView(layout);

            InitializeInternal();
        }

    
    }
}


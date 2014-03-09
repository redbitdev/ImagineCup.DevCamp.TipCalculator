// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace TipCalculator.iPhone
{
	[Register ("TipCalculatorViewController")]
	partial class TipCalculatorViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblNumPeople { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblTipAmount { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblTipPercent { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblTotalCost { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblTotalPerPerson { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider scrollPeople { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider scrollTip { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtAmount { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblNumPeople != null) {
				lblNumPeople.Dispose ();
				lblNumPeople = null;
			}

			if (lblTipAmount != null) {
				lblTipAmount.Dispose ();
				lblTipAmount = null;
			}

			if (lblTipPercent != null) {
				lblTipPercent.Dispose ();
				lblTipPercent = null;
			}

			if (lblTotalCost != null) {
				lblTotalCost.Dispose ();
				lblTotalCost = null;
			}

			if (lblTotalPerPerson != null) {
				lblTotalPerPerson.Dispose ();
				lblTotalPerPerson = null;
			}

			if (scrollPeople != null) {
				scrollPeople.Dispose ();
				scrollPeople = null;
			}

			if (scrollTip != null) {
				scrollTip.Dispose ();
				scrollTip = null;
			}

			if (txtAmount != null) {
				txtAmount.Dispose ();
				txtAmount = null;
			}
		}
	}
}

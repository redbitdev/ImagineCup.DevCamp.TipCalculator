using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TipCalculator.Resources;
using TipCalculator.PCL;

namespace TipCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            LocationManager.Instance.LocationInstance = new MyLocationWindowsPhone();
            InitializeInternal();
        }


    }
}
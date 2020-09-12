using AirMonitor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AirMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private HomeViewModel _viewModel => BindingContext as HomeViewModel;
        public MapPage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation);

           // Map.MoveToRegion(Map.Span.FromCenterAndRadius());
        }

        void Pin_InfoWindowClicked(System.Object sender, Xamarin.Forms.Maps.PinClickedEventArgs e)
        {
            if (sender is Pin pin)
                _viewModel?.MapPinTappedCommand.Execute(pin.Address);
        }
    }
}
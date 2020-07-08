using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AirMonitor.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AirMonitor.ViewModels
{
    public class HomeViewModel
    {
        private readonly INavigation _navigation;

        public HomeViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Initialize();
        }

        private async Task Initialize()
        {


            var location = await GetLocation();
        }

        private async Task<Location> GetLocation()
        {
            Location location = await Geolocation.GetLastKnownLocationAsync();
            return location;
        }

        private ICommand _goToDetailsCommand;
        public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command(OnGoToDetails));

        private void OnGoToDetails()
        {
            _navigation.PushAsync(new DetailsPage());
        }
    }
}

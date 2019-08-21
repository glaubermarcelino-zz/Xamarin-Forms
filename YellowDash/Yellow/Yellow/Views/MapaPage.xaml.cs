
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Yellow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaPage : ContentPage
    {
        public MapaPage()
        {
            InitializeComponent();
            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                              new Position(-23.4859591, -47.4420192),
                              Distance.FromMiles(0.5)));


            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-23.4859591, -47.4420192),
                Label = "Mapa",
                Address = "http://www.gtsti.com.br",
            };

            Mapa.Pins.Add(pin);
        }

        private void ImageButton_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MenuPage2());
        }
    }
}
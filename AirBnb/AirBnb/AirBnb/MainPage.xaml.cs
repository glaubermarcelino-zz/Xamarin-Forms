using AirBnb.ViewModels;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace AirBnb
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel _mainviewModel;
        public MainPage()
        {
            InitializeComponent();
            _mainviewModel = new MainPageViewModel();
            BindingContext = _mainviewModel;
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //NavigationPage.SetHasBackButton(this, false);
            //lstSolicitacoes.BeginRefresh();
            //var texto = searchBar.Text;
            //lstSolicitacoes.ItemsSource = _mainviewModel.Solicitacao
            //                                .Where(x => x.Descricao.ToLower().Contains(texto.ToLower()));
            //lstSolicitacoes.EndRefresh();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            NavigationPage.SetHasBackButton(this, true);

        }

        private void FloatingButton_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}

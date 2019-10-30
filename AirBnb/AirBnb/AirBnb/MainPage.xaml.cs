using AirBnb.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AirBnb
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel _mainViewModel;
        public MainPage()
        {
            InitializeComponent();
            _mainViewModel = new MainPageViewModel();
            BindingContext = _mainViewModel;
            lstSolicitacoes.ItemsSource = _mainViewModel.Solicitacao;
        }
    }
}

using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomControlPages : ContentPage
	{
		public CustomControlPages ()
		{
			InitializeComponent ();
            BindingContext = new CustomViewModel();
		}
	}
}
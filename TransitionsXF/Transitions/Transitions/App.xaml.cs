using Plugin.SharedTransitions;
using Transitions.Services;
using Transitions.Views;
using Xamarin.Forms;

namespace Transitions
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
#if DEBUG
            HotReloader.Current.Run(this, new HotReloader.Configuration
            {
                DeviceUrlPort = 8002
            });
#endif
            MainPage = new SharedTransitionNavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

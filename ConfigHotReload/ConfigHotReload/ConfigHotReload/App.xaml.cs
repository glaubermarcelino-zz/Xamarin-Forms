using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConfigHotReload
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
#if DEBUG
            HotReloader.Current.Run(this, new HotReloader.Configuration
            {
                //Porta padrão para seu dispositivo
                DeviceUrlPort = 8002
            });
#endif
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Transitions.Models;
using Transitions.Views;
using Transitions.ViewModels;
using Plugin.SharedTransitions;

namespace Transitions.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void ItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tappedItemData = e.Item as Item;
            //this is required in order to pass the views to animate
            SharedTransitionNavigationPage.SetTransitionSelectedGroup(this, tappedItemData.Id);
            SharedTransitionNavigationPage.SetTransitionDuration(this, 200);
            SharedTransitionNavigationPage.SetBackgroundAnimation(this, BackgroundAnimation.Flip);
            await Navigation.PushAsync(new ItemDetailPage(tappedItemData));
        }
    }
}
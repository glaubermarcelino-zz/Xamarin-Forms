using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Transitions.Models;
using Transitions.ViewModels;

namespace Transitions.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage(Item tappedItemData)
        {
            InitializeComponent();

            var item = tappedItemData;

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}
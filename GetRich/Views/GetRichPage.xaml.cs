﻿using Xamarin.Forms;

namespace GetRich
{
    public partial class GetRichPage : ContentPage
    {
        private readonly GetRichViewModel _viewModel = new GetRichViewModel();

        public GetRichPage()
        {
            BindingContext = _viewModel;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.Load();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var picture = (Picture)e.Item;
            var page = new ArticlePage
            {
                BindingContext = picture,
            };
            await Navigation.PushAsync(page);
        }
    }
}

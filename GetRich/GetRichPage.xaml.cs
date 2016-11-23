using Xamarin.Forms;

namespace GetRich
{
    public partial class GetRichPage : ContentPage
    {
        private readonly GetRichViewModel _viewModel = new GetRichViewModel();

        public GetRichPage()
        {
            BindingContext = _viewModel;
            InitializeComponent();

            _viewModel.Load();
        }
    }
}

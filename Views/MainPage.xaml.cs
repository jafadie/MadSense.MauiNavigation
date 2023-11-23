using Prismanda.ViewModels;

namespace Prismanda.Views
{
    public partial class MainPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

using Prismanda.ViewModels;

namespace Prismanda.Views;

public partial class Page1
{
	public Page1(Page1ViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
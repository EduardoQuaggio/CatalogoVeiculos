using Catalogo_de_Carros.ViewModels;

namespace Catalogo_de_Carros.Views;

public partial class CatalogoPage : ContentPage
{
	public CatalogoViewModel viewModel;
	
	public CatalogoPage()
	{
        InitializeComponent();
		viewModel = this.BindingContext as CatalogoViewModel; 
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		
		await viewModel.LoadData();
	}
}
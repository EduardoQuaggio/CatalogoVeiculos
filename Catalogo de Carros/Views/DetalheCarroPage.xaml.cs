using Catalogo_de_Carros.Models;
using Catalogo_de_Carros.ViewModels;

namespace Catalogo_de_Carros.Views;

public partial class DetalheCarroPage : ContentPage
{
	private DetalheCarroViewModel viewModel;
	public DetalheCarroPage(Car car)
	{
		InitializeComponent();
		viewModel = new DetalheCarroViewModel(car);
		BindingContext = viewModel;
	}
}
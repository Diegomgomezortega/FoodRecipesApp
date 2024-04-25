using FoodRecipesApp.ViewModels;

namespace FoodRecipesApp.Views;

public partial class OriginPage : ContentPage
{
	private readonly OriginPageViewModel originPageViewModel;
	public OriginPage( OriginPageViewModel _originPageViewModel)
	{
		InitializeComponent();
		BindingContext= _originPageViewModel;
		originPageViewModel= _originPageViewModel;
	}
}
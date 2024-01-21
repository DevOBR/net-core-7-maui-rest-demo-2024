using net_core_7_maui_rest_demo_2024.MVVM.ViewModels;

namespace net_core_7_maui_rest_demo_2024.MVVM.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}

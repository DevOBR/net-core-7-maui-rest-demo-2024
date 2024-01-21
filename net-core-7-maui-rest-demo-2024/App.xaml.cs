using net_core_7_maui_rest_demo_2024.MVVM.Views;

namespace net_core_7_maui_rest_demo_2024;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainView());
	}
}


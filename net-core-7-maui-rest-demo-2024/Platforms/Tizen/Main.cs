using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace net_core_7_maui_rest_demo_2024;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}


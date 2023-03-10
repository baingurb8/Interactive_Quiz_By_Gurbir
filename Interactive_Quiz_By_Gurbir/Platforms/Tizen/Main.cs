using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Interactive_Quiz_By_Gurbir;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}


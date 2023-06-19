using MauiApp_IP.Resources.Views;

namespace MauiApp_IP;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainSpeedyIP), typeof(MainSpeedyIP));
        Routing.RegisterRoute(nameof(ContentSpeedyIP), typeof(ContentSpeedyIP));
    }
}

using MauiApp_IP.Resources.Model;
using System.Net.NetworkInformation;

namespace MauiApp_IP.Resources.Views;

public partial class ContentSpeedyIP : ContentPage
{
    Adaptador _adaptadorActivo;
    public ContentSpeedyIP()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var _networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        //_adaptadorActivo = Funciones.ObtenerInterfacesActivas(_networkInterfaces);

        _adaptadorActivo = Funciones.ObtenerInterfazActiva(_networkInterfaces);

        GridSuperior.BindingContext = _adaptadorActivo;

        //BindableLayout.SetItemsSource(GridSuperior, _adaptadorActivo);
    }

    private void BtnRegresar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
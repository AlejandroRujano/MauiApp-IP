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

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var _networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        //_adaptadorActivo = Funciones.ObtenerInterfacesActivas(_networkInterfaces);

        _adaptadorActivo = Funciones.ObtenerInterfazActiva(_networkInterfaces);

        GridSuperior.BindingContext = _adaptadorActivo;

        GridDesplegable.BindingContext = _adaptadorActivo;

        //ImgCheck.Opacity = 0;

        await ImgCheck.ScaleTo(1.25, 2500, Easing.Linear);
        //ImgCheck.FadeTo(1, 1000, Easing.Linear);
        await ImgCheck.ScaleTo(1, 1200, Easing.Linear);
        

        //BindableLayout.SetItemsSource(GridSuperior, _adaptadorActivo);
    }
    private void BtnRegresar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private async void BtnMostrasMas_Clicked(object sender, EventArgs e)
    {
        if (!GridDesplegable.IsVisible)
        {
            GridDesplegable.Opacity = 1;
            VerticalDesplegable1.Opacity = 0;
            VerticalDesplegable2.Opacity = 0;
            VerticalDesplegable3.Opacity = 0;
            VerticalDesplegable4.Opacity = 0;
            VerticalDesplegable5.Opacity = 0;

            GridDesplegable.IsVisible = true;

            await VerticalDesplegable1.FadeTo(1, 200, Easing.Linear);
            await VerticalDesplegable2.FadeTo(1, 200, Easing.Linear);
            await VerticalDesplegable3.FadeTo(1, 200, Easing.Linear);
            await VerticalDesplegable4.FadeTo(1, 200, Easing.Linear);
            await VerticalDesplegable5.FadeTo(1, 200, Easing.Linear);
        }
        else
        {
            await GridDesplegable.FadeTo(0, 200, Easing.Linear);
            GridDesplegable.IsVisible = false;
        }
    }
}
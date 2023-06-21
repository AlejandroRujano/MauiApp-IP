using MauiApp_IP.Resources.Model;
using System.Net.NetworkInformation;

namespace MauiApp_IP.Resources.Views;

public partial class ContentSpeedyIP : ContentPage
{
    Adaptador _adaptadorActivo;
    readonly Animation _animacionSacudirPadre;
    readonly Animation _animacionSacudir1;
    readonly Animation _animacionSacudir2;
    readonly Animation _animacionSacudir3;

    public ContentSpeedyIP()
    {
        InitializeComponent();
        _animacionSacudirPadre = new Animation();
        _animacionSacudir1 = new Animation(x => ImgInterfaz2.Rotation = x, 0, 30, Easing.Linear);
        _animacionSacudir2 = new Animation(x => ImgInterfaz2.Rotation = x, 30, -20, Easing.Linear);
        _animacionSacudir3 = new Animation(x => ImgInterfaz2.Rotation = x, -20, 0, Easing.Linear);

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _animacionSacudirPadre.Add(0, 0.33, _animacionSacudir1);
        _animacionSacudirPadre.Add(0.33, 0.66, _animacionSacudir2);
        _animacionSacudirPadre.Add(0.66, 1, _animacionSacudir3);


        _animacionSacudirPadre.Commit(this, "Sacudir", 16, 500, Easing.Linear,
                    null, () => true);

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
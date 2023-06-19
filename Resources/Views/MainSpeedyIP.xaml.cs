using MauiApp_IP.Resources.ViewModel;

namespace MauiApp_IP.Resources.Views;

public partial class MainSpeedyIP : ContentPage
{
    BaseViewModel ViewModel = new BaseViewModel(); //AUN NO ESTA EN USO
    readonly Animation _animacionRotacion;
    readonly Animation _animacionBrillar;
    public MainSpeedyIP()
    {
        InitializeComponent();

        _animacionRotacion = new Animation(x => ImgCentral.Rotation = x, 0, 360, Easing.Linear);
        _animacionBrillar = new Animation(x => BordeBtnAnalizar.Opacity = x, 1, 0.3, Easing.Linear);

        ViewModel.PropertyChanged += ViewModel_PropertyChanged;
    }
    private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ViewModel.Activo))
        {
            if (ViewModel.Activo)
            {
                _animacionRotacion.Commit(this, "Rotar", 16, 1000, Easing.Linear,
                    (v, c) => ImgCentral.Rotation = 0, () => true);
            }
            else
            {
                this.AbortAnimation("Rotar");
            }
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ImgCentral.IsEnabled = true;
        BtnAnalizar.IsEnabled = true;

        _animacionRotacion.Commit(this, "Rotar", 16, 5000, Easing.Linear,
                    null, () => true);

        _animacionBrillar.Commit(this, "Brillar", 16, 3000, Easing.Linear,
                    null, () => true);
    }
    private async void BtnAnalizar_Clicked(object sender, EventArgs e)
    {
        ImgCentral.IsEnabled = false;
        BtnAnalizar.IsEnabled = false;
        BordeBtnAnalizar.Opacity = 1;
        this.AbortAnimation("Brillar");

        var _cambioDeVentana = Shell.Current.GoToAsync(nameof(ContentSpeedyIP), false);

        await Task.WhenAny(_cambioDeVentana);

        /*if (_cambioDeVentana.IsCompleted)
        {
            ImgCentral.IsEnabled = true;
            BtnAnalizar.IsEnabled = true;
        }*/
    }
}
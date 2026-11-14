using MauiAppMeuHotel.Views;

namespace MauiAppMeuHotel;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(SobreMeuHotel), typeof(SobreMeuHotel));

        Routing.RegisterRoute(nameof(HospedagemContratadaMeuHotel), typeof(Views.HospedagemContratadaMeuHotel));
    }
}
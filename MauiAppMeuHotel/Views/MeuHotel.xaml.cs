using MauiAppMeuHotel.Models;

namespace MauiAppMeuHotel.Views;

public partial class MeuHotel : ContentPage
{
    private readonly List<Quarto> Lista_quartos = new()
    {
        new Quarto { Nome = "Quarto Master", ValorAdultos = 300.00, ValorCriancas = 150.00 },
        new Quarto { Nome = "Quarto Premium", ValorAdultos = 200.00, ValorCriancas = 150.00 },
        new Quarto { Nome = "Quarto Standard", ValorAdultos = 150.00, ValorCriancas = 75.00 }
    };

    public MeuHotel()
    {
        InitializeComponent();
        pck_quarto.ItemsSource = Lista_quartos;

        DateTime hoje = DateTime.Today;

        dtpck_checkin.MinimumDate = hoje;
        dtpck_checkin.MaximumDate = hoje.AddMonths(3);
        dtpck_checkin.Date = hoje;

        dtpck_checkout.MinimumDate = hoje.AddDays(1);
        dtpck_checkout.MaximumDate = hoje.AddMonths(4);
        dtpck_checkout.Date = hoje.AddDays(1);
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SobreMeuHotel));
    }

    private async void CalcularContratação_Clicked(object sender, EventArgs e)
    {
        if (pck_quarto.SelectedItem is not Quarto quarto)
        {
            await DisplayAlert("Atenção", "Selecione uma acomodação.", "OK");
            return;
        }

        DateTime checkin = dtpck_checkin.Date ?? DateTime.Today;
        DateTime checkout = dtpck_checkout.Date ?? checkin.AddDays(1);

        if (checkout <= checkin)
        {
            await DisplayAlert("Atenção", "O check-out deve ser posterior ao check-in.", "OK");
            return;
        }

        Hospedagem h = new()
        {
            QtdAdultos = (int)stp_adulto.Value,
            QtdCriancas = (int)stp_crianca.Value,
            QuartoEscolhido = quarto,
            DataCheckin = checkin,
            DataCheckout = checkout
        };

        var parametros = new ShellNavigationQueryParameters
        {
            { "Hospedagem", h }
        };

        await Shell.Current.GoToAsync(
            nameof(HospedagemContratadaMeuHotel),
            parametros);
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime novaData = e.NewDate ?? DateTime.Today;

        dtpck_checkout.MinimumDate = novaData.AddDays(1);

        if (dtpck_checkout.Date <= novaData)
        {
            dtpck_checkout.Date = novaData.AddDays(1);
        }
    }
}

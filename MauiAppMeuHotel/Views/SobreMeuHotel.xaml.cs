namespace MauiAppMeuHotel.Views;

public partial class SobreMeuHotel : ContentPage
{
	public SobreMeuHotel()
	{
		InitializeComponent();
	}

	private async void OnVoltarClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}
}
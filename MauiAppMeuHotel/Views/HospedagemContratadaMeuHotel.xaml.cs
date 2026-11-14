using System;
using System.Collections.Generic;
using MauiAppMeuHotel.Models;

namespace MauiAppMeuHotel.Views;

public partial class HospedagemContratadaMeuHotel :
    ContentPage, IQueryAttributable
{
    // Construtor da página
    public HospedagemContratadaMeuHotel()
    {
        InitializeComponent();
    }

    // Receber os dados enviados pela primeira tela
    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue("Hospedagem", out var dados)
            && dados is Hospedagem hospedagem)
        {
            BindingContext = hospedagem;
        }
    }

    // Botão para voltar à primeira tela
    private async void Button_Clicked(
        object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

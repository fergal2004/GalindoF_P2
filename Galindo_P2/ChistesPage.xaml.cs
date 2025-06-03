using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Galindo_P2;

public partial class ChistesPage : ContentPage
{
    HttpClient httpClient = new();
    public ChistesPage()
    {
        InitializeComponent();
        _ = ObtenerChisteAsync();
    }

    private async Task ObtenerChisteAsync()
    {
        try
        {
            var url = "https://official-joke-api.appspot.com/random_joke";
            var chiste = await httpClient.GetFromJsonAsync<Joke>(url);

            if (chiste != null)
            {
                ChisteLabel.Text = $"{chiste.Setup}\n\n{chiste.Punchline}";
            }
            else
            {
                ChisteLabel.Text = "No se pudo cargar el chiste.";
            }
        }
        catch (Exception ex)
        {
            ChisteLabel.Text = $"Error al obtener chiste:\n{ex.Message}";
        }
    }

    private async void OtroChisteButton(object sender, EventArgs e)
    {
        await ObtenerChisteAsync();
    }
    public class Joke
    {
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; } 
    }
}
using System.Net.Http;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace Galindo_P2;

public partial class ChistesPage : ContentPage
{
    public ChistesPage()
    {
        InitializeComponent();
        CargarChiste();
    }

    private async void CargarChiste()
    {
        try
        {
            using HttpClient client = new();
            string url = "https://official-joke-api.appspot.com/random_joke";
            var response = await client.GetStringAsync(url);

            var joke = JsonSerializer.Deserialize<Joke>(response);
            if (joke != null)
            {
                JokeLabel.Text = $"{joke.setup}\n\n{joke.punchline}";
            }
            else
            {
                JokeLabel.Text = "No se pudo cargar el chiste.";
            }
        }
        catch (Exception ex)
        {
            JokeLabel.Text = $"Error: {ex.Message}";
        }
    }

    private void OnOtroChisteClicked(object sender, EventArgs e)
    {
        CargarChiste();
    }
}

public class Joke
{
    public string type { get; set; }
    public string setup { get; set; }
    public string punchline { get; set; }
}
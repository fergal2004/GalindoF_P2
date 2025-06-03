using System.Net.Http;
using System.Text.Json;
using System.Diagnostics; 

namespace Galindo_P2
{
    public partial class ChistesPage : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public ChistesPage()
        {
            InitializeComponent();
            LoadJoke();
        }

        private async void LoadJoke()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://official-joke-api.appspot.com/random_joke");

                
                Debug.WriteLine($"API Raw Response: {response}");
                

                var joke = JsonSerializer.Deserialize<Joke>(response);

                if (joke != null)
                {
                    JokeLabel.Text = $"{joke.Setup}\n\n{joke.Punchline}";
                }
                else
                {
                    JokeLabel.Text = "Error: La API devolvió una respuesta nula o vacía.";
                }
            }
            catch (JsonException jEx)
            {
                // Specific error for JSON parsing issues
                Debug.WriteLine($"JSON Parsing Error: {jEx.Message}");
                JokeLabel.Text = $"Error al procesar el chiste (JSON): {jEx.Message}";
            }
            catch (HttpRequestException httpEx)
            {
                // Specific error for network/HTTP issues
                Debug.WriteLine($"HTTP Request Error: {httpEx.Message}");
                JokeLabel.Text = $"Error de red al cargar el chiste: {httpEx.Message}";
            }
            catch (Exception ex)
            {
                // General catch-all for other errors
                Debug.WriteLine($"General Error loading joke: {ex.ToString()}");
                JokeLabel.Text = $"Error al cargar el chiste: {ex.Message}";
            }
        }

        private void OnOtroChisteButtonClicked(object sender, EventArgs e)
        {
            LoadJoke();
        }
    }

    public class Joke
    {
        public string Setup { get; set; }
        public string Punchline { get; set; }
    }
}
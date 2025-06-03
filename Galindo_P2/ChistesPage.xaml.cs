using System.Net.Http;
using System.Text.Json;

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
                // Consume the API [cite: 5]
                var response = await _httpClient.GetStringAsync("https://official-joke-api.appspot.com/random_joke");
                var joke = JsonSerializer.Deserialize<Joke>(response);

                if (joke != null)
                {
                    // Show the complete joke (setup + punchline) [cite: 5]
                    JokeLabel.Text = $"{joke.Setup}\n\n{joke.Punchline}"; // JokeLabel is now resolvable
                }
            }
            catch (Exception ex)
            {
                JokeLabel.Text = $"Error al cargar el chiste: {ex.Message}";
            }
        }

        private void OnOtroChisteButtonClicked(object sender, EventArgs e)
        {
            LoadJoke(); // Consume the API and show a new joke when button is pressed [cite: 6]
        }
    }

    // Class to deserialize the JSON response from the API
    public class Joke
    {
        public string Setup { get; set; }
        public string Punchline { get; set; }
    }
}
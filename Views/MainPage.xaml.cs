using System.Reflection;
using System.Text.Json;

namespace Module4A.Views
{
    public partial class MainPage : ContentPage
    {
        private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public MainPage()
        {
            GetCatFact(null, null);
            InitializeComponent();
        }

        private async void GetCatFact(object sender, EventArgs e)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.None)
            {
                try
                {
                    HttpClient client = new HttpClient();

                    string response = await client.GetStringAsync("https://catfact.ninja/fact");
                    CatFact.Text = JsonSerializer.Deserialize<CatFact>(response, _serializerOptions).Fact;
                }
                catch 
                {
                    
                }
            }
        }
    }
}
namespace WorkWithJsonDataUWP
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.Web.Http;

    using Newtonsoft.Json;

    using WorkWithJsonDataUWP.Models;

    public sealed partial class MainPage : Page
    {
        private readonly HttpClient httpClient;

        public MainPage()
        {
            this.InitializeComponent();
            this.httpClient = new HttpClient();
        }

        private async void RunButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResultTextBlock.Text = string.Empty;
            var url = "http://best.telerikacademy.com/api/projects/popular";
            var json = await this.ReadAsString(url);
            var rootObject = JsonConvert.DeserializeObject<RootObject>(json);

            var stringBuilder = new StringBuilder();
            foreach (var project in rootObject.data)
            {
                stringBuilder.AppendLine($"{project.title} ({project.likes} likes)");
                stringBuilder.AppendLine(
                    "        " + string.Join(", ", project.collaborators.Select(x => x.userName)));
                stringBuilder.AppendLine(
                    "        " + string.Join(", ", project.tags.Select(x => x.name)));
            }

            this.ResultTextBlock.Text = stringBuilder.ToString();
        }

        private async Task<string> ReadAsString(string url)
        {
            var response = await this.httpClient.GetAsync(new Uri(url));
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}

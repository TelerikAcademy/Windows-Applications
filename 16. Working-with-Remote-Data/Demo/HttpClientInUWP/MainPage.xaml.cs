namespace HttpClientInUWP
{
    using System;
    using System.Threading.Tasks;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.Web.Http;

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
            var url = "http://best.telerikacademy.com/api/projects";
            var json = await this.ReadAsString(url);
            this.ResultTextBlock.Text = json;
        }

        private async Task<string> ReadAsString(string url)
        {
            var response = await this.httpClient.GetAsync(new Uri(url));
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}

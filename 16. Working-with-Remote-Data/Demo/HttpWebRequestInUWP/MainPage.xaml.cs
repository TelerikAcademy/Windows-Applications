namespace HttpWebRequestInUWP
{
    using System.IO;
    using System.Net;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void RunButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResultTextBlock.Text = string.Empty;

            var request = WebRequest.CreateHttp("http://best.telerikacademy.com/api/projects");
            request.ContentType = "application/json";
            request.Method = "GET";

            var response = await request.GetResponseAsync();

            var reader = new StreamReader(response.GetResponseStream());
            var json = await reader.ReadToEndAsync();

            this.ResultTextBlock.Text = json;
        }
    }
}

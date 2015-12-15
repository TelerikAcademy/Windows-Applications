namespace AsyncResourceAccessUWP
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CountFilesButtonClick(object sender, RoutedEventArgs e)
        {
            var list = await this.Find(this.UrlTextBox.Text);
            this.ResultTextBlock.Text = string.Join(Environment.NewLine, list);
        }

        private async Task<List<LinkItem>> Find(string url)
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            var list = new List<LinkItem>();

            // 1. Find all matches in file.
            var matches = Regex.Matches(content, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

            // 2. Loop over each match.
            foreach (Match match in matches)
            {
                var value = match.Groups[1].Value;
                var linkItem = new LinkItem();

                // 3. Get href attribute.
                var m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
                if (m2.Success)
                {
                    linkItem.Href = m2.Groups[1].Value;
                }

                // 4. Remove inner tags from text.
                var text = Regex.Replace(value, @"\s*<.*?>\s*", string.Empty, RegexOptions.Singleline);
                linkItem.Text = text;

                list.Add(linkItem);

                // Intentionally slow down for the demo:
                list.Remove(linkItem);
                list.Add(linkItem);
            }

            return list;
        }
    }
}

namespace SyncResourceAccessProblemsUWP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text.RegularExpressions;

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

        private void CountFilesButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResultTextBlock.Text = string.Join(Environment.NewLine, this.Find(this.UrlTextBox.Text));
        }

        private List<LinkItem> Find(string url)
        {
            var client = new HttpClient();
            var content = client.GetStringAsync(url).Result;
            var list = new List<LinkItem>();

            // 1. Find all matches in file.
            var m1 = Regex.Matches(content, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

            // 2. Loop over each match.
            foreach (Match m in m1)
            {
                var value = m.Groups[1].Value;
                var i = new LinkItem();

                // 3. Get href attribute.
                var m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value;
                }

                // 4. Remove inner tags from text.
                var t = Regex.Replace(value, @"\s*<.*?>\s*", string.Empty, RegexOptions.Singleline);
                i.Text = t;

                list.Add(i);
            }

            return list;
        }
    }
}

namespace WorkWithHtmlDataUWP
{
    using System;
    using System.Linq;

    using AngleSharp;

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
            // Setup the configuration to support document loading
            var config = Configuration.Default.WithDefaultLoader();

            // Load the names of all The Big Bang Theory episodes from Wikipedia
            var address = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes";

            // Asynchronously get the document in a new context using the configuration
            var document = await BrowsingContext.New(config).OpenAsync(address);

            // This CSS selector gets the desired content
            var cellSelector = "tr.vevent td:nth-child(3)";

            // Perform the query to get all cells with the content
            var cells = document.QuerySelectorAll(cellSelector);

            // We are only interested in the text - select it with LINQ
            var titles = cells.Select(m => m.TextContent);

            this.ResultTextBlock.Text = string.Join(Environment.NewLine, titles);
        }
    }
}

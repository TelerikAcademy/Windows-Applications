namespace UsingBuiltInAsyncMethods
{
    using System;
    using System.Net.Http;
    using System.Threading;

    using AngleSharp.Parser.Html;

    public static class UsingBuiltInAsyncMethods
    {
        private static string websiteHtml;

        public static void Main()
        {
            Console.WriteLine("Enter URL of website for which to print HTML: ");
            var url = Console.ReadLine();

            GetWebsiteHtmlAsync(url);

            while (true)
            {
                if (websiteHtml == null)
                {
                    Console.WriteLine("Loading...");
                    Thread.Sleep(100);
                }
                else
                {
                    var parser = new HtmlParser();
                    var document = parser.Parse(websiteHtml);
                    var links = document.QuerySelector("a").ChildElementCount;
                    Console.WriteLine($"Found: {links} links");

                    Console.WriteLine("Enter URL of website for which to print HTML: ");
                    url = Console.ReadLine();
                    GetWebsiteHtmlAsync(url);
                }
            }
        }

        private static async void GetWebsiteHtmlAsync(string websiteUrl)
        {
            var client = new HttpClient();
            websiteHtml = await client.GetStringAsync(websiteUrl);
            Console.WriteLine("Downloaded html");
        }
    }
}

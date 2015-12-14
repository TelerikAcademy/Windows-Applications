namespace SyncResourceAccessProblems
{
    using System;
    using System.Net;

    public static class SyncResourceAccessProblems
    {
        public static void Main()
        {
            Console.WriteLine("Enter URL of website for which to print HTML:");
            var url = Console.ReadLine();

            var webContentAsString = GetWebsiteHtml(url);

            while (true)
            {
                Console.WriteLine("What should I do?");
                var userInput = Console.ReadLine();

                if (userInput == "Print")
                {
                    Console.WriteLine(webContentAsString);
                }
                else
                {
                    Console.WriteLine("I don't know that command. Try again...");
                }
            }
        }

        private static string GetWebsiteHtml(string websiteUrl)
        {
            var client = new WebClient();
            var webContentAsString = client.DownloadString(websiteUrl);
            return webContentAsString;
        }
    }
}

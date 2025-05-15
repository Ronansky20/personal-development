using System.ServiceModel.Syndication;
using System.Xml;

namespace RssReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RSS Feed Starting");

            Console.WriteLine("Enter the RSS Feed you want to check:");
            var URL = Console.ReadLine();

            Console.WriteLine("How far back do you want to see?");
            var amount = Console.ReadLine();
            int amountInteger;
            if (int.TryParse(amount, out amountInteger))
            {
                if (string.IsNullOrWhiteSpace(URL))
                {
                    Console.WriteLine("No RSS feed entered, closing program");
                    return;
                }

                XmlReaderSettings settings =
                    new XmlReaderSettings
                    {
                        XmlResolver = null,
                        DtdProcessing = DtdProcessing.Prohibit,
                        IgnoreWhitespace = true,
                        CheckCharacters = true,
                        CloseInput = true,
                        IgnoreComments = true,
                        IgnoreProcessingInstructions = true,
                    };

                using var reader = XmlReader.Create(URL, settings);
                SyndicationFeedFormatter GenericFeedFormatter = null;
                Atom10FeedFormatter atom = new Atom10FeedFormatter();
                Rss20FeedFormatter rss = new Rss20FeedFormatter();

                if (reader.ReadState == ReadState.Initial)
                    reader.MoveToContent();
                if (atom.CanRead(reader))
                    GenericFeedFormatter = atom;
                if (rss.CanRead(reader))
                    GenericFeedFormatter = rss;

                GenericFeedFormatter.ReadFrom(reader);
                var feed = GenericFeedFormatter.Feed;

                Console.WriteLine($"RSS Title: {GenericFeedFormatter.Feed.Title.Text}");
                for (int i = 0; i < amountInteger; i++)
                {
                    Console.WriteLine($"Post title: {GenericFeedFormatter.Feed.Title.Text}");
                    Console.WriteLine($"Post last updated time: {GenericFeedFormatter.Feed.LastUpdatedTime}");
                    Console.WriteLine($"Post summary: {GenericFeedFormatter.Feed.Description.Text}");
                    Console.WriteLine($"Post baseurl: {GenericFeedFormatter.Feed.Links[1].Uri}");
                    Console.WriteLine("\n");
                }

                Console.WriteLine("rss end");
            }
            return;
        }
    }
}
using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RssReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RSS Feed Starting");

            var URL = "https://weebcentral.com/series/01J76XYGY7FDV857J4HJAZ131K/rss";

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
            {
                reader.MoveToContent();
            }
            if (atom.CanRead(reader)) 
            {
                GenericFeedFormatter = atom;
            }
            if (rss.CanRead(reader)) 
            {
                GenericFeedFormatter = rss;
            }
            if (GenericFeedFormatter == null) 
            {
                System.Environment.Exit(0);
            }
            GenericFeedFormatter.ReadFrom(reader);
            var feed = GenericFeedFormatter.Feed;

            Console.WriteLine($"RSS Title: {GenericFeedFormatter.Feed.Title.Text}");
            foreach (var item in GenericFeedFormatter.Feed.Items)
            {
                Console.WriteLine($"Post id: {item.Id}");
                Console.WriteLine($"Post title: {item.Title.Text}");
                Console.WriteLine($"Post last updated time: {item.LastUpdatedTime}");
                Console.WriteLine($"Post publish date: {item.PublishDate}");
                Console.WriteLine($"Post authors: {item.Authors.FirstOrDefault()?.Name}");
                Console.WriteLine($"Post summary: {item.Summary?.Text}");
                Console.WriteLine($"Post summary: {((TextSyndicationContent)item.Content)?.Text}");

                Console.WriteLine($"Post baseurl: {item.BaseUri}");
                Console.WriteLine($"Post baseurl: {item.Links[0].Uri}");
                Console.WriteLine("\n");
            }

            Console.WriteLine("rss end");
        }
    }
}
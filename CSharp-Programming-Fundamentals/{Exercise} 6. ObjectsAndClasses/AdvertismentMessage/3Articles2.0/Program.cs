using System;
using System.Linq;
using System.Collections.Generic;

namespace AdvertismentMessage
{
    class Articles2dot0
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 1; i <= lines; i++)
            {
                List<string> article = Console.ReadLine()
                .Split(", ")
                .ToList();

                Article articleObj = new Article(article[0], article[1], article[2]);
                articles.Add(articleObj);
            }

            Console.ReadLine();

            for (int i = 0; i < articles.Count; i++)
            {
                Console.WriteLine(articles[i].ToString());
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
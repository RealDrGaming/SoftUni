using System;
using System.Linq;
using System.Collections.Generic;

namespace AdvertismentMessage
{
    class Articles
    {
        static void Main()
        {
            List<string> article = Console.ReadLine()
                .Split(", ")
                .ToList();

            Article articleObj = new Article(article[0], article[1], article[2]);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= lines; i++)
            {
                string[] args = Console.ReadLine().Split(": ");
                string command = args[0];
                string value = args[1];

                if (command == "Edit")
                {
                    articleObj.Edit(value);
                }
                else if (command == "ChangeAuthor")
                {
                    articleObj.ChangeAuthor(value);
                }
                else if (command == "Rename")
                {
                    articleObj.Rename(value);
                }
            }

            Console.WriteLine(articleObj.ToString());
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

        public void Edit(string newContent)
        {
            Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
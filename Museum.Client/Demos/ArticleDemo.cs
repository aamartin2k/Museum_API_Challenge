using Museum.Client.Clients;
using Museum.Client.Forms;
using MuseumAPI.Mapping.Resources;
using System;
using System.Linq;

namespace Museum.Client.Demos
{
    internal static class ArticleDemo
    {
        public static void Demo_Article(string baseUrl, string resource)
        {
            #region Articles
    
            // Read
            var articleClient = new ArticleClient(baseUrl, resource);
            var articles = articleClient.Get();

            Console.WriteLine("Start: " + articleClient.GetType().Name);
            Console.WriteLine("Found {0} articles: ", articles.Count);

            FormList form = new FormList();

            foreach (var article in articles)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", article.Name, article.Id, article.StatusDescription, article.MuseumId);
                form.listBox1.Items.Add(article.Name);
            }

            form.ShowDialog();

            // Create
            Console.WriteLine();
            Console.WriteLine("Adding a new article");
            articleClient.Create(new NewArticleResource() { Name = "Miniature Roman", StatusId = 100, MuseumId = 101 });

            // Read again
            articles = articleClient.Get();
            Console.WriteLine("Now found {0} articles", articles.Count);
            var last = articles.OrderBy(p => p.Id).First();
            Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", last.Name, last.Id, last.StatusDescription, last.MuseumId);

            // Update
            Console.WriteLine();
            Console.WriteLine("Updating the last article");
            last.Name = "Miniature Roman Damaged";
            last.StatusId = 102;

            articleClient.Update(last.Id, last);

            // Read again
            articles = articleClient.Get();
            Console.WriteLine("Now found {0} articles", articles.Count);
            last = articles.OrderBy(p => p.Id).First();
            Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", last.Name, last.Id, last.StatusDescription, last.MuseumId);


            // List by Museum ID
            Console.WriteLine();
            Console.WriteLine("Selecting all Museum's articles for Museum Id = 101");
            articles = articleClient.ListByMuseumID(101);

            Console.WriteLine("Found {0} articles: ", articles.Count);
            foreach (var article in articles)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", article.Name, article.Id, article.StatusDescription, article.MuseumId);
            }

            Console.WriteLine();
            // Add articles to Museum ID
            Console.WriteLine("Add articles 105 & 107 to Museum Id = 101");
            // 105
            var artc = articleClient.ListById(105);
            artc.MuseumId = 101;
            articleClient.Update(artc.Id, artc);
            // 107
            artc = articleClient.ListById(107);
            artc.MuseumId = 101;
            articleClient.Update(artc.Id, artc);

            Console.WriteLine("Selecting all Museum's articles for Museum Id = 101");
            articles = articleClient.ListByMuseumID(101);

            Console.WriteLine("Found {0} articles: ", articles.Count);
            foreach (var article in articles)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", article.Name, article.Id, article.StatusDescription, article.MuseumId);
            }

            Console.WriteLine();
            // Change status
            Console.WriteLine("Selecting all damaged articles");
            articles = articleClient.Get();
            var damaged = articles.Where(ar => ar.StatusId == 102).ToList();

            Console.WriteLine("Found {0} articles: ", damaged.Count);
            foreach (var article in damaged)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", article.Name, article.Id, article.StatusDescription, article.MuseumId);
            }

            Console.WriteLine();
            Console.WriteLine("Changing article 101 status to damaged");
            artc = articles.Where(ar => ar.Id == 101).First();
            artc.StatusId = 102;
            articleClient.Update(artc.Id, artc);

            // Read again
            Console.WriteLine("Selecting all damaged articles");
            articles = articleClient.Get();
            damaged = articles.Where(ar => ar.StatusId == 102).ToList();

            Console.WriteLine("Found {0} articles: ", damaged.Count);
            foreach (var article in damaged)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", article.Name, article.Id, article.StatusDescription, article.MuseumId);
            }

            // Delete
            Console.WriteLine();
            Console.WriteLine("Deleting the last article");

            articleClient.Delete(last.Id);

            // Read again
            articles = articleClient.Get();
            Console.WriteLine("Found {0} articles: ", articles.Count);
            foreach (var article in articles)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", article.Name, article.Id, article.StatusDescription, article.MuseumId);
            }


            #endregion
        }

        public static void Demo_ArticleStatus(string baseUrl, string resource)
        {
            var articleClient = new ArticleStatusClient(baseUrl, resource);
            var articles = articleClient.Get();

            Console.WriteLine("Found {0} article status: ", articles.Count);
            foreach (var article in articles)
            {
                Console.WriteLine("\t{0} (ID:{1})", article.Description, article.Id);
            }
        }
    }
}

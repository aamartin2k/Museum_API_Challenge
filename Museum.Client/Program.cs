using Museum.Client.Clients;
using MuseumAPI.Mapping.Resources;
using System;
using System.Linq;

namespace Museum.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "https://localhost:5001/api/";
            string resource;

            #region Museums
            // Museums
            resource = "Museums/";

            // Read
            var client = new MuseumClient(baseUrl, resource);
            var museums = client.Get();

            Console.WriteLine("Start: " + client.GetType().Name);
            Console.WriteLine("Found {0} museums: ", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }
            // Create
            Console.WriteLine();
            Console.WriteLine("Adding a new museum");
            client.Create(new NewMuseumResource() { Name = "Ultimate Museum", Address = "34th Museum Road North", ThemeId = 101 });
            // Read again
            museums = client.Get();
            Console.WriteLine("Now found {0} museums", museums.Count);
            var lastM = museums.OrderBy(p => p.Id).First();
            Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", lastM.Name, lastM.Id, lastM.Address, lastM.ThemeDescription);

            // Update
            Console.WriteLine();
            Console.WriteLine("Updating the last museum");
            lastM.Name = "Miniature Ultimate Museum";
            lastM.ThemeId = 102;

            client.Update(lastM.Id, lastM);

            // Read again
            museums = client.Get();
            Console.WriteLine("Now found {0} museums", museums.Count);
            lastM = museums.OrderBy(p => p.Id).First();
            Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", lastM.Name, lastM.Id, lastM.Address, lastM.ThemeDescription);

            // Get all museums by theme
            Console.WriteLine();
            Console.WriteLine("Get all Museums by Theme");
            Console.WriteLine("  Museums of Theme Art:");
            museums = client.ListByThemeID(100);
            Console.WriteLine("  Found {0} museums: ", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }

            Console.WriteLine("  Museums of Theme Natural Science:");
            museums = client.ListByThemeID(101);
            Console.WriteLine("  Found {0} museums: ", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }

            Console.WriteLine("  Museums of Theme History:");
            museums = client.ListByThemeID(102);
            Console.WriteLine("  Found {0} museums: ", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }

            // Delete
            Console.WriteLine();
            Console.WriteLine("Deleting the last museum");

            client.Delete(lastM.Id);

            // Read again
            museums = client.Get();
            Console.WriteLine("Now found {0} museums", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }

            #endregion

            Console.WriteLine();
            Console.WriteLine("Press enter to continue with Articles...");
            Console.ReadLine();
            Console.WriteLine();

            #region Articles
            // Articles
            resource = "Articles/";

            // Read
            var articleClient = new ArticleClient(baseUrl, resource);
            var articles = articleClient.Get();

            Console.WriteLine("Start: " + articleClient.GetType().Name);
            Console.WriteLine("Found {0} articles: ", articles.Count);
            foreach (var article in articles)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", article.Name, article.Id, article.StatusDescription, article.MuseumId);
            }

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

            // Change status
            Console.WriteLine("Selecting all damaged articles");
            articles = articleClient.Get();
            var damaged = articles.Where(ar => ar.StatusId == 102).ToList();

            Console.WriteLine("Found {0} articles: ", damaged.Count);
            foreach (var article in damaged)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status: {2} Location: {3}", article.Name, article.Id, article.StatusDescription, article.MuseumId);
            }

            Console.WriteLine("Changing article 101  status to damaged");
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


            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}

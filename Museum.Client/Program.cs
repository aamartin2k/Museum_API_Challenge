using Museum.Client.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "https://localhost:5001/api/";


            var articleClient = new ArticleClient(baseUrl, "Articles/");
            var articles = articleClient.Get();

            Console.WriteLine("Start: " + articleClient.GetType().Name);
            Console.WriteLine("Found {0} articles: ", articles.Count);
            foreach (var article in articles)
            {
                Console.WriteLine("\t{0} (ID:{1}) Status {2:c}", article.Name, article.Id, article.StatusDescription );
            }




            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}

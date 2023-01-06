using MuseumAPI.Common;
using RestSharp;
using System;

namespace Museum.Client.Demos
{
    internal static class Builder
    {
       public static void Demo()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to show Museums...");
            Console.ReadLine();

            Console.WriteLine();
            MuseumDemo.Demo_Museum(new RestClient(Constants.BaseUrl), Constants.ResMuseums);

            Console.WriteLine();
            Console.WriteLine("Press enter to continue with Museum Themes...");
            Console.ReadLine();
            Console.WriteLine();

            MuseumDemo.Demo_MuseumTheme(new RestClient(Constants.BaseUrl), Constants.ResMuseumTheme);

            Console.WriteLine();
            Console.WriteLine("Press enter to continue with Articles...");
            Console.ReadLine();
            Console.WriteLine();

            ArticleDemo.Demo_Article(new RestClient(Constants.BaseUrl), Constants.ResArticles);

            Console.WriteLine();
            Console.WriteLine("Press enter to continue with Article Status...");
            Console.ReadLine();
            Console.WriteLine();

            ArticleDemo.Demo_ArticleStatus(new RestClient(Constants.BaseUrl), Constants.ResArticleStatus);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}

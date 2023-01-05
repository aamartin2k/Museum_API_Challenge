using MuseumAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Demos
{
    static class Builder
    {
        static void Demo()
        {
            

           MuseumDemo.Demo(Constants.BaseUrl, Constants.ResMuseums);

            Console.WriteLine();
            Console.WriteLine("Press enter to continue with Articles...");
            Console.ReadLine();
            Console.WriteLine();

            ArticleDemo.Demo(Constants.BaseUrl, Constants.ResArticles);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}

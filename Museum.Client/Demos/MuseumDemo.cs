using Museum.Client.Clients;
using Museum.Client.Forms;
using MuseumAPI.Mapping.Resources;
using RestSharp;
using System;
using System.Linq;

namespace Museum.Client.Demos
{
    internal static class MuseumDemo
    {
        public static void Demo_Museum(IRestClient rclient, string resource)
        {
            #region Museums
         
            // Read
            var mclient = new MuseumClient(rclient, resource);
            var museums = mclient.Get();

            Console.WriteLine("Start: " + mclient.GetType().Name);
            var text = string.Format("Found {0} museums: ", museums.Count);
            Console.WriteLine(text);

            FormList form = new FormList();
            form.Text = text;

            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
                form.listBox1.Items.Add(museum.Name);
            };

            form.ShowDialog();
   

            // Create
            Console.WriteLine();
            Console.WriteLine("Adding a new museum");
            mclient.Create(new NewMuseumResource() { Name = "Ultimate Museum", Address = "34th Museum Road North", ThemeId = 101 });
           
            // Read again
            museums = mclient.Get();
            Console.WriteLine("Now found {0} museums", museums.Count);
            var lastM = museums.OrderBy(p => p.Id).First();
            Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", lastM.Name, lastM.Id, lastM.Address, lastM.ThemeDescription);

            // Update
            Console.WriteLine();
            Console.WriteLine("Updating the last museum");
            lastM.Name = "Miniature Ultimate Museum";
            lastM.ThemeId = 102;

            mclient.Update(lastM.Id, lastM);

            // Read again
            museums = mclient.Get();
            Console.WriteLine("Now found {0} museums", museums.Count);
            lastM = museums.OrderBy(p => p.Id).First();
            Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", lastM.Name, lastM.Id, lastM.Address, lastM.ThemeDescription);

            // Get all museums by theme
            Console.WriteLine();
            Console.WriteLine("Get all Museums by Theme");
            Console.WriteLine("  Museums of Theme Art:");
            museums = mclient.ListByThemeID(100);
            Console.WriteLine("  Found {0} museums: ", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }

            Console.WriteLine("  Museums of Theme Natural Science:");
            museums = mclient.ListByThemeID(101);
            Console.WriteLine("  Found {0} museums: ", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }

            Console.WriteLine("  Museums of Theme History:");
            museums = mclient.ListByThemeID(102);
            Console.WriteLine("  Found {0} museums: ", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }

            // Delete
            Console.WriteLine();
            Console.WriteLine("Deleting the last museum");

            mclient.Delete(lastM.Id);

            // Read again
            museums = mclient.Get();
            Console.WriteLine("Now found {0} museums", museums.Count);
            foreach (var museum in museums)
            {
                Console.WriteLine("\t{0} (ID:{1}) Address: {2} Theme: {3}", museum.Name, museum.Id, museum.Address, museum.ThemeDescription);
            }

            #endregion
        }

        public static void Demo_MuseumTheme(IRestClient client, string resource)
        {
            var articleClient = new MuseumThemeClient(client, resource);
            var articles = articleClient.Get();

            Console.WriteLine("Found {0} museum themes: ", articles.Count);
            foreach (var article in articles)
            {
                Console.WriteLine("\t{0} (ID:{1})", article.Description, article.Id);
            }
        }

    }
}

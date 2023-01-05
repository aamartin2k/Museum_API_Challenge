﻿using Museum.Client.Clients;
using MuseumAPI.Mapping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Demos
{
    static class MuseumDemo
    {
        public static void Demo(string baseUrl, string resource)
        {
            #region Museums
         
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
        }
    }
}

using Client_Console_Velib.WS_Soap_Velib_Reference;
using System;
using System.Collections.Generic;

namespace Client_Console_Velib
{
    class Program
    {

        static List<Composite_City> cityList;
        static ServiceVelibClient serviceReference;

        static void Main(string[] args)
        {
            serviceReference = new ServiceVelibClient();
            cityList = new List<Composite_City>(serviceReference.GetContracts());

            Console.WriteLine("Bonjour et bienvenue dans l'application de consultation des stations de vélos publiques.");
            Console.WriteLine("Il est recommandé de passer cette application en plein écran pour une meilleure lecture.");
            Console.WriteLine("\nEntrez \"aide\" pour une liste des commandes disponibles.\n");
            string command = "";

            while (!String_Contains(command, "terminer"))
            {
                command = Console.ReadLine();

                if (String_Contains(command, "aide"))
                    Display_Help();
                else if (String_Contains(command, "liste_villes"))
                    Display_Cities();
                else if (String_Contains(command, "info"))
                    Display_City_Info(command);
                else
                    Console.WriteLine("Commande inconnue. Entrer \"aide\" pour une liste des commandes.\n");
            }
        }

        private static bool String_Contains(string command, string test_string)
        {
            return command.IndexOf(test_string, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static void Display_Help()
        {
            Console.WriteLine("\naide\t\t\t\tpermet d'afficher cette liste");
            Console.WriteLine("liste_villes\t\t\tpermet d'afficher la liste des villes disponibles");
            Console.WriteLine("info {nom de la ville}\t\tpermet d'afficher les stations d'une ville");
            Console.WriteLine("terminer\t\t\tpermet de sortir du programme.\n");
            return;
        }

        static void Display_Cities()
        {
            Console.WriteLine("\nVoici la liste des villes pour lesquelles vous pouvez consulter les stations :");
            foreach (Composite_City c in cityList)
                Console.WriteLine(c.Name + " [" + c.Country_code + "]");
            Console.WriteLine("");
        }

        private static void Display_City_Info(string command)
        {
            foreach (Composite_City c in cityList)
                if (String_Contains(command, c.Name))
                {
                    Console.WriteLine("");
                    List<Composite_StationVelib> stations = new List<Composite_StationVelib>(serviceReference.GetAllInformationForContract(c.Name));
                    foreach (Composite_StationVelib s in stations)
                        Console.WriteLine(String.Format("{0,-60} {1,3} vélos disponibles.", s.Name, s.Available_bikes));
                    Console.WriteLine(c.Name + " (" + c.Commercial_name + "), " + stations.Count + " stations existantes.\n");
                    return;
                }
            Console.WriteLine("\nImpossible de trouver une ville pour la commande \"" + command + "\"\n");
            return;
        }
    }
}

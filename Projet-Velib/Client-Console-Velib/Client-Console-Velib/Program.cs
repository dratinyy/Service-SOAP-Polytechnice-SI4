using Client_Console_Velib.WS_Soap_Velib_Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Console_Velib
{
    class Program
    {

        static List<Composite_City> cityList;
        static ServiceClient serviceReference;

        static void Main(string[] args)
        {
            serviceReference = new ServiceClient();
            cityList = new List<Composite_City>(serviceReference.GetContracts());

            Console.WriteLine("Bonjour et bienvenue dans l'application de consultation des stations de vélos publiques.\nEntrez \"help\" pour une liste des commandes disponibles.");
            string command = "";

            while (!String_Contains(command, "quit"))
            {
                command = Console.ReadLine();

                if (String_Contains(command, "help"))
                    Display_Help();
                else if (String_Contains(command, "list"))
                    Display_Cities();
                else if (String_Contains(command, "info"))
                    Display_City_Info(command);
                else
                    Console.WriteLine("Commande inconnue. Entrer \"help\" pour une liste des commandes.");
            }
        }

        private static bool String_Contains(string command, string test_string)
        {
            return command.IndexOf(test_string, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static void Display_Help()
        {
            Console.WriteLine("help, cities, {cityname}, quit");
            return;
        }

        static void Display_Cities()
        {
            Console.WriteLine("Voici la liste des villes pour lesquelles vous pouvez consulter les stations :\n");
            foreach (Composite_City c in cityList)
                Console.WriteLine(c.Name + " [" + c.Country_code + "]");
        }

        private static void Display_City_Info(string command)
        {
            foreach (Composite_City c in cityList)
                if (command.IndexOf(c.Name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    List<Composite_StationVelib> stations = new List<Composite_StationVelib>(serviceReference.GetAllInformationForContract(c.Name));
                    Console.WriteLine(c.Name + " (" + c.Commercial_name + "), " + stations.Count + " stations existantes");
                    return;
                }
            Console.WriteLine("ERROR");
            return;
        }
    }
}

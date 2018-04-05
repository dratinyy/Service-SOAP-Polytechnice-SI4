using Client_Console_Velib.WS_Soap_Velib_Reference;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Client_Console_Velib
{
    class Program
    {

        static List<Composite_City> cityList;
        static ServiceVelibClient serviceReference;

        static void Main(string[] args)
        {

            VelibServiceCallbackSink objsink = new VelibServiceCallbackSink();
            InstanceContext iCntxt = new InstanceContext(objsink);
            serviceReference = new ServiceVelibClient(iCntxt);
            cityList = new List<Composite_City>(serviceReference.GetContracts());

            serviceReference.SubscribeAllInfoForContractEvent();
            serviceReference.SubscribeAllInfoForContractFinishedEvent();
            serviceReference.SubscribeStationInfoForContractEvent();
            serviceReference.SubscribeStationInfoForContractFinishedEvent();

            Console.WriteLine("Bonjour et bienvenue dans l'application de consultation des stations de vélos publiques.");
            Console.WriteLine("Il est recommandé de passer cette application en plein écran pour une meilleure lecture.");
            Display_Help();
            string command = "";

            while (!String_Contains(command, "terminer"))
            {
                command = Console.ReadLine();

                if (String_Contains(command, "aide"))
                    Display_Help();
                else if (String_Contains(command, "liste_villes"))
                    Display_Cities();
                else if (String_Contains(command, "info_v"))
                    Display_City_Info();
                else if (String_Contains(command, "info_s"))
                    Display_Station_Info();
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
            Console.WriteLine("info_v\t\tpermet d'entrer une ville afin d'afficher les stations d'une ville");
            Console.WriteLine("info_s\t\tpermet d'entrer une ville puis un identifiant afin d'afficher cette station");
            Console.WriteLine("terminer\t\t\tpermet de sortir du programme.\n");
            return;
        }

        private static void Display_Cities()
        {
            Console.WriteLine("\nVoici la liste des villes pour lesquelles vous pouvez consulter les stations :");
            foreach (Composite_City c in cityList)
                Console.WriteLine(c.Name + " [" + c.Country_code + "]");
            Console.WriteLine("");
        }

        private static void Display_City_Info()
        {
            Console.WriteLine("entrez la ville souhaitée :");
            string contract = Console.ReadLine();
            serviceReference.GetAllInformationForContract(contract);
        }

        private static void Display_Station_Info()
        {
            Console.WriteLine("entrez successivement la ville souhaitée, puis l'identifiant de la station souhaitée (2 inputs différents):");
            string contract = Console.ReadLine(), identifiant = Console.ReadLine();
            serviceReference.GetStationInformationForContract(contract, Int32.Parse(identifiant));
        }

        private static void Subscribe(string Command)
        {

        }
    }
}

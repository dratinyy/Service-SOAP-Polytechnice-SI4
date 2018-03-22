using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;

namespace WS_Soap_Velib
{
    public class Service : IService
    {

        private Cache cache = new Cache();

        /// <summary>
        /// Appelle le Web Service de JCDecaux pour récupérer toutes les villes disponibles, avec la requête :
        /// https://api.jcdecaux.com/vls/v1/contracts
        /// </summary>
        public List<Composite_City> GetContracts()
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts"
                + "?apiKey=ed75cd6d6bb24bd1427faf27eeeea43b6dd4a5b6");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return JsonConvert.DeserializeObject<List<Composite_City>>(responseFromServer);
        }

        /// <summary>
        /// Appelle le Web Service de JCDecaux pour récupérer toutes les informations des stations d'une ville spécifique, avec la requête :
        /// https://api.jcdecaux.com/vls/v1/stations?contract={nom_de_la_ville}
        /// </summary>
        public List<Composite_StationVelib> GetAllInformationForContract(string contract)
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract
                + "&apiKey=ed75cd6d6bb24bd1427faf27eeeea43b6dd4a5b6");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return JsonConvert.DeserializeObject<List<Composite_StationVelib>>(responseFromServer);
        }

        /// <summary>
        /// Appelle le Web Service de JCDecaux pour récupérer les informations d'une station d'une ville, avec la requête :
        /// https://api.jcdecaux.com/vls/v1/stations/{id_de_la_station}?contract={nom_de_la_ville}
        /// </summary>
        public Composite_StationVelib GetStationInformationForContract(string contract, int station_id)
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations/" + station_id
                + "?contract=" + contract
                + "&apiKey=ed75cd6d6bb24bd1427faf27eeeea43b6dd4a5b6");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return JsonConvert.DeserializeObject<Composite_StationVelib>(responseFromServer);
        }

        internal class Cache
        {
            private DataTable table;

            public Cache()
            {

            }
        }
    }
}

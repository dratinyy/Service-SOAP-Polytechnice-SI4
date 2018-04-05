using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WS_Soap_Velib
{
    public class ServiceVelib : IServiceVelib
    {
        static Action<string, List<Composite_StationVelib>> m_EventStationList = delegate { };
        static Action m_EventStationListQueryFinished = delegate { };
        static Action<string, int, Composite_StationVelib> m_EventStation = delegate { };
        static Action m_EventStationQueryFinished = delegate { };

        public void SubscribeAllInfoForContractEvent()
        {
            IServiceVelibEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IServiceVelibEvents>();
            m_EventStationList += subscriber.CityStationListQuery;
        }

        public void SubscribeAllInfoForContractFinishedEvent()
        {
            IServiceVelibEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IServiceVelibEvents>();
            m_EventStationListQueryFinished += subscriber.CityStationListQueryFinished;
        }

        public void SubscribeStationInfoForContractEvent()
        {
            IServiceVelibEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IServiceVelibEvents>();
            m_EventStation += subscriber.StationQuery;
        }

        public void SubscribeStationInfoForContractFinishedEvent()
        {
            IServiceVelibEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IServiceVelibEvents>();
            m_EventStationQueryFinished += subscriber.StationQueryFinished;
        }

        void IServiceVelib.GetAllInformationForContract(string contract)
        {
            m_EventStationList(contract, cache.GetDataForContract(contract));
            m_EventStationListQueryFinished();
        }

        void IServiceVelib.GetStationInformationForContract(string contract, int station_id)
        {
            OperationContext current = OperationContext.Current;
            MessageProperties prop = current.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            MonitoringUnit.AddIncomingRequest(DateTime.Now, endpoint.Address);
            MonitoringUnit.AddOutgoingRequest(DateTime.Now);

            DateTime reqTime = DateTime.Now;
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations/" + station_id
                + "?contract=" + contract
                + "&apiKey=ed75cd6d6bb24bd1427faf27eeeea43b6dd4a5b6");
            WebResponse response = request.GetResponse();
            MonitoringUnit.AddJCDecauxResponseTime(reqTime, DateTime.Now);

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            m_EventStation(contract, station_id, JsonConvert.DeserializeObject<Composite_StationVelib>(responseFromServer));
            m_EventStationQueryFinished();
        }

        private Cache cache = new Cache();

        /*
         * Cette partie correspond au web service SOAP.
         * 
         * Elle contient les méthodes du service IServiceClient qui permettent de récupérer les informations
         * du service REST de JCDecaux à travers un service SOAP.
         */

        /// <summary>
        /// Appelle le Web Service de JCDecaux pour récupérer toutes les villes disponibles, avec la requête :
        /// https://api.jcdecaux.com/vls/v1/contracts
        /// </summary>
        public List<Composite_City> GetContracts()
        {
            OperationContext current = OperationContext.Current;
            MessageProperties prop = current.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            MonitoringUnit.AddIncomingRequest(DateTime.Now, endpoint.Address);
            MonitoringUnit.AddOutgoingRequest(DateTime.Now);

            DateTime reqTime = DateTime.Now;
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts"
                + "?apiKey=ed75cd6d6bb24bd1427faf27eeeea43b6dd4a5b6");
            WebResponse response = request.GetResponse();
            MonitoringUnit.AddJCDecauxResponseTime(reqTime, DateTime.Now);

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return JsonConvert.DeserializeObject<List<Composite_City>>(responseFromServer);
        }

        /*
         * Cette partie correspond à l'extension Cache.
         * 
         * Elle contient la classe Cache qui garde en mémoire les réponses des requêtes effectuées par le service
         * afin d'envoyer ces réponses à nouveau aux clients qui effectueraient la même requête dans un interval de temps réduit
         * dans le but de réduire le nombre de requêtes totales effectuées auprès du service de JCDecaux.
         */


        internal class Cache
        {
            private static DataTable table = null;

            public Cache()
            {
                if (table == null)
                {
                    table = new DataTable();

                    table.PrimaryKey = new[] { table.Columns.Add("Contract", typeof(string)) };
                    table.Columns.Add("Stations", typeof(List<Composite_StationVelib>));
                    table.Columns.Add("Data_Age", typeof(DateTime));
                }
            }

            public List<Composite_StationVelib> GetDataForContract(string contract)
            {
                OperationContext current = OperationContext.Current;
                MessageProperties prop = current.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

                string expression = "Contract = '" + contract + "'";
                DataRow[] result = table.Select(expression);

                if (result.Length > 0)
                {
                    if ((DateTime.Now - (DateTime)result[0][2]).TotalSeconds < 300)
                    {
                        MonitoringUnit.AddIncomingRequest(DateTime.Now, endpoint.Address, true);
                        return (List<Composite_StationVelib>)result[0][1];
                    }
                    result[0].Delete();
                }

                MonitoringUnit.AddIncomingRequest(DateTime.Now, endpoint.Address);
                MonitoringUnit.AddOutgoingRequest(DateTime.Now);

                DateTime reqTime = DateTime.Now;
                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract
                     + "&apiKey=ed75cd6d6bb24bd1427faf27eeeea43b6dd4a5b6");
                WebResponse response = request.GetResponse();
                MonitoringUnit.AddJCDecauxResponseTime(reqTime, DateTime.Now);

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();
                List<Composite_StationVelib> station_list = JsonConvert.DeserializeObject<List<Composite_StationVelib>>(responseFromServer);
                DataRow entry = table.NewRow();
                entry[0] = contract;
                entry[1] = station_list;
                entry[2] = DateTime.Now;
                table.Rows.Add(entry);

                return station_list;
            }
        }

        /*
         * Cette partie correspond à l'extension Monitoring.
         * 
         * Elle contient la classe MonitoringUnit qui garde en mémoire les requêtes effectuées par les clients
         * et par le service lui-même pour pouvoir donner de plus amples critères de sélection pour les statistiques.
         */

        public class MonitoringUnit
        {
            public static List<Request> incomingRequests = new List<Request>();
            public static List<Request> outgoingRequests = new List<Request>();
            public static List<JCDecauxResponseTime> jCDecauxResponseTimes = new List<JCDecauxResponseTime>();

            public static void AddIncomingRequest(DateTime time, string clientIp = "", bool cached = false)
            {
                incomingRequests.Add(new Request(time, clientIp, cached));
            }

            public static void AddOutgoingRequest(DateTime time, string clientIp = "", bool cached = false)
            {
                outgoingRequests.Add(new Request(time, clientIp, cached));
            }

            public static void AddJCDecauxResponseTime(DateTime req, DateTime response)
            {
                jCDecauxResponseTimes.Add(new JCDecauxResponseTime(response, response - req));
            }

            public class Request
            {
                public DateTime time;
                public string clientIp;
                public bool cached;

                public Request(DateTime time, string clientIp, bool cached)
                {
                    this.time = time;
                    this.clientIp = clientIp;
                    this.cached = cached;
                }
            }

            public class JCDecauxResponseTime
            {
                public DateTime time;
                public TimeSpan delay;

                public JCDecauxResponseTime(DateTime time, TimeSpan delay)
                {
                    this.time = time;
                    this.delay = delay;
                }
            }
        }
    }
}

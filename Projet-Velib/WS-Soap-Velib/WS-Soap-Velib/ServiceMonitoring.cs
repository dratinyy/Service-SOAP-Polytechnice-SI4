using System;
using System.Collections.Generic;
using static WS_Soap_Velib.ServiceVelib.MonitoringUnit;

namespace WS_Soap_Velib
{
    public class ServiceMonitoring : IServiceMonitoring
    {

        /*
         * Cette partie correspond à l'extension Monitoring.
         * 
         * Elle contient les méthodes du service de monitoring IServiceMonitoring qui permettent de récupérer des
         * statistiques d'utilisation du web service SOAP mis en place précedemment.
         */

        /// <summary>
        /// Permet de récupérer le nombres de clients différents(identifiés par leur adresse IP) ayant effectué des requêtes
        /// au Web Service, entre deux instants donnés.
        /// </summary>
        public int GetClientsBetweenDates(DateTime start, DateTime end)
        {
            List<string> clients = new List<string>();
            int result = 0;
            foreach (Request r in incomingRequests)
                if (DateTime.Compare(start, r.time) <= 0 && DateTime.Compare(r.time, end) < 0)
                    if (!clients.Contains(r.clientIp))
                    {
                        clients.Add(r.clientIp);
                        result++;
                    }
            return result;
        }

        /// <summary>
        /// Permet de récupérer le nombres de clients différents (identifiés par leur adresse IP) ayant effectué des requêtes
        /// au Web Service, entre deux heures données, pour tous les jours.
        /// </summary>
        public int GetClientsBetweenHours(DateTime start, DateTime end)
        {
            List<string> clients = new List<string>();
            int result = 0;
            foreach (Request r in incomingRequests)
                if (TimeSpan.Compare(start.TimeOfDay, r.time.TimeOfDay) <= 0 && TimeSpan.Compare(r.time.TimeOfDay, end.TimeOfDay) < 0)
                    if (!clients.Contains(r.clientIp))
                    {
                        clients.Add(r.clientIp);
                        result++;
                    }
            return result;
        }

        /// <summary>
        /// Permet de récupérer le nombres de requêtes différentes ayant été effectuées auprès du
        /// Web Service, entre deux instants donnés.
        /// </summary>
        public int GetClientRequestsBetweenDates(DateTime start, DateTime end)
        {
            int result = 0;
            foreach (Request r in incomingRequests)
                if (DateTime.Compare(start, r.time) <= 0 && DateTime.Compare(r.time, end) < 0)
                    result++;
            return result;
        }

        /// <summary>
        /// Permet de récupérer le nombres de requêtes différentes ayant été effectuées auprès du
        /// Web Service, entre deux heures données, pour tous les jours.
        /// </summary>
        public int GetClientRequestsBetweenHours(DateTime start, DateTime end)
        {
            int result = 0;
            foreach (Request r in incomingRequests)
                if (TimeSpan.Compare(start.TimeOfDay, r.time.TimeOfDay) <= 0 && TimeSpan.Compare(r.time.TimeOfDay, end.TimeOfDay) < 0)
                    result++;
            return result;
        }

        /// <summary>
        /// Permet de récupérer le nombres de requêtes différentes ayant été effectuées par le
        /// Web Service, auprès du Web Service JCDecaux, entre deux instants donnés.
        /// </summary>
        public int GetJCDecauxRequestsBetweenDates(DateTime start, DateTime end)
        {
            int result = 0;
            foreach (Request r in outgoingRequests)
                if (DateTime.Compare(start, r.time) <= 0 && DateTime.Compare(r.time, end) < 0)
                    result++;
            return result;
        }

        /// <summary>
        /// Permet de récupérer le nombres de requêtes différentes ayant été effectuées par le
        /// Web Service, auprès du Web Service JCDecaux, entre deux heures données pour tous les jours.
        /// </summary>
        public int GetJCDecauxRequestsBetweenHours(DateTime start, DateTime end)
        {
            int result = 0;
            foreach (Request r in outgoingRequests)
                if (TimeSpan.Compare(start.TimeOfDay, r.time.TimeOfDay) <= 0 && TimeSpan.Compare(r.time.TimeOfDay, end.TimeOfDay) < 0)
                    result++;
            return result;
        }

        /// <summary>
        /// Permet de récupérer le temps moyen de réponse du Web Service JCDecaux, entre deux instants donnés.
        /// </summary>
        public TimeSpan GetJCDecauxAverageResponseTime(DateTime start, DateTime end)
        {
            long totalTicks = 0;
            int totalTimes = 0;
            foreach (JCDecauxResponseTime responseTime in jCDecauxResponseTimes)
                if (DateTime.Compare(start, responseTime.time) <= 0 && DateTime.Compare(responseTime.time, end) < 0)
                {
                    totalTicks += responseTime.delay.Ticks;
                    totalTimes++;
                }
            return new TimeSpan((totalTimes > 0 ? totalTicks / totalTimes : 0));
        }
    }
}

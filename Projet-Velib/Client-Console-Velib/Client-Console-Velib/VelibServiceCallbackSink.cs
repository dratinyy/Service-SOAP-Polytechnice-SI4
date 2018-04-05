using System;
using Client_Console_Velib.WS_Soap_Velib_Reference;

namespace Client_Console_Velib
{
    class VelibServiceCallbackSink : IServiceVelibCallback
    {
        public void CityStationListQuery(string contract, Composite_StationVelib[] stationlist)
        {
            Console.WriteLine("Stations de  " + contract + " :");
            foreach (Composite_StationVelib s in stationlist)
                Console.WriteLine(String.Format("{0,-60} {1,3} vélos disponibles.", s.Name, s.Available_bikes));
            Console.WriteLine(contract + ", " + stationlist.Length + " stations existantes.\n");
        }

        public void CityStationListQueryFinished()
        {
            Console.WriteLine("City Station List was successfully queried!");
        }

        public void StationQuery(string contract, int station_id, Composite_StationVelib station)
        {
            Console.WriteLine("La station " + station.Name + " de " + contract + " :");
            Console.WriteLine(String.Format("Adresse :\t\t{0}\n\nVélos disponibles\t\t{1}\n\nEmplacements totaux :\t\t{2}\n", station.Address, station.Available_bikes, station.Bike_stands));
        }

        public void StationQueryFinished()
        {
            Console.WriteLine("Station Data was successfully queried!");
        }
    }
}

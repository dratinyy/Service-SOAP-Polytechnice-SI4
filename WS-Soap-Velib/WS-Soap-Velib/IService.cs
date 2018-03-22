using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WS_Soap_Velib
{
    // API KEY ed75cd6d6bb24bd1427faf27eeeea43b6dd4a5b6

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<Composite_City> GetContracts();

        [OperationContract]
        List<Composite_StationVelib> GetAllInformationForContract(string contract);

        [OperationContract]
        Composite_StationVelib GetStationInformationForContract(string contract, int station_id);
    }

    [DataContract]
    public class Composite_City
    {
        string name;
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        List<string> cities;
        [DataMember]
        public List<string> Cities
        {
            get { return cities; }
            set { cities = value; }
        }

        string commercial_name;
        [DataMember]
        public string Commercial_name
        {
            get { return commercial_name; }
            set { commercial_name = value; }
        }

        string country_code;
        [DataMember]
        public string Country_code
        {
            get { return country_code; }
            set { country_code = value; }
        }

        public override string ToString()
        {
            return name + " [" + country_code + "]";
        }
    }

    [DataContract]
    public class Composite_StationVelib
    {
        int number { get; set; }
        [DataMember]
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        string contract_name { get; set; }
        [DataMember]
        public string Contract_name
        {
            get { return contract_name; }
            set { contract_name = value; }
        }

        string name { get; set; }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string address { get; set; }
        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        Position position { get; set; }
        [DataMember]
        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        bool banking { get; set; }
        [DataMember]
        public bool Banking
        {
            get { return banking; }
            set { banking = value; }
        }

        bool bonus { get; set; }
        [DataMember]
        public bool Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        string status { get; set; }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        int bike_stands { get; set; }
        [DataMember]
        public int Bike_stands
        {
            get { return bike_stands; }
            set { bike_stands = value; }
        }

        int available_bike_stands { get; set; }
        [DataMember]
        public int Available_bike_stands
        {
            get { return available_bike_stands; }
            set { available_bike_stands = value; }
        }

        int available_bikes { get; set; }
        [DataMember]
        public int Available_bikes
        {
            get { return available_bikes; }
            set { available_bikes = value; }
        }

        string last_update { get; set; }
        [DataMember]
        public string Last_update
        {
            get { return last_update; }
            set { last_update = value; }
        }
    }

    [DataContract]
    public class Position
    {
        double lat;
        [DataMember]
        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }

        double lng;
        [DataMember]
        public double Lng
        {
            get { return lng; }
            set { lng = value; }
        }
    }
}

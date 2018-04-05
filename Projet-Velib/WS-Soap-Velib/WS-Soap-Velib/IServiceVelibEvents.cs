using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WS_Soap_Velib
{
    public interface IServiceVelibEvents
    {
        [OperationContract(IsOneWay = true)]
        void CityStationListQuery(string contract, List<Composite_StationVelib> stationlist);

        [OperationContract(IsOneWay = true)]
        void CityStationListQueryFinished();

        [OperationContract(IsOneWay = true)]
        void StationQuery(string contract, int station_id, Composite_StationVelib station);

        [OperationContract(IsOneWay = true)]
        void StationQueryFinished();
    }
}

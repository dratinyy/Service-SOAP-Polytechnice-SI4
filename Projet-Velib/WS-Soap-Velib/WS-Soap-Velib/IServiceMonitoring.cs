using System;
using System.ServiceModel;

namespace WS_Soap_Velib
{

    [ServiceContract]
    public interface IServiceMonitoring
    {
        [OperationContract]
        int GetClientsBetweenDates(DateTime start, DateTime end);

        [OperationContract]
        int GetClientsBetweenHours(DateTime start, DateTime end);

        [OperationContract]
        int GetClientRequestsBetweenDates(DateTime start, DateTime end);

        [OperationContract]
        int GetClientRequestsBetweenHours(DateTime start, DateTime end);

        [OperationContract]
        int GetJCDecauxRequestsBetweenDates(DateTime start, DateTime end);

        [OperationContract]
        int GetJCDecauxRequestsBetweenHours(DateTime start, DateTime end);

        [OperationContract]
        TimeSpan GetJCDecauxAverageResponseTime(DateTime start, DateTime end);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MathsLibrary
{

    [ServiceContract]
    public interface IMathsOperations
    {
        [OperationContract]
        int Add(int num1, int num2);

        [OperationContract]
        int Sub(int num1, int num2);

        [OperationContract]
        [FaultContract(typeof(CustomFaultDetails))]
        int Divide(int num1, int num2);

    }

    [DataContract]
    public class CustomFaultDetails
    {
        private string details;

        [DataMember]
        public string Details { get => details; set => details = value; }
    }
}

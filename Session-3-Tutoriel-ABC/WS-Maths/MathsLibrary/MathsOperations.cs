using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MathsLibrary
{
    public class MathsOperations : IMathsOperations
    {
        public int Add(int num1, int num2)
        {
            return (num1 + num2);
        }

        public int Sub(int num1, int num2)
        {
            return (num1 - num2);
        }

        public int Divide(int num1, int num2)
        {
            if (num2 == 0)
            {
                CustomFaultDetails fault = new CustomFaultDetails();
                fault.Details = "Division par Zero";
                throw new FaultException<CustomFaultDetails>(fault, "La division par zéro est proscrite !");
            }
            return (num1 / num2);
        }
    }

}

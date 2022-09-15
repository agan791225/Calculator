using CalculatorService.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.ServiceInterface
{
    public class DematicMultiply : IDematicMath
    {
        public double Calculate(Operation operation)
        {
            double result = 1;

            foreach (int addend in operation.Value)
                result *= addend;

            return result;
        }
    }
}

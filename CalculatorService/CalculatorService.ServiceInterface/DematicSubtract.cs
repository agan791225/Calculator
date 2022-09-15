using CalculatorService.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.ServiceInterface
{
    public class DematicSubtract : IDematicMath
    {
        public double Calculate(Operation operation)
        {
            double result = 0;
            int i = 0;
            foreach (int current in operation.Value)
            {
                if (i++ == 0)
                    result = current;
                else
                    result = result - current;
            }
            return result;
        }
    }
}

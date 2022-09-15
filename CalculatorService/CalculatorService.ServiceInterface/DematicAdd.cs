using CalculatorService.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.ServiceInterface
{
    public class DematicAdd : IDematicMath
    {
        double IDematicMath.Calculate(Operation operation)
        {
            double result = 0;

            foreach (int addend in operation.Value)
                result += addend;

            return result;
        }
    }
}

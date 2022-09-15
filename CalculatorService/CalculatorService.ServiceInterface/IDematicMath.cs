using CalculatorService.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.ServiceInterface
{
    public interface IDematicMath
    {
        double Calculate(Operation operation);
    }
}

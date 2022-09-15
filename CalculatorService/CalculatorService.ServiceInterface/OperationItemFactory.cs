using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.ServiceModel;

namespace CalculatorService.ServiceInterface
{
    internal static class OperationItemFactory
    {
        internal static IDematicMath Create(Operation operation)
        {
            IDematicMath dematicMath = null;
            if (operation.ID == Operator.Addition)
                dematicMath = new DematicAdd();
            else if (operation.ID == Operator.Subtraction)
                dematicMath = new DematicSubtract();
            else if (operation.ID == Operator.Multiplication)
                dematicMath = new DematicMultiply();
            else
                dematicMath = new DematicDivide();
            return dematicMath;
        }
    }
}

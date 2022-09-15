using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.ServiceModel
{
    abstract public class Operation
    {
        public List<double> Value { get; set; }

        public Operator ID { get; set; }

    }

    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        None,
    }

}

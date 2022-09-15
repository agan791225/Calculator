using ServiceStack;
using CalculatorService.ServiceModel;
using ServiceStack.Logging;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace CalculatorService.ServiceInterface
{
    public class CalculatorServices : Service
    {
        public AddResponse Any(Calculate request)
        {
            AddResponse response = new AddResponse();
            try
            {   if (request?.MyMaths?.MyOperation != null)
                {
                    DematicOperation operation = ConvertToDematicOperation(request.MyMaths.MyOperation);
                    response.Result = Calculate(operation);
                }
                else
                    response.Exception = "Invalid request.";
            }
            catch(Exception ex)
            {
                response.Exception = ex.Message;
            }
            return response;
        }

        private double Calculate(DematicOperation operation)
        {        
            IDematicMath dematicMath = OperationItemFactory.Create(operation);
            double result = dematicMath.Calculate(operation);
            if (operation.dematicOperation != null)
                return result + Calculate(operation.dematicOperation);
            else
                return result;
        }

        private DematicOperation ConvertToDematicOperation(Myoperation myoperation)
        {
            DematicOperation dematicoperation = new DematicOperation
            {
                ID = SelectOperator(myoperation.ID),
                Value = myoperation.Value?.Select(o => Convert.ToDouble(o)).ToList()
            };
            if(dematicoperation.ID == Operator.None)
                throw new InvalidOperationException("Missing the operator!");
            if (myoperation.MyOperation != null)
                dematicoperation.dematicOperation = ConvertToDematicOperation(myoperation.MyOperation);
            return dematicoperation;
        }

        private Operator SelectOperator(string id)
        {
            Operator result = Operator.None;
            if (id == "Plus")
                result = Operator.Addition;
            else if (id == "Subtraction")
                result = Operator.Subtraction;
            else if (id == "Multiplication")
                result = Operator.Multiplication;
            else if (id == "Division")
                result = Operator.Division;
            return result;
        }
    }
}
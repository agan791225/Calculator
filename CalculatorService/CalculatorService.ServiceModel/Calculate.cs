using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using ServiceStack;

namespace CalculatorService.ServiceModel
{
    [DataContract]
    [Route("/calculator/calculate/")]
    public class Calculate : IReturn<AddResponse>
    {
        public Mymaths MyMaths;
        [DataMember(Name = "MyMaths")]
        public virtual Mymaths FirstMethod
        {
            get
            {
                return this.MyMaths;
            }
            set
            {
                this.MyMaths = value;
            }
        }

        [DataMember(Name = "Maths")]
        public virtual Mymaths SecondMethod
        {
            get
            {
                return this.MyMaths;
            }
            set
            {
                this.MyMaths = value;
            }
        }
    }

    [DataContract]
    public class AddResponse
    {
        [DataMember(Name = "Result")]
        public double Result { get; set; }

        [DataMember(Name = "Exception")]
        public string Exception { get; set; }
    }

    [DataContract]
    public class Mymaths
    {
        public Myoperation MyOperation;
        [DataMember(Name = "MyOperation")]
        public virtual Myoperation FirstMethod
        {
            get
            {
                return this.MyOperation;
            }
            set
            {
                this.MyOperation= value;
            }
        }

        [DataMember(Name = "Operation")]
        public virtual Myoperation SecondMethod
        {
            get
            {
                return this.MyOperation;
            }
            set
            {
                this.MyOperation = value;
            }
        }
    }

    [DataContract]
    public class Myoperation
    {
        [DataMember(Name = "@ID")]
        public string ID { get; set; }
        [DataMember(Name = "Value")]
        public string[] Value { get; set; }
        public Myoperation MyOperation;
        [DataMember(Name = "MyOperation")]
        public virtual Myoperation FirstMethod
        {
            get
            {
                return this.MyOperation;
            }
            set
            {
                this.MyOperation = value;
            }
        }

        [DataMember(Name = "Operation")]
        public virtual Myoperation SecondMethod
        {
            get
            {
                return this.MyOperation;
            }
            set
            {
                this.MyOperation = value;
            }
        }
    }
}

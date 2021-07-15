using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Exception
{

    [Serializable]
    public class OceanException : System.Exception
    {
        public uint Value { get; }
        public OceanException() { }
        public OceanException(string msg, uint value) 
            : base(msg)
        {
            Value = value;
        }
        public OceanException(string msg, System.Exception inner) : base(msg, inner) { }
        protected OceanException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

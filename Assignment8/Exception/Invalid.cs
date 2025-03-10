using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8.Exception
{
    internal class Invalid : ApplicationException
    {
        public Invalid(string message) : base(message)
        {
            
        }
    }
}

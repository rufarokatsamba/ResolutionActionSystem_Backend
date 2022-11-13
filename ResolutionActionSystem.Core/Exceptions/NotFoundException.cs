using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name ,object key) : base($"{name} ({key} was not found")
        {

        }
        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException(string message, Exception exp) : base(message, exp)
        {

        }
    }
}
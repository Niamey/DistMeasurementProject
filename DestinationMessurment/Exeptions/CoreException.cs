using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationMessurment.Service.Core.Exeptions
{
    public  class CoreException : Exception
    {
        public CoreException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationMessurment.Service.Core.Abstraction.Clients.Models
{
    public class RestApiClientHeaderCollection : List<RestApiClientHeader>
    {
        public void Add(string name, string value)
        {
            this.Add(new RestApiClientHeader
            {
                Name = name,
                Value = value
            });
        }

    }
}

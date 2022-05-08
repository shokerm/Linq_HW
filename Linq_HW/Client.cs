using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_HW
{
    internal class Client
    {
        public string ClientName { get; set; }
        public int Orders { get; set; }

        public Agent agent;




        public Client(Agent agent)
        {
            this.agent = agent;
        }
    }
}

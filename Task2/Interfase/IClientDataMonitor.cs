using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface IClientDataMonitor
    {
        Client ViewClientData(Client client);

        Client EditeClient(Client client, string newData);
    }
}

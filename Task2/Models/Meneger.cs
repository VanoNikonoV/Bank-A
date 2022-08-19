using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Meneger:Consultant, IClientDataMonitor
    {
        public new Client ViewClientData(Client client)
        {

            Client viewClient = new Client(client.FirstName,
                                client.MiddleName,
                                client.SecondName,
                                client.Telefon,
                                client.SeriesAndPassportNumber);
            return viewClient;

        }
    }
}

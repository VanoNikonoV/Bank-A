using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Consultant : IClientDataMonitor
    {
        public Consultant() {  }
      
        public Client EditeClient(Client client, string newData)
        {
            client.Telefon = newData;

            return client;
        }

        public Client ViewClientData(Client client)
        {
            string concealmentOfSeriesAndPassportNumber = ConcealmentOfSeriesAndPassportNumber(client.SeriesAndPassportNumber);

            return client;
                    
        }

        private string ConcealmentOfSeriesAndPassportNumber(string number)
        {
            if (number.Length > 0 && number != null && number != String.Empty)
            {
                string data = number;

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < number.Length; i++)
                {
                    if (data[i] != ' ')
                    {
                        sb.Append('*');
                    }
                    else sb.Append(data[i]);
                }
                return sb.ToString();
            }

            else return "нет данных";
        }
    }

    
}

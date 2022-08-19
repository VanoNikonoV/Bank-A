using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Consultant : IClientDataMonitor
    {
        public Consultant() {  }
      
        /// <summary>
        /// Метод редактирования номера телефона
        /// </summary>
        /// <param name="client">Клент чей номер необходимо отредактировать</param>
        /// <param name="newData">Новый номер</param>
        /// <returns>Клент с новым номером</returns>
        public Client EditeClient(Client client, string newData)
        {
            client.Telefon = newData;

            return client;
        }

        /// <summary>
        /// Метод отображение информации о  клиенте
        /// </summary>
        /// <param name="client">Выбранный клиент</param>
        /// <returns>Клине с скрытыми данными</returns>
        public Client ViewClientData(Client client)
        {
            string concealmentOfSeriesAndPassportNumber = ConcealmentOfSeriesAndPassportNumber(client.SeriesAndPassportNumber);

            return client;
                    
        }
        /// <summary>
        /// Сокрыте паспортных данных клиента
        /// </summary>
        /// <param name="number">Паспорные данные</param>
        /// <returns>Скрытые данные либо "нет данных"</returns>
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

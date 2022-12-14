using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task1
{
    public class Bank
    {
        //public AccessLevel AccessLevel { get; set; } = AccessLevel.Consultant;

        private ObservableCollection<Client> clients { get; set; } 

        public Bank()
        {
            this.clients = LoadData("data.csv");
        }

        /// <summary>
        /// Загружает данные о клиентах из файла data.csv
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        private static ObservableCollection<Client> LoadData(string path)
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();

            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        while (!reader.EndOfStream)
                        {
                            string[] line = reader.ReadLine().Split('\t');

                            clients.Add(new Client(line[1], line[2], line[3], line[4], line[5]));
                        }
                    }
                    return clients;
                }
                else
                {
                    MessageBox.Show("Не найден файл с данными",
                    caption: "Ощибка в чтении данных",
                    MessageBoxButton.OK,
                    icon: MessageBoxImage.Error);

                    return clients;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), caption: "Не удалось получить данные");
                return null;
            }

        }

        /// <summary>
        /// Возвращает коллекцию клиентов, в соответсвии с уровнем доступа
        /// </summary>
        /// <param name="level">Уровень доступа</param>
        /// <returns></returns>
        public ObservableCollection<ClientForBank> GetData(AccessLevel level)
        {
            ObservableCollection<ClientForBank> temp = new ObservableCollection<ClientForBank>();

            switch (level)
            {
                case AccessLevel.Consultant:

                    foreach (Client forBank in clients)
                    {
                        temp.Add(new ClientForBank(forBank, level));
                    }
                    return temp;

                case AccessLevel.Menager:

                    foreach (Client forBank in clients)
                    {
                        temp.Add(new ClientForBank(forBank, level));
                    }
                    return temp;

                    default: return temp;
            }
        }
    }

     
}

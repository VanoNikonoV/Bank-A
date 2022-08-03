using System;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Task1

/// <summary>
/// Класс описывающий модель клиента
/// </summary>
{
    public class Client : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Статический конструктор
        private static int id;

        private static int NextID()
        {
            id++;
            return id;
        }
        static Client()
        {
            id = 0;
        }
        #endregion

        public Client() { } //для консультанта

        public Client(string firstName,string middleName, 
                      string secondName, string telefon,
                      string seriesAndPassportNumber) =>

                    (this.FirstName, this.MiddleName,
                     this.SecondName,this.Telefon,
                     this.seriesAndPassportNumber, this.ID) =

                    (firstName, middleName,
                     secondName, telefon,
                     seriesAndPassportNumber, Client.NextID());
        public Client(string firstName, string midlleName, 
                      string secondName, string telefon, 
                      string seriesAndPassportNumber, int currentId)

                      : this(firstName, midlleName, secondName, 
                             telefon, seriesAndPassportNumber) 
        {
            this.ID = currentId; 
            --id; 
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                    this.firstName = value;
                    OnPropertyChanged(nameof(FirstName));
            }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            private set
            { this.middleName = value;
                OnPropertyChanged(nameof(MiddleName)); }
        }
        public string SecondName
        {
            get { return this.secondName; }

            private set { this.secondName = value;
                  OnPropertyChanged(nameof(SecondName));}
        }
        public string Telefon
        {
            get { return this.telefon; }

            set
            {
                this.telefon = value;
                OnPropertyChanged(nameof(Telefon));
            }
        }
        public int ID { get; private set; }
        
        public virtual string SeriesAndPassportNumber
        {
            get {return this.seriesAndPassportNumber;}
            private set
            {
                this.seriesAndPassportNumber = value;
                OnPropertyChanged(nameof(SeriesAndPassportNumber));
            }
        }

        #region Поля
        string firstName;
        string secondName;  
        string middleName;
        string telefon;
        string seriesAndPassportNumber;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Переопределяю для записи данных в файл .csv
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ID.ToString() + "\t" + FirstName + "\t" + MiddleName  + "\t" + SecondName + "\t" + Telefon + "\t" + SeriesAndPassportNumber;
        }


        private string error;

        public string Error => error;

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;

                switch (columnName)
                {
                    case nameof(Telefon):


                        if (this.Telefon.Length == 0)
                        {
                            return result = "Нужно заполнить поле";
                        }

                        else if (!decimal.TryParse(this.Telefon, out decimal number))
                        {
                            return result = "Нужны числа";
                        }

                        else if (this.Telefon.Length > 11 || this.Telefon.Length < 11)
                        {
                            return result = "Номер должен состоять из 11 цифр";
                        }

                        break;
                }
                return result;
            }
        }
    }
}


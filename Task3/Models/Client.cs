using System;
using System.ComponentModel;

namespace Task3

/// <summary>
/// Класс описывающий модель клиента
/// </summary>
{
    //Расширяем и изменяем программу из задания 1 и 2.
    //У нас есть два класса для консультанта и менеджера.
    //У классов есть метод изменения данных. Исходя из этого, добавьте к данным из задания 1 дополнительные поля:
    //      дата и время изменения записи;
    //      какие данные изменены;
    //      тип изменений;
    //      кто изменил данные(консультант или менеджер).

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

        public Client() : this("Имя", "Отчество", "Фамилия", "79000000000", "66 00 000000") { --id; } //для нового клиента

        /// <summary>
        /// Вызывается при создании нового клиента
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="secondName"></param>
        /// <param name="telefon"></param>
        /// <param name="seriesAndPassportNumber"></param>
        public Client(string firstName, string middleName,
                      string secondName, string telefon,
                      string seriesAndPassportNumber) =>

                    (this.FirstName, this.MiddleName,
                     this.SecondName, this.Telefon,
                     this.SeriesAndPassportNumber, this.IsChanged, 
                     this.ID, this.DateOfEntry) =

                    (firstName, middleName,
                     secondName, telefon,
                     seriesAndPassportNumber, false, 
                     Client.NextID(), DateTime.Now);

        /// <summary>
        /// Вызывается при редактировании, перезаписывании клиента
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="secondName"></param>
        /// <param name="telefon"></param>
        /// <param name="seriesAndPassportNumber"></param>
        /// <param name="currentId"></param>
        public Client(string firstName, string middleName, 
                          string secondName, string telefon, 
                          string seriesAndPassportNumber, int currentId, 
                          bool isChanged)

                          : this(firstName, middleName, secondName, 
                                 telefon, seriesAndPassportNumber) 
            {
                this.ID = currentId; 
                --id; 
                this.DateOfEntry = DateTime.Now;
                this.IsChanged = isChanged;
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
        public string SeriesAndPassportNumber
        {
            get {return this.seriesAndPassportNumber;}
            private set
            {
                this.seriesAndPassportNumber = value;
                OnPropertyChanged(nameof(SeriesAndPassportNumber));
            }
        }

        private bool isChanged;

        public bool IsChanged 
        { 
            get { return this.isChanged; }
            set
            {
                if (isChanged == value) return;
                {
                    this.isChanged = value;
                    OnPropertyChanged(nameof(IsChanged));
                }
               
            }
        }

        public DateTime DateOfEntry { get; set; }

        public string WhatHasChanged 
        {
            get
            {
                if (IsChanged == true)
                {
                    return this.whatHasChanged;
                }
                else return this.whatHasChanged;
            }
            private set { this.whatHasChanged = value; }
        }

        private string whatHasChanged = string.Empty;
        public string WhoChangedIt { get; set; }

        #region Поля
        string firstName;
        string secondName;  
        string middleName;
        string telefon;
        string seriesAndPassportNumber;
        string error;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (propName != nameof(IsChanged))
            {
                this.IsChanged = true;

                this.WhatHasChanged = propName;
            }
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Переопределяю для записи данных в файл .csv
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ID.ToString() + "\t" 
                    + FirstName + "\t" 
                    + MiddleName  + "\t"
                    + SecondName + "\t" 
                    + Telefon + "\t" 
                    + SeriesAndPassportNumber;
        }

        /// <summary>
        /// Сообщает о наличии ощибки в поле
        /// </summary>
        public string Error => error;

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;

                error = string.Empty; 

                switch (columnName)
                {
                    case nameof(Telefon):

                        if (this.Telefon.Length == 0)
                        {
                            error = "Нужно заполнить поле";
                            return result = "Нужно заполнить поле";
                        }

                        else if (!decimal.TryParse(this.Telefon, out decimal number))
                        {
                            error = "Нужны числа";
                            return result = "Нужны числа";
                        }

                        else if (this.Telefon.Length > 11 || this.Telefon.Length < 11)
                        {
                            error = "Номер должен состоять из 11 цифр";
                            return result = "Номер должен состоять из 11 цифр";
                        }
                        break;

                    case nameof(SeriesAndPassportNumber):

                        if (this.SeriesAndPassportNumber.Length == 0)
                        {
                            error = "Нужно заполнить поле";
                            return result = "Нужно заполнить поле";
                        }
                       
                        break;

                    case nameof(FirstName):

                        if (this.FirstName.Length == 0)
                        {
                            error = "Нужно заполнить поле";
                            return result = "Нужно заполнить поле";
                        }
                        break;

                    case nameof(SecondName):

                        if (this.SecondName.Length == 0)
                        {
                            error = "Нужно заполнить поле";
                            return result = "Нужно заполнить поле";
                        }
                        break;

                    case nameof(MiddleName):

                        if (this.MiddleName.Length == 0)
                        {
                            error = "Нужно заполнить поле";
                            return result = "Нужно заполнить поле";
                        }
                        break;
                }
                return result;
            }
        }
    }
}


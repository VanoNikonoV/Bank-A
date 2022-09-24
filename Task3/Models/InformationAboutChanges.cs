using System;

namespace Task3
{
    public partial class Clients
    {
        /// <summary>
        /// Информаци об измененияих в записи о клиенте
        /// </summary>
        public class InformationAboutChanges
        {
            public InformationAboutChanges( int id_client, DateTime dateTime, 
                                            string whatChanges = "", 
                                            string typeOfChanges = "", 
                                            string whoChangedIt = "") =>
            
                (this.ID_Client, this.DateChenges, 
                this.WhatChanges, this.TypeOfChanges, 
                this.WhoChangedIt) =

                (id_client ,dateTime, whatChanges, 
                typeOfChanges, whoChangedIt);
            
            /// <summary>
            /// Дата изменения
            /// </summary>
            public DateTime DateChenges { get; set; }
            /// <summary>
            /// Какое поле измненилось
            /// </summary>
            public string WhatChanges{ get; set; }
            /// <summary>
            /// Тип изменений
            /// </summary>
            public string TypeOfChanges { get; set; }
            /// <summary>
            /// Кто произмел изменение
            /// </summary>
            public string WhoChangedIt { get; set; }
            /// <summary>
            /// ID клиента
            /// </summary>
            public int ID_Client { get; set; }
        }

    }
}

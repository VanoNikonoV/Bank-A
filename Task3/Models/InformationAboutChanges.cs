using System;

namespace Task3
{
   
        /// <summary>
        /// Информаци об измененияих в записи о клиенте
        /// </summary>
        public class InformationAboutChanges
        {
            public InformationAboutChanges( DateTime dateTime, 
                                            string whatChanges = "", 
                                            string typeOfChanges = "", 
                                            string whoChangedIt = "") =>
            
                (this.DateChenges, 
                this.WhatChanges, this.TypeOfChanges, 
                this.WhoChangedIt) =

                (dateTime, whatChanges, 
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
 
        }

    
}

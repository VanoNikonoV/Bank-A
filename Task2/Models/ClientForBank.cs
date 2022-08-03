using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ClientForBank:Client
    {
        public AccessLevel AccessLevel { get; set; } = AccessLevel.Consultant;

        public ClientForBank(Client client, AccessLevel level) : base(client.FirstName,
                                                                    client.MiddleName,
                                                                    client.SecondName,
                                                                    client.Telefon,
                                                                    client.SeriesAndPassportNumber, 
                                                                    client.ID)
        {
            this.AccessLevel = level;

        }

        public override string SeriesAndPassportNumber
        {
            get {
                    if (AccessLevel == AccessLevel.Consultant)
                    {
                        if (base.SeriesAndPassportNumber.Length > 0 &&
                            base.SeriesAndPassportNumber != null &&
                            base.SeriesAndPassportNumber != String.Empty)
                        {
                            string data = base.SeriesAndPassportNumber;

                            StringBuilder sb = new StringBuilder();

                            for (int i = 0; i < base.SeriesAndPassportNumber.Length; i++)
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
                    if (AccessLevel == AccessLevel.Menager) return base.SeriesAndPassportNumber;
                    
                    else return "уровень Бог";
                 }
        }
    }
}

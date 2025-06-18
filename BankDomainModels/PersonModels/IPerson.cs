using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankDomainModels.PersonModels
{
    internal interface IPerson
    {
        public void CreateCard();
        public void DeleteCard();
        public void ChangeFinancalNumber(string newFinancalNumber);
    }
}

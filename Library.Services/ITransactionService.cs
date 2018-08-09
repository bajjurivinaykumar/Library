using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    interface ITransactionService
    {
        void CreateTransaction();
        void DeleteTransaction();
        void DisplayTransaction();
        void CalculateFine();
        void PayBill();
        void CloseTransaction();

    }
}

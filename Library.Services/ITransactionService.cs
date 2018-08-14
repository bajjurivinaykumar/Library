using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;

namespace Library.Services
{
    interface ITransactionService
    {
        void DeleteTransaction();
        void DisplayTransaction();
        void CalculateFine();
        void PayBill();
        bool IssueBook(User u, Book b);
        bool ReturnBook(int userid, Book book);
        bool RenewBook(int UserId,Book book);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;

namespace Library.Repository
{
    public interface ITransactionRepository
    {
        bool IssueBook(User user, Book book);

    }
}

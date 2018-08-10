using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Services;

namespace Library.ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            

            BookService Bs = new BookService();
           
            var data = Bs.SearchBookByName("Harry");



        }
        
    }
}

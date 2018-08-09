﻿using Library.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Services
{
    interface IBookService
    {
         Book AddBook();
         Book ManageBooks();
         Book SearchBook();

    }
}

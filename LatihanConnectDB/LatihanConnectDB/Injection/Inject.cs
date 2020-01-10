using LatihanConnectDB.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanConnectDB.Injection
{
    class Inject
    {
        public static BookRepository ProvideBookRepository()
        {
            return new BookRepository();
        }

        public static UserController ProvideUserController()
        {
            return new UserController(ProvideBookRepository());
        }
    }
}

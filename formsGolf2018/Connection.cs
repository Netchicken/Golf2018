using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formsGolf2018
{
    //A static class doesn't need to be instantiated - just the the name of the class and the name of the method or property - only use it when you need only 1 instance
    static class Connection
    {
        //properties
        public static string ConnectionString { get; set; } =
            @"Data Source=GARY-YOGA\SQLEXPRESS;Initial Catalog=Golf;Integrated Security=True;";

    }
}

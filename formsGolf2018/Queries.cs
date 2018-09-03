using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formsGolf2018
{
    static class Queries
    {

        public static string SelectAllQuery { get; set; } = "Select * from golf";

        public static string CountMembersQuery { get; set; } = "Select count(ID) from golf";
    }
}

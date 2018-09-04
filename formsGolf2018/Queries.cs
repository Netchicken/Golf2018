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

        public static String UpdateQuery { get; set; } = "UPDATE Golf set  Title=@Title, Firstname=@Firstname, Surname=@Surname, Gender=@Gender, DOB=@DOB, Street=@Street, Suburb=@Suburb, City=@City, [Available week days]=@Available, Handicap=@Handicap  where ID = @ID";

        public static String DeleteQuery { get; set; } = "Delete Golf where ID = @ID";
        public static String InsertQuery { get; set; } = "INSERT INTO Golf (Title, Firstname, Surname, Gender, DOB, Street, Suburb, City, [Available week days], Handicap) VALUES ( @Title, @Firstname, @Surname, @Gender,  @DOB, @Street,  @Suburb, @City, @Available, @Handicap)";
    }
}

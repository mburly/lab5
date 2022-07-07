using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    public class Author : IClassModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Author()
        {

        }
        public Author(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                $"First Name: {FirstName}\n" +
                $"Surname: {Surname}\n";
        }
    }
}

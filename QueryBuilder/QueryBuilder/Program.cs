using System;
using QueryBuilder.Models;
namespace QueryBuilder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dbPath = $"{FileRoot.Root}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}data.db";
            QueryBuilder qb = new QueryBuilder(dbPath);

            Categories c = new Categories(1, "Spooky");

            List<Categories> cats = qb.ReadAll<Categories>();
            foreach(Categories cat in cats)
            {
                Console.WriteLine(cat.Name.ToString());
            }

        }
    }
}
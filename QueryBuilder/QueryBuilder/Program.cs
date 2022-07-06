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

            // Create objects to add to the database
            Categories c = new Categories(1, "Spooky");
            Categories c2 = new Categories(2, "Fantasy");
            Author a = new Author(1, "George R. R.", "Martin");
            Books b = new Books(1, "A Game of Thrones", "9780553593716", "8/1/1996", 2, 1);
            Users u = new Users(1, "burlesonmf", "3001 Moss Creek Drive", "Student", 25, "burlesonmf@etsu.edu", "4074468773");
            BooksOutOnLoan bol = new BooksOutOnLoan(1, 1, "6/1/2022", "6/15/2022", "6/24/2022", 1);

            // Add categories to database
            qb.Create(c);
            qb.Create(c2);

            // Add author to database
            qb.Create(a);

            // Add book to database
            qb.Create(b);

            // Add user to database
            qb.Create(u);

            // Log books out on loan in the database
            qb.Create(bol);

            Console.WriteLine("Categories");
            // Read all of the categories from the database into a list
            List<Categories> cats = qb.ReadAll<Categories>();
            foreach(Categories cat in cats)
            {
                Console.WriteLine(cat.Name.ToString());
            }
            Console.WriteLine();

            // Update name of category with id 1 from Spooky to Horror
            Categories c3 = new Categories(1, "Horror");
            qb.Update<Categories>(c3);

            Console.WriteLine("Categories");
            // Read all of the categories again to make sure the name updated
            List<Categories> cats2 = qb.ReadAll<Categories>();
            foreach (Categories cat in cats2)
            {
                Console.WriteLine(cat.Name.ToString());
            }
            Console.WriteLine();

            // Get information about user with id 1
            Console.WriteLine(qb.Read<Users>(1));

            // Remove category with id 1 from the database
            qb.Delete<Categories>(c3);

            // Read all of the categories one final time to see if the category was removed
            Console.WriteLine("Categories");
            List<Categories> cats3 = qb.ReadAll<Categories>();
            foreach (Categories cat in cats3)
            {
                Console.WriteLine(cat.Name.ToString());
            }
            Console.WriteLine();

            // Read the list of logs of books out on loan from the database
            List<BooksOutOnLoan> logs = qb.ReadAll<BooksOutOnLoan>();
            foreach (BooksOutOnLoan log in logs)
            {
                Console.WriteLine(log.ToString());
            }

        }
    }
}
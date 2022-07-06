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

            // Create author objects
            Author a1 = new Author(1, "George", "Martin");
            Author a2 = new Author(2, "J.K", "Johnson");

            // Add author object to database
            qb.Create<Author>(a1);
            qb.Create<Author>(a2);

            Console.WriteLine("All Authors");
            Console.WriteLine("====================");

            // Read and list all authors in the database
            List<Author> authors = qb.ReadAll<Author>();
            foreach(Author author in authors)
            {
                Console.WriteLine(author.ToString());
            }
            Console.WriteLine("====================");
            Console.WriteLine();

            // Update author name with id 2
            Author a3 = new Author(2, "J.K", "Rowling");
            qb.Update<Author>(a3);

            // Read author with id 2 from the database to make sure name changed
            Console.WriteLine(qb.Read<Author>(2).ToString());

            // Delete author with id 2
            qb.Delete<Author>(a3);


            Console.WriteLine("All Authors");
            Console.WriteLine("====================");
            // Read and list all authors again to see if author with id 2 is deleted
            List<Author> authors2 = qb.ReadAll<Author>();
            foreach (Author author in authors2)
            {
                Console.WriteLine(author.ToString());
            }
            Console.WriteLine("====================");
        }
    }
}
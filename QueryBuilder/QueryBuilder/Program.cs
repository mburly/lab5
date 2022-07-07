using System;
using Newtonsoft.Json;
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
            Author a1 = new Author("George", "Martin");
            Author a2 = new Author("J.K", "Johnson");
            Author a3 = new Author("Arthur", "Miller");
            qb.Create<Author>(a1);
            qb.Create<Author>(a2);
            qb.Create<Author>(a3);

            string outFile = $"{FileRoot.Root}{Path.DirectorySeparatorChar}authors.json";
            List<Author> authors = qb.ReadAll<Author>();
            using (StreamWriter writer = new StreamWriter(outFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, authors);
            }

            Categories c = new Categories("Fantasy");
            Books b = new Books("A Game of Thrones", "9780553593716", "8/1/1996", 7, 16);
            Books b2 = new Books("A Clash of Kings", "0553579908", "9/5/2000", 7, 16);
            Users u = new Users("burlesonmf", "3001 Moss Creek Drive", "Student", 25, "burlesonmf@etsu.edu", "4074468773");
            Users u2 = new Users("smithj", "50 Main Street", "Student", 0, "smithj@etsu.edu", "5551234567");
            BooksOutOnLoan bol = new BooksOutOnLoan(10, "6/1/2022", "6/15/2022", "6/24/2022", 11);

            qb.Create<Categories>(c);
            qb.Create<Books>(b);
            qb.Create<Books>(b2);
            qb.Create<Users>(u);
            qb.Create<Users>(u2);
            qb.Create<BooksOutOnLoan>(bol);

            string inFile = $"{FileRoot.Root}{Path.DirectorySeparatorChar}loans.json";

            using (StreamReader sr = new StreamReader(inFile))
            {
                JsonSerializer seralizer = new JsonSerializer();
                BooksOutOnLoan loan = (BooksOutOnLoan)seralizer.Deserialize(sr, typeof(BooksOutOnLoan));
                qb.Create<BooksOutOnLoan>(loan);
            }

            // Read and print the books out on loan to make sure it was added
            List<BooksOutOnLoan> loans = qb.ReadAll<BooksOutOnLoan>();
            foreach(BooksOutOnLoan loan in loans)
            {
                Console.WriteLine(loan);
            }
        }

    }
}
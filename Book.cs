using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    using System;



    public class Book
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string BookType { get; set; }
        public string ISBN { get; set; }
        public int BookQuantity { get; set; }
        public Book(string n, string a, string t, string isbn, int q = 1)
        {
            BookName = n;
            AuthorName = a;
            BookType = t;
            ISBN = isbn;
            BookQuantity = q;
        }

        public void Display()
        {
            Console.WriteLine($"Book name: {BookName}");
            Console.WriteLine($"Book type: {BookType}");
            Console.WriteLine($"Author name: {AuthorName}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Book Quantity: {BookQuantity}\n");
        }
        List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
    
}

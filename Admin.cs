using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class Admin

{
    List<Book> books = new List<Book>();
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    List<User> users = new List<User>();
    public void AddUser(User user)
    {
        users.Add(user);
    }
    public void EditBook(string bookedited, string newTitle, string newAuthor, string Type, string isbn, int Q)

    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName == bookedited)
            {
                Console.WriteLine("The old information of the book :");
                Console.WriteLine($" {books[i].BookName} : {books[i].AuthorName} : {books[i].ISBN} :{books[i].BookQuantity}\n");
                books[i].BookName = newTitle;
                books[i].AuthorName = newAuthor;
                books[i].BookType = Type;
                books[i].ISBN = isbn;
                books[i].BookQuantity = Q;
                Console.WriteLine("The new information of the book :");
                Console.WriteLine($" {books[i].BookName} : {books[i].AuthorName} : {books[i].ISBN}  :{books[i].BookQuantity}\n");
                return;
            }
        }
        Console.WriteLine("This book is either not in the library or you entered wrong title");
    }
    public void DeleteBook(string title)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName == title)
            {
                books[i].BookName = null;
                books[i].AuthorName = null;
                books[i].BookType = null;
                books[i].ISBN = null;
                books[i].BookQuantity = 0;
                Console.WriteLine("Deleted Successfully");
                return;

            }
        }
        Console.WriteLine("the book is not in the library");
    }
    public void SearchByAuthor(string author)
    {
        Console.WriteLine($"These are the available books for {author}");
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].AuthorName == author)
                books[i].Display();

        }
    }
    public void SearchByTitle(string name)
    {
        Console.WriteLine($"These are the available books that has the name {name}");
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName == name)
                books[i].Display();
        }
    }
    public void SearchByISBN(string isbn)
    {
        Console.WriteLine($"These are the available books that has the isbn {isbn}");
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].ISBN == isbn)
                books[i].Display();
        }
    }
    public void SearchByType(string type)
    {
        Console.WriteLine($"These are the available books that has the type {type}");
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookType == type)
                books[i].Display();
        }
    }
    public void CheckOut(string book, int id)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName == book)
            {
                books[i].BookQuantity = books[i].BookQuantity - 1;
            }

        }
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].UserId == id)
            {
                DateTime oneMonthBeforeExpiry = users[i].ExpiryDate.AddMonths(-1);

                if (DateTime.Today <= oneMonthBeforeExpiry)
                {
                    Console.WriteLine("There is still one month until the expiry date.");
                }
                else
                {
                    Console.WriteLine("There is less than one month until the expiry date , Please inform the user that he should return the book before this date");
                }
                users[i].QuantityBorrowed = users[i].QuantityBorrowed + 1;
                users[i].BorrowDate = DateTime.Now;
                users[i].DueDate = DateTime.Now.AddDays(14);
                Console.WriteLine("Check out is done SUCCESSFULLY!!\n");
                Console.WriteLine("The new information of the user :");
                users[i].Display();
            }
        }

    }
    public void CheckIn(string book, int id)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName == book)
            {
                books[i].BookQuantity = books[i].BookQuantity + 1;
            }

        }
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].UserId == id)
            {
                users[i].QuantityBorrowed = users[i].QuantityBorrowed - 1;
                if (users[i].QuantityBorrowed < 0)
                    users[i].QuantityBorrowed = 0;
                Console.WriteLine("The new information of the user :");
                users[i].Display();
                DateTime today = DateTime.Today;
                if (today > users[i].DueDate)
                {
                    TimeSpan calculation = DateTime.Today - users[i].DueDate;
                    int daysLate = calculation.Days;
                    decimal Penalty = daysLate * (1 / 2);
                    users[i].Penaltyy = Penalty;
                }
                else
                {
                    Console.WriteLine($"Book is returned in time and user penalties now is {users[i].Penaltyy}");
                }
                Console.WriteLine("Check in is done SUCCESSFULLY!!\n");
                
                }

            }

        }
    


    public void PayPenalty(int id)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].UserId == id)
            {
                Console.WriteLine("enter the amount you want to pay");
                decimal Amount = decimal.Parse(Console.ReadLine());
                if (users[i].Penaltyy == 0)
                {
                    Console.WriteLine("This user has no penalty");
                }
                else
                {
                    if (Amount > users[i].Penaltyy)
                    {
                        decimal change = Amount - (users[i].Penaltyy);
                        users[i].Penaltyy = users[i].Penaltyy - Amount;
                        Console.WriteLine("You have paid your penalty and also have change {0}", change);
                        users[i].Penaltyy = 0.0m;
                    }
                    else
                    {
                        users[i].Penaltyy = users[i].Penaltyy - Amount;
                        Console.WriteLine($"User new penalty amount is {users[i].Penaltyy}");
                    }
                    Console.WriteLine("Penalty is Paid SUCCESSFULLY!!\n");
                }
            }
        }
    }
}





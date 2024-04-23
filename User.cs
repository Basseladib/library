using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
   
        public class User
        {
            public int ID;
            public string Name { get; set; }
            public string PhoneNum { get; set; }
            public List<Book> BorrowedBook;
            public List<Book> BorrowedHistory;
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Penaltyy { get; set; }
        public string Privilege { get; set; }
        public DateTime ExpiryDate { get; set; }
        private int libraryCardNumber;
        public int QuantityBorrowed { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public User(int userId, string firstName, string lastName, string position, decimal penaltyy, DateTime ed, string privilege, int libraryCardNumber, int quantityBorrowed)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            ExpiryDate = ed;
            Privilege = privilege;
            LibraryCardNumber = libraryCardNumber;
            QuantityBorrowed = quantityBorrowed;
            Penaltyy = penaltyy;

        }
        int LibraryCardNumber
        {
            get
            {
                return libraryCardNumber;
            }
            set
            {
                if (value > 0)
                {
                    libraryCardNumber = value;
                }
            }
        }
        public void UserBorrow(DateTime bd, DateTime dd)
        {
            BorrowDate = bd;
            DueDate = dd;
        }
        public void Display()
        {
            Console.WriteLine($"First name :{FirstName}\n" + $"Last name :{LastName}\n" + $"Library Card Number:{libraryCardNumber}\n" + $"Library Card Expiry date: {ExpiryDate}\n" + $"penalty if any:{Penaltyy}\n" + $"privilege:{Privilege}");
            Console.WriteLine($"Quantity borrowed:{QuantityBorrowed}\n");
        }
        List<User> users = new List<User>();
        public void AddUser(User user)
        {
            users.Add(user);
        }
        /*Bassel*/
        public User(int id, string name, string phone)
            {
                ID = id;
                Name = name;
                PhoneNum = phone;
                BorrowedBook = new List<Book>();
                BorrowedHistory = new List<Book>();
            }

            public void SetBorrowedBook(Book book)
            {
                BorrowedBook.Add(book);
                BorrowedHistory.Add(book);
            }

            public void Returned(Book book)
            {
                BorrowedBook.Remove(book);
            }

            public void Info()
            {
                Console.WriteLine("CURRENTLY BORROWING:");
                foreach (var book in BorrowedBook)
                {
                    book.Display();
                }
                Console.WriteLine();
                Console.WriteLine("BORROWING HISTORY:");
                foreach (var book in BorrowedHistory)
                {
                    book.Display();
                }
            }
        }
   


}

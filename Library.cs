using System.Globalization;

namespace library
{
    class Library
    {
        static List<Book> lib = new List<Book>();
        static List<User> users = new List<User>();
        


        public static void Main(string[] args)
        {

            PopulateLibrary();
            Admin admin = new Admin();
           

            Book book1 = new Book("The fault in our", "John Green", "Romance", "DJDJ11", 5);
            Book book2 = new Book("Nine Perfect Strangers", "Liane Moriarty", "Drama", "thyr65", 7);
            Book book3 = new Book("Lucky Jim ", "Kingsley Amis", "Comedy", "emfl33", 8);
            admin.AddBook(book1);
            admin.AddBook(book2);
            admin.AddBook(book3);

            User user1 = new User(22100, "John", "Green", "student", 15.0m, DateTime.Now.AddYears(1), "drama", 6543, 0);
            User user2 = new User(2856, "Micheal", "Alferd", "student", 7.0m, DateTime.Now.AddYears(1), "comedy", 7856, 2);
            admin.AddUser(user1);
            admin.AddUser(user2);
            Console.WriteLine("HELLO TO OUR LIBRARY SYSTEM \n Are you a user or an admin?\n 1.User\n 2.Admin");

            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            if (choice == 2)
            {
                Console.WriteLine("What service do you want to do? \n 1.Add new Book\n 2.Edit Information about an existing book\n 3.Delete a book");
                Console.WriteLine(" 4.search for a book\n 5.Do a check in for book\n 6.Do a check out for a book\n 7.Pay the penalty for a user");
                int choice2 = int.Parse(Console.ReadLine());

                if (choice2 == 1)
                {
                    Console.WriteLine("Enter the title of the book");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter the Author of the book");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter the type of the book");
                    string type = Console.ReadLine();
                    Console.WriteLine("Enter the isbn of the book");
                    string isbn = Console.ReadLine();
                    Console.WriteLine("Enter number of copies of the book");
                    int copies = int.Parse(Console.ReadLine());
                    Book newBook = new Book(title, author, type, isbn, copies);
                    admin.AddBook(newBook);
                    Console.WriteLine("This Book Is Successfully Added");
                    newBook.Display();
                }

                if (choice2 == 2)
                {
                    Console.WriteLine("What is the title of the book do you want to edit");
                    string book = Console.ReadLine();
                    Console.WriteLine("Enter the new information of the book");
                    Console.WriteLine("Enter the title of the book");
                    string newTitle = Console.ReadLine();
                    Console.WriteLine("Enter the Author of the book");
                    string newAuthor = Console.ReadLine();
                    Console.WriteLine("Enter the type of the book");
                    string Type = Console.ReadLine();
                    Console.WriteLine("Enter the isbn of the book");
                    string isbn = Console.ReadLine();
                    Console.WriteLine("Enter number of copies of the book");
                    int Q = int.Parse(Console.ReadLine());
                    admin.EditBook(book, newTitle, newAuthor, Type, isbn, Q);

                }
                if (choice2 == 3)
                {
                    Console.WriteLine("What is the title of the book do you want to delte");
                    string book = Console.ReadLine();
                    admin.DeleteBook(book);

                }
                if (choice2 == 4)
                {
                    Console.WriteLine("Which method do you want to search by");
                    Console.WriteLine("1)by Title\n2)by Author\n3)by ISBN\n4)by Type");
                    int choice3 = int.Parse(Console.ReadLine());
                    if (choice3 == 1)
                    {
                        Console.WriteLine("Enter the title of the Book");
                        string title = Console.ReadLine();
                        admin.SearchByTitle(title);
                    }
                    if (choice3 == 2)
                    {
                        Console.WriteLine("Enter the Author of the Book");
                        string author = Console.ReadLine();
                        admin.SearchByAuthor(author);
                    }
                    if (choice3 == 3)
                    {
                        Console.WriteLine("Enter the ISBN of the Book");
                        string ISBN = Console.ReadLine();
                        admin.SearchByAuthor(ISBN);
                    }
                    if (choice3 == 4)
                    {
                        Console.WriteLine("Enter the Type of the Book");
                        string Type = Console.ReadLine();
                        admin.SearchByType(Type);
                    }
                    if ((choice3 != 1) && (choice3 != 2) && (choice3 != 3) && (choice3 != 4))
                    {
                        Console.WriteLine("Wrong Input");
                    }
                }
                if (choice2 == 5)
                {
                    Console.WriteLine("Enter the information of the book to be borrowed");
                    Console.WriteLine("Enter the title of the book");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter the id number of the user");
                    int id = int.Parse(Console.ReadLine());
                    admin.CheckOut(title, id);

                }
                if (choice2 == 6)
                {
                    Console.WriteLine("Enter the title of the book");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter the id number of the user");
                    int id = int.Parse(Console.ReadLine());
                    admin.CheckIn(title, id);
                }
                if (choice2 == 7)
                {
                    Console.WriteLine("Enter the id number of the user");
                    int id = int.Parse(Console.ReadLine());
                    admin.PayPenalty(id);
                }
            }
            
            else if (choice == 1)
            {

                

                /*Bassel*/
                users.Add(new User(1, "Bassel Adel", "+645312085"));
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("1. Search by book name, author name, ISBN, book type");
                    Console.WriteLine("2. All The Books");
                    Console.WriteLine("3. Return Book");
                    Console.WriteLine("4. User Info");
                    Console.WriteLine("5. Exit");
                    int choice1 = int.Parse(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            {

                                Console.Clear();
                                
                                Console.WriteLine("Enter how you want to search for you book:");
                                Console.WriteLine("1. Search by book name");
                                Console.WriteLine("2. Search by author name");
                                Console.WriteLine("3. Search by ISBN");
                                Console.WriteLine("4. Search by book type");
                                int choice3 = int.Parse(Console.ReadLine());
                                if (choice3 == 1)
                                {
                                    Console.WriteLine("Enter the book name:");
                                    string keyword = Console.ReadLine();
                                    SearchFor1(keyword);
                                    PromptBorrow(users[0]);
                                }
                                else if (choice3 == 2)
                                {
                                    Console.WriteLine("Enter the author name:");
                                    string keyword = Console.ReadLine();
                                    SearchFor2(keyword);
                                    PromptBorrow(users[0]);
                                }
                                else if (choice3 == 3)
                                {
                                    Console.WriteLine("Enter the ISBN:");
                                    string keyword = Console.ReadLine();
                                    SearchFor3(keyword);
                                    PromptBorrow(users[0]);
                                }
                                else if (choice3 == 4)
                                {
                                    Console.WriteLine("Enter the book type:");
                                    string keyword = Console.ReadLine();
                                    SearchFor4(keyword);
                                    PromptBorrow(users[0]);
                                }
                                break;
                            }
                     
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("We Currently Have:");
                                foreach (var book in lib)
                                {
                                    book.Display();
                                }
                                PromptBorrow(users[0]);
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Console.Clear();
                                users[0].Info();
                                Console.WriteLine("Type the index of the book you want to return:");
                                int r = int.Parse(Console.ReadLine()) - 1;
                                users[0].Returned(lib[r]);
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                users[0].Info();
                                Console.WriteLine();
                                break;
                            }
                        case 5:
                            {
                                exit = true;
                                break;
                            }
                        default:
                            Console.Clear();
                            Console.WriteLine("Your number was out of range\nPlease type a number from 1 to 5");
                            break;
                    }
                }
                Console.Clear();
                Console.Clear();
                Console.WriteLine("Thank You!");
            }
        }
       
        public static void PromptBorrow(User u)
            {
                Console.WriteLine("Would you like to borrow any of those? (y/n)");
                string r = Console.ReadLine();
                if (r == "y" || r == "Y")
                {
                    Console.WriteLine("Enter the book name that you want:");
                int want;
                    if (!int.TryParse(Console.ReadLine(), out want) || want < 1 || want > 100)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number between 1 and 100.");
                    // Handle the invalid input here, such as asking the user to input again.
                }
                else
                {
                    // Subtract 1 because arrays are zero-indexed
                    want -= 1;

                    // Now you can use the 'want' variable safely
                }
                u.SetBorrowedBook(lib[want]);
                }
                Console.Clear();
            }
            public static void SearchFor1(string keyword)
            {
                Console.Clear();
            string lowercaseKeyword = keyword.ToLower();
            List<Book> result1 = lib.Where(book => book.BookName.ToLower().Contains(lowercaseKeyword)).ToList();
            
            
            
            Console.WriteLine("Search Results for \"" + keyword + "\":");
                if (result1.Count == 0)
                {
                    Console.WriteLine("No matching books found.");
                }
                else
                {
                    foreach (Book book in result1)
                    {
                   
                    book.Display();
                    }
                }
        }
        public static void SearchFor2(string keyword)
        {
            Console.Clear();
            string lowercaseKeyword = keyword.ToLower();
            List<Book> result2 = lib.Where(book => book.AuthorName.ToLower().Contains(lowercaseKeyword)).ToList();
            if (result2.Count == 0)
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                foreach (Book book in result2)
                {

                    book.Display();
                }
            }
        }
        public static void SearchFor3(string keyword)
        {
            Console.Clear();
            string lowercaseKeyword = keyword.ToLower();
            List<Book> result3 = lib.Where(book => book.ISBN.ToLower().Contains(lowercaseKeyword)).ToList();
            if (result3.Count == 0)
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                foreach (Book book in result3)
                {

                    book.Display();
                }
            }
        }
        public static void SearchFor4(string keyword)
        {
            Console.Clear();
            string lowercaseKeyword = keyword.ToLower();
            List<Book> result4 = lib.Where(book => book.BookType.ToLower().Contains(lowercaseKeyword)).ToList();
            if (result4.Count == 0)
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                foreach (Book book in result4)
                {

                    book.Display();
                }
            }
        }

            public static void PopulateLibrary()
        {

            try
            {
                string[] lines = File.ReadAllLines(@"D:\oop\library\books.txt");
                for (int i = 0; i < lines.Length; i+=4)
                {
                    string t = lines[i];
                    string a = lines[i + 1];
                    string isbn = lines[i + 2];
                    string g = lines[i + 3];
                    lib.Add(new Book(t, a, g, isbn));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
            }
        }
    }
        

}

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
            public int Index { get; set; }
            public string Title { get; set; }

            public Book(string title, int i)
            {
                Index = i;
                Title = title;
            }
        }
    
}

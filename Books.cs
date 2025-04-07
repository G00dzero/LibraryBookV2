using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookV2
{
    internal class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Stocks quantity { get; set; }

        public Books(string title, string author, string genre , Stocks quantity)
        {
            Title = title;
            Author = author;
            Genre = genre;
            this.quantity = quantity;
        }

    }
}

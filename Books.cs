using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookV2
{
    internal class Books
    {
        private string v1;
        private string v2;
        private string v3;

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Stocks quantity { get; set; }
        public int DueDate { get; set; }

        public Books(string title, string author, string genre, Stocks quantity, int dueDate)
        {
            Title = title;
            Author = author;
            Genre = genre;
            this.quantity = quantity;
           this.DueDate = dueDate;
        }

        public Books(string v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }
}

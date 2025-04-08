using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookV2
{
    public class Books
    {
        private string v1;
        private string v2;
        private string v3;

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Stocks stocks { get; set; }
        public DateTime DueDate { get; set; }
        public int RentalCount { get; set; } // New property to track rental count

        public Books(string title, string author, string genre, Stocks stocks, DateTime dueDate)
        {
            Title = title;
            Author = author;
            Genre = genre;
            this.stocks = stocks;
            this.DueDate = dueDate;
            RentalCount = 0; // Initialize rental count
        }

        public Books(string v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Books other) return false;
            return Title == other.Title && Author == other.Author && DueDate == other.DueDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, DueDate);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookV2
{
    public class Stocks
    {
        public int StockID { get; set; }
        public int Quantity { get; set; }
        public Books Book { get; set; }

        public Stocks(int StockID, int Quantity, Books books)
        {
        this.StockID = StockID;
            this.Quantity = Quantity;
            this.Book = books;
        }
    }
}

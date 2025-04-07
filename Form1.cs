using Microsoft.VisualBasic;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows.Forms; // Add this using directive

namespace LibraryBookV2
{
    public partial class Form1 : Form
    {
        private List<Books> books; // Make books a class-level variable
        private Dictionary<String, bool> notifiedBooks; // Track notified books

        public Form1()
        {
            InitializeComponent();
            books = new List<Books>(); // Initialize books
            notifiedBooks = new Dictionary<String, bool>(); // Initialize notifiedBooks
            InitializeTimer();
        }

        private void loadData(List<Books> books)
        {
            DateTime dueDate = DateTime.Now.AddMinutes(2); // Set due date to 4 minutes ahead of the current time
            Books b = new Books("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", new Stocks(1, 10, null!), dueDate);
            Books b1 = new Books("To Kill a Mockingbird", "Harper Lee", "Fiction", new Stocks(2, 5, null!), dueDate);
            Books b2 = new Books("1984", "George Orwell", "Dystopian", new Stocks(3, 8, null!), dueDate);
            Books b3 = new Books("The Wizard of Oz", "Goody", "fiction", new Stocks(4, 0, null!), dueDate);
            books.Add(b);
            books.Add(b1);
            books.Add(b2);
            books.Add(b3);

            notifiedBooks = books.ToDictionary(book => book.Title, book => false); // Initialize notifiedBooks
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData(books);
            dataGridView1.DataSource = books;
            timer1.Start(); // Start the timer when the form loads
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            List<Books> booksToRemove = new List<Books>(); // List to track books to be removed

            foreach (Books book in books)
            {
                if (DateTime.Now >= book.DueDate )
                {
                    var result = MessageBox.Show($"The book '{book.Title}' is overdue.\n\nWould you like to return it?", "Book Overdue", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        booksToRemove.Add(book); // Add book to removal list
                    }
                    notifiedBooks[book.Title] = true;
                    // Mark as notified
                }
                else if (DateTime.Now >= book.DueDate.AddMinutes(-2) && DateTime.Now < book.DueDate && !notifiedBooks[book.Title])
                {
                    var result = MessageBox.Show($"The book '{book.Title}' is due soon.\n\nWould you like to return it?", "Book Due Soon", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        booksToRemove.Add(book); // Add book to removal list
                    }
                    notifiedBooks[book.Title] = true;
                    // Mark as notified
                }
            }

            // Remove books after iteration
            foreach (Books book in booksToRemove)
            {
                ReturnBook(book);
            }
        }

        private void ReturnBook(Books book)
        {
            books.Remove(book);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = books;
            notifiedBooks.Remove(book.Title);
            // Remove from notifiedBooks
        }

        private void InitializeTimer()
        {
            // Initialize and configure the timer
            timer1.Interval = 10500; // Set the interval to 1000 milliseconds (1 second)
            timer1.Tick += timer1_Tick;
        }
    }
}

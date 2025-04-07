using Microsoft.VisualBasic;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows.Forms; // Add this using directive

namespace LibraryBookV2
{
    public partial class Form1 : Form
    {
        private List<Books> books; // Make books a class-level variable
        private Dictionary<String, bool> notifiedBooks; // Track notified books
        private List<Books> returnedBooks = new List<Books>();
        public Form1()
        {
            InitializeComponent();
            books = new List<Books>(); // Initialize books
            notifiedBooks = new Dictionary<String, bool>(); // Initialize notifiedBooks
            InitializeTimer();
        }

        private void loadData(List<Books> books)
        {
            DateTime dueDate1 = new DateTime(2025, 4, 7, 19, 40, 0); // Set specific due date
            DateTime dueDate2 = new DateTime(2025, 5, 15, 18, 20, 0); // Set specific due date
            DateTime dueDate3 = new DateTime(2025, 7, 23, 16, 0, 0); // Set specific due date
            DateTime dueDate4 = new DateTime(2025, 4, 25, 8, 0, 0); // Set specific due date

            Books b = new Books("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", new Stocks(1, 10, null!), dueDate1);
            Books b1 = new Books("To Kill a Mockingbird", "Harper Lee", "Fiction", new Stocks(2, 5, null!), dueDate2);
            Books b2 = new Books("1984", "George Orwell", "Dystopian", new Stocks(3, 8, null!), dueDate3);
            Books b3 = new Books("The Wizard of Oz", "Goody", "fiction", new Stocks(4, 0, null!), dueDate4);
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
                if (DateTime.Now >= book.DueDate)
                {
                    var result = MessageBox.Show($"The book '{book.Title}' is overdue.\n\nWould you like to return it?", "Book Overdue", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    booksToRemove.Add(book); // Add book to removal list

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
            returnedBooks.Add(book); // Track returned books
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = books;
            notifiedBooks.Remove(book.Title);
        }

        private void InitializeTimer()
        {
            // Initialize and configure the timer
            timer1.Interval = 10500; // Set the interval to 1000 milliseconds (1 second)
            timer1.Tick += timer1_Tick;
        }

        private void RDInStock_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (RDInStock.Checked)
            {
                foreach (Books book in returnedBooks)
                {
                    ListViewItem item = new ListViewItem(book.Title);
                    item.SubItems.Add(book.Author);
                    item.SubItems.Add(book.Genre);
                    listView1.Items.Add(item);
                }
            }

        }

        private void RdOutOfStock_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (RdOutOfStock.Checked)
            {
                // Show books that are not due yet and sort them by due date in ascending order
                List<Books> notDueBooks = books.Where(b => b.DueDate > DateTime.Now).OrderBy(b => b.DueDate).ToList();

                foreach (Books book in notDueBooks)
                {
                    ListViewItem item = new ListViewItem(book.Title);
                    item.SubItems.Add(book.Author);
                    item.SubItems.Add(book.Genre);
                    item.SubItems.Add(book.DueDate.ToString("yyyy-MM-dd HH:mm")); // Add due date to the list view
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //selects book from data grid view and click button to return it
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Books selectedBook = (Books)dataGridView1.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Are you sure you want to return '{selectedBook.Title}'?", "Return Book", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ReturnBook(selectedBook);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to return.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //when a book is selected in listview1 and click the button, it will be added to the data grid view
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string title = selectedItem.Text;
                string author = selectedItem.SubItems[1].Text;
                string genre = selectedItem.SubItems[2].Text;

                // Prompt user to input the number of days
                string input = Interaction.InputBox("Enter the number of days until the book is due:", "Input Days", "3");
                if (int.TryParse(input, out int days))
                {
                    Books newBook = new Books(title, author, genre, new Stocks(0, 0, null!), DateTime.Now.AddDays(days));
                    books.Add(newBook);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = books;
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid number of days.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to add.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

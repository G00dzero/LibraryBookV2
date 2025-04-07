using Microsoft.VisualBasic;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryBookV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void loadData(List<Books> books)
        {
            Books b = new Books("The Great Gatsby", "F. Scott Fitzgerald", "Fiction");
            Books b1 = new Books("To Kill a Mockingbird", "Harper Lee", "Fiction");
            Books b2 = new Books("1984", "George Orwell", "Dystopian");
            Books b3 = new Books("The Wizard of Oz", "Goody", "fiction");
            books.Add(b);
            books.Add(b1);
            books.Add(b2);
            books.Add(b3);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Books> books = new List<Books>();
            loadData(books);
            dataGridView1.DataSource = books;
            timer1.Start(); // Start the timer when the form loads

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Books> books = new List<Books>();
            loadData(books);
            int Due=0;
            foreach (Books book in books)
            {
                
            }
        }
        private void InitializeTimer()
        {
            // Initialize and configure the timer
            //Timer1 = new Timer();
            timer1.Interval = 20000; // Set the interval to 5000 milliseconds (5 seconds)
            timer1.Tick += timer1_Tick;
        }
    }
}

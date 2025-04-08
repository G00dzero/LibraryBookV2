namespace LibraryBookV2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            RDInStock = new RadioButton();
            RdOutOfStock = new RadioButton();
            btnReturn = new Button();
            btnAdd = new Button();
            btnStats = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(678, 180);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 226);
            listView1.Name = "listView1";
            listView1.Size = new Size(678, 121);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Book";
            columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Author";
            columnHeader2.Width = 260;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Quantity in AStock";
            columnHeader3.Width = 260;
            // 
            // RDInStock
            // 
            RDInStock.AutoSize = true;
            RDInStock.Location = new Point(25, 353);
            RDInStock.Name = "RDInStock";
            RDInStock.Size = new Size(82, 24);
            RDInStock.TabIndex = 2;
            RDInStock.TabStop = true;
            RDInStock.Text = "In Stock";
            RDInStock.UseVisualStyleBackColor = true;
            RDInStock.CheckedChanged += RDInStock_CheckedChanged;
            // 
            // RdOutOfStock
            // 
            RdOutOfStock.AutoSize = true;
            RdOutOfStock.Location = new Point(25, 383);
            RdOutOfStock.Name = "RdOutOfStock";
            RdOutOfStock.Size = new Size(116, 24);
            RdOutOfStock.TabIndex = 3;
            RdOutOfStock.TabStop = true;
            RdOutOfStock.Text = "Out of  Stock";
            RdOutOfStock.UseVisualStyleBackColor = true;
            RdOutOfStock.CheckedChanged += RdOutOfStock_CheckedChanged;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(696, 40);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(696, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnStats
            // 
            btnStats.Location = new Point(696, 75);
            btnStats.Name = "btnStats";
            btnStats.Size = new Size(94, 29);
            btnStats.TabIndex = 6;
            btnStats.Text = "Statistics";
            btnStats.UseVisualStyleBackColor = true;
            btnStats.Click += btnStats_Click;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStats);
            Controls.Add(btnAdd);
            Controls.Add(btnReturn);
            Controls.Add(RdOutOfStock);
            Controls.Add(RDInStock);
            Controls.Add(listView1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private RadioButton RDInStock;
        private RadioButton RdOutOfStock;
        private Button btnReturn;
        private Button btnAdd;
        private Button btnStats;
        private System.Windows.Forms.Timer timer2;
    }
}

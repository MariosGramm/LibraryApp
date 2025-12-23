using LibraryForm.Model;
using LibraryForm.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LibraryForm
{
    public partial class BookSelection : Form
    {

        private List<Book> books;

        public BookSelection()
        {
            InitializeComponent();
            BookComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewCopies.CellFormatting += DataGridViewCopies_CellFormatting;
            DataGridViewCopies.CellContentClick += DataGridViewCopies_CellContentClick;
            DataGridViewCopies.CellPainting += DataGridViewCopies_CellPainting;
        }

        private void BookSelection_Load(object sender, EventArgs e)
        {

            DataGridViewButtonColumn loanBtnCol = new DataGridViewButtonColumn();
            loanBtnCol.Name = "Loan";
            loanBtnCol.Text = "Loan";
            loanBtnCol.HeaderText = "";
            loanBtnCol.UseColumnTextForButtonValue = true;
            loanBtnCol.ReadOnly = true;

            

            DataGridViewTextBoxColumn borrowerCol = new DataGridViewTextBoxColumn();
            borrowerCol.Name = "Borrower";
            borrowerCol.HeaderText = "Borrower";
            
        

            DataGridViewCopies.Columns.Add(loanBtnCol);
            DataGridViewCopies.Columns.Add(borrowerCol);


            finishBtn.Visible = false;
            DataGridViewCopies.Visible = false;
            SelectCopy.Visible = false;



            books = new List<Book>(Utils.ExcelToBookList.ΤoBookList("C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\Books.xlsx"));

            Utils.PopulateBookCopies.Populate(books);

            BookComboBox.DataSource = books;
            BookComboBox.DisplayMember = "Title";
            BookComboBox.ValueMember = "BookId";

            BookComboBox.SelectedIndex = -1;


            BookComboBox.SelectedIndexChanged += BookComboBox_SelectedIndexChanged;     //Show DataGridView


            BookComboBox.DropDownWidth = 120;
        }

        

        private void BookComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewCopies.BorderStyle = BorderStyle.None;
            DataGridViewCopies.Visible = true;
            SelectCopy.Visible = true;
            finishBtn.Visible = true;


            if (BookComboBox.SelectedItem is Book selectedBook)
            {
                DataGridViewCopies.DataSource = null;
                DataGridViewCopies.DataSource = selectedBook.Copies;

                DataGridViewCopies.Columns["CopyId"].ReadOnly = true;
                DataGridViewCopies.Columns["IsAvailable"].ReadOnly = true;
                DataGridViewCopies.Columns["LoanDate"].ReadOnly = true;
                DataGridViewCopies.Columns["ReturnDueDate"].ReadOnly = true;
                DataGridViewCopies.Columns["BookId"].ReadOnly = true;


            }
        }


        private void DataGridViewCopies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataGridViewCopies.Columns[e.ColumnIndex].Name == "Loan" && e.RowIndex >= 0)
            {
                var row = DataGridViewCopies.Rows[e.RowIndex];
                var bookCopy = row.DataBoundItem as BookCopy;

                if (bookCopy != null && !bookCopy.IsAvailable)
                {
                    DataGridViewButtonCell cell = (DataGridViewButtonCell)DataGridViewCopies.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    cell.ReadOnly = true;
                    cell.FlatStyle = FlatStyle.Flat;
                    cell.Style.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        private void DataGridViewCopies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataGridViewCopies.Columns["Loan"].Index && e.RowIndex >= 0)
            {
                BookCopy bookCopy = DataGridViewCopies.Rows[e.RowIndex].DataBoundItem as BookCopy;      //selected copy

                //No Loan - No Rental if true 
                if (bookCopy == null || !bookCopy.IsAvailable)
                {
                    return;
                }

                Book selectedBook = books.Find(b => b.BookId == bookCopy.BookId);

                //Loan 
                bookCopy.IsAvailable = false;

                bookCopy.LoanDate = DateTime.UtcNow;

                bookCopy.ReturnDueDate = DateTime.UtcNow.AddDays(7);

                DataGridViewCopies.Rows[e.RowIndex]
                    .Cells["Borrower"].ReadOnly = true;         //no editing after populated 


                //Rental
                Rental rental = new Rental()
                {
                    BookId = bookCopy.BookId,
                    CopyId = bookCopy.CopyId,
                    Title = selectedBook.Title,
                    LoanDate = (DateTime)bookCopy.LoanDate,
                    ReturnDueDate = (DateTime)bookCopy.ReturnDueDate,   
                    Borrower = DataGridViewCopies.Rows[e.RowIndex].Cells["Borrower"].Value?.ToString() ?? "No name provided"
                };

                

                //JSON Writing 
                string jsonPath = "C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\loans.json";
                List<Rental> rentals;

                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    rentals = JsonConvert.DeserializeObject<List<Rental>>(json)
                              ?? new List<Rental>();
                }
                else
                {
                    rentals = new List<Rental>();
                }

                //Adding the new rental
                rentals.Add(rental);

                //New JSON file (updated)
                string updatedJson = JsonConvert.SerializeObject(rentals, Formatting.Indented);

                File.WriteAllText(jsonPath, updatedJson);

                DataGridViewCopies.Refresh();

                //Excel Writing

                JsonToExcel.ToExcel(jsonPath);
            }
        }

        void DataGridViewCopies_CellPainting(Object sender, DataGridViewCellPaintingEventArgs e )
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)            
            {
                return;
            }

            if (e.ColumnIndex != 1)
            {
                return;
            }

            if (e.Value != null)
            {
                return;
            }

            //Paint every DataGridViewPaintPart except the ContentForeground
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~(DataGridViewPaintParts.ContentForeground));

            TextRenderer.DrawText(e.Graphics, "Enter a name", e.CellStyle.Font,
                e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

            e.Handled = true;
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

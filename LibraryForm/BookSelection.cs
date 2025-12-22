using LibraryForm.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryForm
{
    public partial class BookSelection : Form
    {
        public BookSelection()
        {
            InitializeComponent();
            BookComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewCopies.CellFormatting += DataGridViewCopies_CellFormatting;
        }

        private void BookSelection_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn loanBtnCol = new DataGridViewButtonColumn();
            loanBtnCol.Name = "Loan";
            loanBtnCol.Text = "Loan";
            loanBtnCol.HeaderText = "";
            loanBtnCol.UseColumnTextForButtonValue = true;

            DataGridViewCopies.Columns.Add(loanBtnCol);

            DataGridViewCopies.ReadOnly = true;
            DataGridViewCopies.Visible = false;
            SelectCopy.Visible = false;



            var books = new List<Book>(Utils.ExcelToBookList.ΤoBookList("C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\Books.xlsx"));

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


            if (BookComboBox.SelectedItem is Book selectedBook)
            {
                DataGridViewCopies.DataSource = null;
                DataGridViewCopies.DataSource = selectedBook.Copies; 
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

        private void DataGridViewCopies_CellContentClick(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DataGridViewCopies.Columns["Loan"].Index && e.RowIndex >= 0)
            {
                BookCopy bookCopy = DataGridViewCopies.Rows[e.RowIndex].DataBoundItem as BookCopy;      //selected copy

                //Loan
                if (bookCopy != null && bookCopy.IsAvailable)
                {

                }
            }
        }

    }
}

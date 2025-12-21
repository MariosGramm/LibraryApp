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
        }

        private void BookSelection_Load(object sender, EventArgs e)
        {
            DataGridViewCopies.Visible = false;
            SelectCopy.Visible = false;

            var books = new List<Book>(Utils.ExcelToBookList.ΤoBookList("C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\Books.xlsx"));

            Utils.PopulateBookCopies.Populate(books);

            BookComboBox.DataSource = books;
            BookComboBox.DisplayMember = "Title";
            BookComboBox.ValueMember = "BookId";

            BookComboBox.SelectedIndexChanged += BookComboBox_SelectedIndexChanged;


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

    }
}

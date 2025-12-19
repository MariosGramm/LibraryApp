using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryForm
{
    public partial class BookSelection : Form
    {
        public BookSelection()
        {
            InitializeComponent();

            Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            BookComboBox.DataSource = Utils.JsonOperations.Read().Books.ToArray();
        }
    }
}

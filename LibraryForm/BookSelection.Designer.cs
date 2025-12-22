
using System;

namespace LibraryForm
{
    partial class BookSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BookComboBox = new System.Windows.Forms.ComboBox();
            this.SelectBook = new System.Windows.Forms.Label();
            this.DataGridViewCopies = new System.Windows.Forms.DataGridView();
            this.SelectCopy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // BookComboBox
            // 
            this.BookComboBox.FormattingEnabled = true;
            this.BookComboBox.Location = new System.Drawing.Point(423, 194);
            this.BookComboBox.Name = "BookComboBox";
            this.BookComboBox.Size = new System.Drawing.Size(181, 24);
            this.BookComboBox.TabIndex = 0;
            // 
            // SelectBook
            // 
            this.SelectBook.AutoSize = true;
            this.SelectBook.Location = new System.Drawing.Point(443, 145);
            this.SelectBook.Name = "SelectBook";
            this.SelectBook.Size = new System.Drawing.Size(143, 17);
            this.SelectBook.TabIndex = 1;
            this.SelectBook.Text = "Please select a book ";
            // 
            // DataGridViewCopies
            // 
            this.DataGridViewCopies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridViewCopies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCopies.GridColor = System.Drawing.SystemColors.Control;
            this.DataGridViewCopies.Location = new System.Drawing.Point(121, 356);
            this.DataGridViewCopies.Name = "DataGridViewCopies";
            this.DataGridViewCopies.RowHeadersWidth = 51;
            this.DataGridViewCopies.RowTemplate.Height = 24;
            this.DataGridViewCopies.Size = new System.Drawing.Size(820, 276);
            this.DataGridViewCopies.TabIndex = 2;
            // 
            // SelectCopy
            // 
            this.SelectCopy.AutoSize = true;
            this.SelectCopy.Location = new System.Drawing.Point(462, 314);
            this.SelectCopy.Name = "SelectCopy";
            this.SelectCopy.Size = new System.Drawing.Size(93, 17);
            this.SelectCopy.TabIndex = 3;
            this.SelectCopy.Text = "Select a copy";
            // 
            // BookSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 718);
            this.Controls.Add(this.SelectCopy);
            this.Controls.Add(this.DataGridViewCopies);
            this.Controls.Add(this.SelectBook);
            this.Controls.Add(this.BookComboBox);
            this.Name = "BookSelection";
            this.Text = "Book Selection";
            this.Load += new System.EventHandler(this.BookSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BookComboBox;
        private System.Windows.Forms.Label SelectBook;
        private System.Windows.Forms.DataGridView DataGridViewCopies;
        private System.Windows.Forms.Label SelectCopy;
    }
}


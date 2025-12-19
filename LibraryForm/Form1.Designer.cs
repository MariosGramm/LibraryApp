
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
            this.SuspendLayout();
            // 
            // BookComboBox
            // 
            this.BookComboBox.FormattingEnabled = true;
            this.BookComboBox.Location = new System.Drawing.Point(331, 231);
            this.BookComboBox.Name = "BookComboBox";
            this.BookComboBox.Size = new System.Drawing.Size(121, 24);
            this.BookComboBox.TabIndex = 0;
            // 
            // SelectBook
            // 
            this.SelectBook.AutoSize = true;
            this.SelectBook.Location = new System.Drawing.Point(319, 187);
            this.SelectBook.Name = "SelectBook";
            this.SelectBook.Size = new System.Drawing.Size(143, 17);
            this.SelectBook.TabIndex = 1;
            this.SelectBook.Text = "Please select a book ";
            // 
            // BookSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectBook);
            this.Controls.Add(this.BookComboBox);
            this.Name = "BookSelection";
            this.Text = "Book Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BookComboBox;
        private System.Windows.Forms.Label SelectBook;

        
    }
}


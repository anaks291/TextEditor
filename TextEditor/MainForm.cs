using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{

    public interface IMainForm
    {
        string FilePath { get; }       
        string Content { get; set; }   
        void SetSimbolCount(int count); 
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChaiged;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            butOpenFile.Click += ButOpenFile_Click;
            butSaveFile.Click += ButSaveFile_Click;
            fldContent.TextChanged += FldContent_TextChanged;
            butSelectFile.Click += ButSelectFile_Click;
            numFont.ValueChanged += NumFont_ValueChanged;
        }
        #region Собственный код формы
        private void NumFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font = new Font("Calibri", (float)numFont.Value);
        }

        private void ButSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текствые файлы | *.txt | Все файлы | *.* ";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;

                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Проброс Событий
        private void FldContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChaiged != null) ContentChaiged(this, EventArgs.Empty);
        }

        private void ButSaveFile_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }

        private void ButOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }
        #endregion

        #region IMainForm
        public string Content
        {
            get { return fldContent.Text; }
            set { fldContent.Text = value; }           
        }

        public string FilePath
        {
            get { return fldFilePath.Text; }            
        }


        public void SetSimbolCount(int count)
        {
            lblSymbolCount.Text = count.ToString();
        }       


        public event EventHandler ContentChaiged;
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;

        #endregion


    }
}

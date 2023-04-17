using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Notepad
{
    public partial class Notepad : Form
    {
        string filePath = "";
        Color currentColor;
        int saveStat = 0;
        
        public Notepad(string name = "Notepad")
        {
            InitializeComponent();
            currentColor = richBox.SelectionBackColor;

        }

        private void Notepad_Load(object sender, EventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveStat < 1)
            {
                Save_Warning f2 = new Save_Warning(this.Text, filePath, this);
                f2.ShowDialog();
                saveStat = f2.getSaveStat();
            }
            if (saveStat == 1 || saveStat == -1)
            {
                filePath = "";
                SaveStatus.Text = "Not Saved";
                richBox.Text = "";
                this.Text = "Untitled";
                saveStat = -1;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true, Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using(StreamReader str=new StreamReader(ofd.FileName))
                    {
                        filePath = ofd.FileName;
                        String[] args = ofd.FileName.Split('\\');
                        this.Text= args[args.Length - 1];
                        SaveStatus.Text = "Saved";
                        saveStat = 1;
                        Task<string> text = str.ReadToEndAsync();
                        richBox.Text = text.Result;
                        richBox.SelectionStart = richBox.Text.Length;
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter strw = new StreamWriter(sfd.FileName))
                        {
                            strw.WriteLineAsync(richBox.Text);
                            filePath = sfd.FileName;
                           
                            String[] args = sfd.FileName.Split('\\');
                            this.Text = args[args.Length - 1];
                            SaveStatus.Text = "Saved";
                            saveStat = 1;
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLineAsync(richBox.Text); 
                    SaveStatus.Text = "Saved";
                    saveStat = 1;
                }
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter strw = new StreamWriter(sfd.FileName))
                    {
                        strw.WriteLineAsync(richBox.Text);
                    }
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.Undo();
            SaveStatus.Text = "Not Saved";
            saveStat = -1;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            richBox.Font = richBox.Font;
            richBox.BackColor = richBox.BackColor;
            richBox.SelectionBackColor = currentColor;

            if(saveStat == 1)
            {
                SaveStatus.Text = "Saved";
                saveStat = -1;
            }
            else
            {
                SaveStatus.Text = "Not Saved";
            }

            if (richBox.Text.Length > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.Redo();
            SaveStatus.Text = "Not Saved";
            saveStat = -1;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.SelectedText = "";
            SaveStatus.Text = "Not Saved";
            saveStat = -1;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.Cut();
            SaveStatus.Text = "Not Saved";
            saveStat = -1;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.SelectAll();
            saveStat = -1;
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.Text += System.DateTime.Today.ToLongDateString();
            richBox.SelectionStart = richBox.Text.Length;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(wordWrapToolStripMenuItem.Checked== true)
            {
                wordWrapToolStripMenuItem.Checked = false;
                richBox.WordWrap = false;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = true;
                richBox.WordWrap = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richBox.SelectionFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
        }

        private void changeTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richBox.ForeColor = colorDialog1.Color;
        }

        private void changeAppBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richBox.BackColor = colorDialog1.Color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/c start https://github.com/cristinel24/notepad");
        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richBox.SelectionBackColor = Color.DarkBlue;
        }

        private void newNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad other = new Notepad();
            other.ShowDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find_Window f = new Find_Window(this);
            f.Show();
        }
    }
}

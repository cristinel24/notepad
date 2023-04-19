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

namespace Notepad
{
    public partial class Save_Warning : Form
    {
        string filePath;
        Notepad parent;
        int saveStat = 0;
        public Save_Warning(string name, string path, Notepad n)
        {
            InitializeComponent();
            label2.Text = name + "?";
            filePath = path;
            parent = n;
        }

        public int getSaveStat()
        {
            return saveStat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter strw = new StreamWriter(sfd.FileName))
                        {
                            strw.WriteLineAsync(parent.richBox.Text);
                            filePath = sfd.FileName;
                            saveStat = 1;
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLineAsync(parent.richBox.Text);
                    saveStat = 1;
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            saveStat = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            saveStat = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Find_Window : Form
    {
        Notepad parent;
        static int instances = 0;
        int lastIndex = 0;
        public Find_Window(Notepad n)
        {
            InitializeComponent();
            parent = n;
            instances++;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lastIndex = parent.richBox.Text.IndexOf(find_box.Text);
            if (lastIndex < parent.richBox.Text.Length)
            {
                parent.richBox.SelectionStart = lastIndex;
                parent.richBox.SelectionLength = find_box.Text.Length;
                parent.richBox.Focus();
            }

        }
        private void Find_FormClosing(object sender, FormClosingEventArgs e)
        {
            instances--;
        }
        public int getInstances()
        {
            return instances;
        }
    }
}

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
    public partial class EnterValue : Form
    {
        Notepad parent = null;
        public EnterValue(Notepad n)
        {
            InitializeComponent();
            change_box.Focus();
            change_box.Text += '%';
            parent = n;
        }

        private bool check(String buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
                if (!(buffer[i] >= '0' && buffer[i] <= '9'))
                    return false;

            return true;
        }
        private double toNumber(String buffer)
        {
            int number = 0;
            for (int i = 0; i < buffer.Length; i++)
                number = number * 10 + buffer[i] - '0';

            return number;
        }

        private void change_box_TextChanged(object sender, EventArgs e)
        {
           if(change_box.Text.Length > 0 && change_box.Text[change_box.Text.Length - 1 ] != '%' && change_box.Text[change_box.Text.Length - 1] != '!')
                change_box.Text += '%';
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter) && (change_box.Focused || change_button.Focused))
            {
                this.change_button_Click(this, EventArgs.Empty);
                return true;
            }
           
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            string to_check = change_box.Text;
            if (change_box.Text.Length > 0 && change_box.Text[change_box.Text.Length - 1] == '%') to_check = change_box.Text.Substring(0, change_box.Text.Length - 1);

            if (check(to_check))
            {
                parent.Opacity = toNumber(to_check) / 100.00;
                this.Close();
            }
            else
            {
                change_box.Focus();
                change_box.Text = "Invalid Value!";
                change_box.SelectAll();
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

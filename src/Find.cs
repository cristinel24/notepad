using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Notepad
{
    public partial class Find_Window : Form
    {
        Notepad parent;
        static int instances = 0;
        int lastIndex = 0, list_itearator = 0;
        public Find_Window(Notepad n)
        {
            InitializeComponent();
            parent = n;
            instances++;
        }
        ~Find_Window()
        {
            instances = 0;
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                this.button1_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public static string[] FindWordsMatchingPattern(string input, string pat, RegexOptions options = RegexOptions.None)
        {
            string pattern = pat;
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            string[] results = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                results[i] = matches[i].Value;
            }

            return results;
        }

        public List<int> FindWordIndices(string input, string pat, RegexOptions options = RegexOptions.None)
        {
            string pattern = pat;
            MatchCollection matches = Regex.Matches(input, pattern, options);

            List<int> indices = new List<int>();
           
            foreach (Match match in matches)
            {
                indices.Add(match.Index);
            }

            return indices;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Find";
            List<int> indicies = null;
            String[] matches = null;
            //No check
            if (!matchCase.Checked && !WholeWord.Checked)
            {
                indicies = FindWordIndices(parent.richBox.Text.ToLower(), $"{find_box.Text}", RegexOptions.IgnoreCase);
                matches = FindWordsMatchingPattern(parent.richBox.Text.ToLower(), $"{find_box.Text}", RegexOptions.IgnoreCase);
            }
            //Match Check
            if (matchCase.Checked && !WholeWord.Checked)
            {
                indicies = FindWordIndices(parent.richBox.Text, @$"\b\w*{find_box.Text}\w*\b");
                matches = FindWordsMatchingPattern(parent.richBox.Text, @$"\b\w*{find_box.Text}\w*\b");                
            }
            //Whole Word
            if (!matchCase.Checked && WholeWord.Checked)
            {
                indicies = FindWordIndices(parent.richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.IgnoreCase);
                matches = FindWordsMatchingPattern(parent.richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.IgnoreCase);
            }


            //Match Check && Whole Word
            if (matchCase.Checked && WholeWord.Checked)
            {
                indicies = FindWordIndices(parent.richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.None);
                matches = FindWordsMatchingPattern(parent.richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.None);
            }

            if (matches.Length == 0 && indicies.Count == 0)
            {
                this.Text = "Find - No result!";
                return;
            }

            if (list_itearator < 0 || list_itearator >= indicies.Count) list_itearator = 0;
            if (indicies.Count > 0)
            {
                lastIndex = indicies[list_itearator++];
                parent.richBox.SelectionStart = lastIndex++;
                parent.richBox.SelectionLength = matches[list_itearator - 1].Length;
            }

            parent.Focus();
        }

        private void find_replace_button_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/c start https://github.com/cristinel24/notepad#Regular_Expressions");
        }

        private void highlight_button_Click(object sender, EventArgs e)
        {
            this.Text = "Find";
            List<int> indicies = null;
            String[] matches = null;
            list_itearator = 0;
            lastIndex = 0;
            while (true)
            {
                //No check
                if (!matchCase.Checked && !WholeWord.Checked)
                {
                    indicies = FindWordIndices(parent.richBox.Text.ToLower(), $"{find_box.Text}", RegexOptions.IgnoreCase);
                    matches = FindWordsMatchingPattern(parent.richBox.Text.ToLower(), $"{find_box.Text}", RegexOptions.IgnoreCase);
                }
                //Match Check
                if (matchCase.Checked && !WholeWord.Checked)
                {
                    indicies = FindWordIndices(parent.richBox.Text, @$"\b\w*{find_box.Text}\w*\b");
                    matches = FindWordsMatchingPattern(parent.richBox.Text, @$"\b\w*{find_box.Text}\w*\b");
                }
                //Whole Word
                if (!matchCase.Checked && WholeWord.Checked)
                {
                    indicies = FindWordIndices(parent.richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.IgnoreCase);
                    matches = FindWordsMatchingPattern(parent.richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.IgnoreCase);
                }


                //Match Check && Whole Word
                if (matchCase.Checked && WholeWord.Checked)
                {
                    indicies = FindWordIndices(parent.richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.None);
                    matches = FindWordsMatchingPattern(parent.richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.None);
                }

                if (matches.Length == 0 && indicies.Count == 0)
                {
                    this.Text = "Find - No result!";
                    return;
                }

                if (list_itearator < 0 || list_itearator >= indicies.Count) break;
                if (indicies.Count > 0)
                {
                    lastIndex = indicies[list_itearator++];
                    parent.richBox.SelectionStart = lastIndex++;
                    parent.richBox.SelectionLength = matches[list_itearator - 1].Length;
                    parent.richBox.SelectionBackColor = parent.currentHighlightColor;
                }
            }

            parent.Focus();
        }

        public int getInstances()
        {
            return instances;
        }
    }
}

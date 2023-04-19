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
using System.Text.RegularExpressions;

namespace Notepad
{
    public partial class Notepad : Form
    {
        private string filePath = "";
        private Color currentColor;
        private int saveStat = 0, list_iterator = 0, lastIndex = 0, count = -1;
        protected Color currentBackColor = Color.FromArgb(39,39,39), currentForeColor=Color.Black, currentHighlightColor=Color.DarkBlue, currentHighlighttextColor = Color.White;
        private bool mouseDown = false, fromSave = false, fromOpen = false;
        private Point offset;

        public Notepad(string name = "Notepad")
        {
            InitializeComponent();
            currentColor = richBox.SelectionBackColor;
            panel1.SendToBack();
            siticoneShadowForm1.SetShadowForm(this);
        }

        private const int grip = 6;

        private const int caption = 40;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point p = new Point(m.LParam.ToInt32());
                p = this.PointToClient(p);
                if (p.Y <= caption && p.Y >= grip)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (p.X >= this.ClientSize.Width - grip && p.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
                if (p.X <= grip && p.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)16;
                    return;
                }
                if (p.X <= grip)
                {
                    m.Result = (IntPtr)10;
                    return;
                }
                if (p.X >= ClientSize.Width - grip)
                {
                    m.Result = (IntPtr)11;
                    return;
                }
                if (p.Y <= grip)
                {
                    m.Result = (IntPtr)12;
                    return;
                }
                if (p.Y >= this.ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)15;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveStatus.Text == "Not Saved")
            {
                Save_Warning f2 = new Save_Warning(TitleBox.Text, filePath, this);
                f2.ShowDialog();
                saveStat = f2.getSaveStat();
            }
            if (saveStat == 1 || saveStat == -1)
            {
                filePath = "";
                SaveStatus.Text = "Not Saved";
                richBox.Text = "";
                TitleBox.Text = "Untitled";
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
                        TitleBox.Text= args[args.Length - 1];
                        SaveStatus.Text = "Saved";
                        saveStat = 1;
                        fromOpen = true;
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
                            fromSave = true;
                            String[] args = sfd.FileName.Split('\\');
                            TitleBox.Text = args[args.Length - 1];
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
            //if(scrollbar != null) scrollbar.ContextMenuStrip.BackColor = currentBackColor;

           


            richBox.Font = richBox.Font;
            richBox.BackColor = richBox.BackColor;
            richBox.SelectionBackColor = currentColor;

            if (fromSave || fromOpen)
            {
                SaveStatus.Text = "Saved";
                saveStat = -1;
                if (fromSave) fromSave = false;
                if (fromOpen) fromOpen = false;
            } 
            else
            {
                SaveStatus.Text = "Not Saved";
                saveStat = -1;
            }

            if (richBox.Text.Length > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = true;
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
            SaveStatus.Text = "Not Saved";
            saveStat = -1;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richBox.SelectedText != "")
            {
                richBox.SelectedText = "";
            }
            else if(richBox.SelectionLength == 0 && richBox.SelectionStart < richBox.Text.Length)
            {
                richBox.SelectionLength = 1;
                richBox.SelectedText = "";
                richBox.SelectionLength = 0;
            }

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
           if(richBox.SelectedText!="") richBox.SelectionFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
           else richBox.Font = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
        }

        private void changeTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richBox.ForeColor = colorDialog1.Color;
            currentForeColor = colorDialog1.Color;
        }

        private void changeAppBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richBox.BackColor = colorDialog1.Color;
            currentBackColor = colorDialog1.Color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var process = new Process();

            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                ArgumentList =  {"/c start https://github.com/cristinel24/notepad" },
                FileName = "cmd"
            };
            process.StartInfo = startInfo;
            process.Start();
        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richBox.SelectionBackColor == currentHighlightColor)
                richBox.SelectionBackColor = currentBackColor;
            else richBox.SelectionBackColor = currentHighlightColor;
        }

        private void newNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var info = new ProcessStartInfo(Application.ExecutablePath);
            Process.Start(info);
        }

        private void changeHighlightTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richBox.SelectionColor = colorDialog1.Color;
            currentHighlighttextColor = colorDialog1.Color;
        }

        private void find_box_TextChanged(object sender, EventArgs e)
        {
 
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter) && find_box.Focused)
            {
                this.button1_Click(this, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Enter) && find_box_replace.Focused)
            {
                this.button4_Click(this, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Enter) && replace_box.Focused)
            {
                count = 0;
                this.button4_Click(this, EventArgs.Empty);
                replace_box.Focus();
                this.replace_button_Click(this, EventArgs.Empty);
                count = -1;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MatchCollection matches = null;

            try
            {
                if (find_box.Text == "") return;
                //No check
                if (!matchCase.Checked && !WholeWord.Checked) matches = Regex.Matches(richBox.Text.ToLower(), @$"{find_box.Text}", RegexOptions.IgnoreCase);

                //Match Check
                if (matchCase.Checked && !WholeWord.Checked) matches = Regex.Matches(richBox.Text, @$"{find_box.Text}", RegexOptions.None);

                //Whole Word
                if (!matchCase.Checked && WholeWord.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.IgnoreCase);

                //Match Check && Whole Word
                if (matchCase.Checked && WholeWord.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.None);
            }
            catch (Exception) { }

            if (matches != null)
            {
                if (list_iterator < 0 || list_iterator >= matches.Count) list_iterator = 0;
                richBox.SelectionLength = 0; ;
                if (matches.Count > 0)
                {
                    lastIndex = matches[list_iterator++].Index;
                    richBox.SelectionStart = lastIndex++;
                    richBox.SelectionLength = matches[list_iterator - 1].Length;
                }
                richBox.Focus();
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (find_panel.Visible)
            {
                find_panel.Visible = false;
                find_panel.Enabled = false;
            }

            if (replace_panel.Visible)
            {
                replace_panel.Visible = false;
                replace_panel.Enabled = false;
            }
            else
            {
                replace_panel.Visible = true;
                replace_panel.Enabled = true;
                replace_panel.Focus();
                find_box_replace.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (find_box_replace.Text == "") return;
            MatchCollection matches = null;

            try
            {
                //No check
                if (!matchCase2.Checked && !WholeWord2.Checked) matches = Regex.Matches(richBox.Text.ToLower(), @$"{find_box_replace.Text}", RegexOptions.IgnoreCase);

                //Match Check
                if (matchCase2.Checked && !WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"{find_box_replace.Text}", RegexOptions.None);

                //Whole Word
                if (!matchCase2.Checked && WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box_replace.Text}\b", RegexOptions.IgnoreCase);

                //Match Check && Whole Word
                if (matchCase2.Checked && WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box_replace.Text}\b", RegexOptions.None);
            }
            catch (Exception err) { };

            if (matches != null)
            {
                foreach (Match match in matches)
                {
                    richBox.SelectionStart = match.Index;
                    richBox.SelectionLength = match.Length;
                    richBox.SelectionBackColor = currentHighlightColor;
                }
                richBox.SelectionLength = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (count == 0) list_iterator = count;
            if (find_box_replace.Text == "") return;

            MatchCollection matches = null;
            try
            {
                //No check
                if (!matchCase2.Checked && !WholeWord2.Checked) matches = Regex.Matches(richBox.Text.ToLower(), @$"{find_box_replace.Text}", RegexOptions.IgnoreCase);

                //Match Check
                if (matchCase2.Checked && !WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"{find_box_replace.Text}", RegexOptions.None);

                //Whole Word
                if (!matchCase2.Checked && WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box_replace.Text}\b", RegexOptions.IgnoreCase);

                //Match Check && Whole Word
                if (matchCase2.Checked && WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box_replace.Text}\b", RegexOptions.None);

            }
            catch (Exception) { }


            if (matches != null)
            {
                if (list_iterator < 0 || list_iterator >= matches.Count) list_iterator = 0;
                richBox.SelectionLength = 0;
                if (matches.Count > 0)
                {
                    lastIndex = matches[list_iterator++].Index;
                    richBox.SelectionStart = lastIndex++;
                    richBox.SelectionLength = matches[list_iterator - 1].Length;
                }
                richBox.Focus();
            }

           
        }

        private void replace_button_Click(object sender, EventArgs e)
        {
            if (richBox.SelectedText == "") return;
            richBox.SelectedText = replace_box.Text;
            richBox.SelectionStart = richBox.SelectionStart;
            richBox.SelectionLength = replace_box.Text.Length;
        }

        private void replace_all_button_Click(object sender, EventArgs e)
        {
            if (find_box_replace.Text == "") return;
            list_iterator = 0;
            lastIndex = 0;

            MatchCollection matches = null;

            try
            {
                //No check
                if (!matchCase2.Checked && !WholeWord2.Checked) matches = Regex.Matches(richBox.Text.ToLower(), @$"{find_box_replace.Text}", RegexOptions.IgnoreCase);

                //Match Check
                if (matchCase2.Checked && !WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"{find_box_replace.Text}", RegexOptions.None);

                //Whole Word
                if (!matchCase2.Checked && WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box_replace.Text}\b", RegexOptions.IgnoreCase);

                //Match Check && Whole Word
                if (matchCase2.Checked && WholeWord2.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box_replace.Text}\b", RegexOptions.None);
            }
            catch (Exception err) { };

            if(matches != null)
            {
                if (list_iterator < 0 || list_iterator >= matches.Count) list_iterator = 0;
                richBox.SelectionLength = 0;

                for (int i = 0; i < matches.Count; i++)
                {
                    richBox.SelectionStart = matches[i].Index + i * (matches[i].Length - find_box_replace.Text.Length);
                    richBox.SelectionLength = matches[i].Length;
                    richBox.SelectedText = replace_box.Text;
                }
            }
            
        }

        private void mouseDown_event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_event(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.WindowState = FormWindowState.Normal;
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseUp_event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void mouseDoubleClick_event(object sender, MouseEventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else this.WindowState = FormWindowState.Maximized;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public enum TextAlign
        {
            Left = 0,
            Right = 1,
            Center = 2,
            Justify = 3,
            CenterJustify = 4
        }

        private void left_indent_button_Click(object sender, EventArgs e)
        {
            richBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void center_indent_button_Click(object sender, EventArgs e)
        {
            richBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void right_indent_button_Click(object sender, EventArgs e)
        {
            richBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richBox.SelectionFont.Bold)
                richBox.SelectionFont = new Font(richBox.Font.FontFamily, richBox.Font.Size, richBox.SelectionFont.Style & ~FontStyle.Bold);
            else richBox.SelectionFont = new Font(richBox.Font.FontFamily, richBox.Font.Size, richBox.SelectionFont.Style | FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richBox.SelectionFont.Italic)
                richBox.SelectionFont = new Font(richBox.Font.FontFamily, richBox.Font.Size, richBox.SelectionFont.Style & ~FontStyle.Italic);
            else richBox.SelectionFont = new Font(richBox.Font.FontFamily, richBox.Font.Size, richBox.SelectionFont.Style | FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richBox.SelectionFont.Underline)
                richBox.SelectionFont = new Font(richBox.Font.FontFamily, richBox.Font.Size, richBox.SelectionFont.Style & ~FontStyle.Underline);
            else richBox.SelectionFont = new Font(richBox.Font.FontFamily, richBox.Font.Size, richBox.SelectionFont.Style | FontStyle.Underline);
        }

        private void strikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richBox.SelectionFont.Strikeout)
                richBox.SelectionFont = new Font(richBox.Font.FontFamily, richBox.Font.Size, richBox.SelectionFont.Style & ~FontStyle.Strikeout);
            else richBox.SelectionFont = new Font(richBox.Font.FontFamily, richBox.Font.Size, richBox.SelectionFont.Style | FontStyle.Strikeout);
        }

        private void replace_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void find_box_replace_TextChanged(object sender, EventArgs e)
        {

        }

        private void mouseLeave_event(object sender, EventArgs e)
        {
            mouseDown = false;
        }

        private void changeOpacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterValue opacity = new EnterValue(this);
            opacity.ShowDialog();
        }


        private void how_to_use_reg_button_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/c start https://github.com/cristinel24/notepad#Regular_Expressions");
        }

        private void find_replace_button_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/c start https://github.com/cristinel24/notepad#Regular_Expressions");
        }

        private void highlight_button_Click(object sender, EventArgs e)
        {
            if (find_box.Text == "") return;
           
            list_iterator = 0;
            lastIndex = 0;
            MatchCollection matches = null;

            try
            {
                //No check
                if (!matchCase.Checked && !WholeWord.Checked) matches = Regex.Matches(richBox.Text.ToLower(), @$"{find_box.Text}", RegexOptions.IgnoreCase);

                //Match Check
                if (matchCase.Checked && !WholeWord.Checked) matches = Regex.Matches(richBox.Text, @$"{find_box.Text}", RegexOptions.None);

                //Whole Word
                if (!matchCase.Checked && WholeWord.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.IgnoreCase);

                //Match Check && Whole Word
                if (matchCase.Checked && WholeWord.Checked) matches = Regex.Matches(richBox.Text, @$"\b{find_box.Text}\b", RegexOptions.None);
            }
            catch (Exception) { }

            if(matches != null)
            {
                foreach (Match match in matches)
                {
                    richBox.SelectionStart = match.Index;
                    richBox.SelectionLength = match.Length;
                    richBox.SelectionBackColor = currentHighlightColor;
                }
                richBox.SelectionLength = 0;
            }

        }


        private void changeHighlightColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richBox.SelectionBackColor = colorDialog1.Color;
            currentHighlightColor = colorDialog1.Color;
        } 
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (replace_panel.Visible)
            {
                replace_panel.Visible = false;
                replace_panel.Enabled = false;
            }

            if (find_panel.Visible == false)
            {
                find_panel.Visible = true;
                find_panel.Enabled = true;
                find_panel.Focus();
                find_box.Focus();
            }
            else
            {
                find_panel.Visible = false;
                find_panel.Enabled = false;
            }
        }
    }

   
}

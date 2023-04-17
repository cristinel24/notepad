
namespace Notepad
{
    partial class Find_Window
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
            this.find_box = new System.Windows.Forms.RichTextBox();
            this.matchCase = new System.Windows.Forms.CheckBox();
            this.WholeWord = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.highlight_button = new System.Windows.Forms.Button();
            this.find_replace_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // find_box
            // 
            this.find_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.find_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.find_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.find_box.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.find_box.ForeColor = System.Drawing.Color.White;
            this.find_box.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.find_box.Location = new System.Drawing.Point(5, 5);
            this.find_box.Multiline = false;
            this.find_box.Name = "find_box";
            this.find_box.Size = new System.Drawing.Size(255, 38);
            this.find_box.TabIndex = 0;
            this.find_box.Text = "";
            // 
            // matchCase
            // 
            this.matchCase.AutoSize = true;
            this.matchCase.ForeColor = System.Drawing.Color.White;
            this.matchCase.Location = new System.Drawing.Point(266, 5);
            this.matchCase.Name = "matchCase";
            this.matchCase.Size = new System.Drawing.Size(88, 19);
            this.matchCase.TabIndex = 1;
            this.matchCase.Text = "Match Case";
            this.matchCase.UseVisualStyleBackColor = true;
            this.matchCase.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // WholeWord
            // 
            this.WholeWord.AutoSize = true;
            this.WholeWord.ForeColor = System.Drawing.Color.White;
            this.WholeWord.Location = new System.Drawing.Point(266, 24);
            this.WholeWord.Name = "WholeWord";
            this.WholeWord.Size = new System.Drawing.Size(129, 19);
            this.WholeWord.TabIndex = 2;
            this.WholeWord.Text = "Match Whole Word";
            this.WholeWord.UseVisualStyleBackColor = true;
            this.WholeWord.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(5, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // highlight_button
            // 
            this.highlight_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.highlight_button.ForeColor = System.Drawing.Color.White;
            this.highlight_button.Location = new System.Drawing.Point(86, 44);
            this.highlight_button.Name = "highlight_button";
            this.highlight_button.Size = new System.Drawing.Size(89, 23);
            this.highlight_button.TabIndex = 5;
            this.highlight_button.Text = "Highlight All";
            this.highlight_button.UseVisualStyleBackColor = false;
            this.highlight_button.Click += new System.EventHandler(this.highlight_button_Click);
            // 
            // find_replace_button
            // 
            this.find_replace_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.find_replace_button.ForeColor = System.Drawing.Color.White;
            this.find_replace_button.Location = new System.Drawing.Point(181, 44);
            this.find_replace_button.Name = "find_replace_button";
            this.find_replace_button.Size = new System.Drawing.Size(196, 23);
            this.find_replace_button.TabIndex = 6;
            this.find_replace_button.Text = "How to use Regular Expressions";
            this.find_replace_button.UseVisualStyleBackColor = false;
            this.find_replace_button.Click += new System.EventHandler(this.find_replace_button_Click);
            // 
            // Find_Window
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(419, 71);
            this.Controls.Add(this.find_replace_button);
            this.Controls.Add(this.highlight_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WholeWord);
            this.Controls.Add(this.matchCase);
            this.Controls.Add(this.find_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Find_Window";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox find_box;
        private System.Windows.Forms.CheckBox matchCase;
        private System.Windows.Forms.CheckBox WholeWord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button highlight_button;
        private System.Windows.Forms.Button find_replace_button;
    }
}
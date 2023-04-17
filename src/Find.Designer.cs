
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(266, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Match Case";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(266, 24);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(129, 19);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Match Whole Word";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.ForeColor = System.Drawing.Color.White;
            this.checkBox3.Location = new System.Drawing.Point(266, 44);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(152, 19);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Use Regular Expressions";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
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
            // 
            // find_replace_button
            // 
            this.find_replace_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.find_replace_button.ForeColor = System.Drawing.Color.White;
            this.find_replace_button.Location = new System.Drawing.Point(171, 44);
            this.find_replace_button.Name = "find_replace_button";
            this.find_replace_button.Size = new System.Drawing.Size(89, 23);
            this.find_replace_button.TabIndex = 6;
            this.find_replace_button.Text = "Replace";
            this.find_replace_button.UseVisualStyleBackColor = false;
            // 
            // Find_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(419, 71);
            this.Controls.Add(this.find_replace_button);
            this.Controls.Add(this.highlight_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.find_box);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Find_Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox find_box;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button highlight_button;
        private System.Windows.Forms.Button find_replace_button;
    }
}
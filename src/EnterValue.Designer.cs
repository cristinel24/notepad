
namespace Notepad
{
    partial class EnterValue
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
            this.cancel_button = new System.Windows.Forms.Button();
            this.change_button = new System.Windows.Forms.Button();
            this.change_box = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancel_button.ForeColor = System.Drawing.Color.White;
            this.cancel_button.Location = new System.Drawing.Point(125, 61);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(90, 23);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // change_button
            // 
            this.change_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.change_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.change_button.ForeColor = System.Drawing.Color.White;
            this.change_button.Location = new System.Drawing.Point(12, 61);
            this.change_button.Name = "change_button";
            this.change_button.Size = new System.Drawing.Size(107, 23);
            this.change_button.TabIndex = 2;
            this.change_button.Text = "Change Value";
            this.change_button.UseVisualStyleBackColor = false;
            this.change_button.Click += new System.EventHandler(this.change_button_Click);
            // 
            // change_box
            // 
            this.change_box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.change_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.change_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.change_box.EnableAutoDragDrop = true;
            this.change_box.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.change_box.ForeColor = System.Drawing.Color.White;
            this.change_box.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.change_box.Location = new System.Drawing.Point(12, 27);
            this.change_box.Multiline = false;
            this.change_box.Name = "change_box";
            this.change_box.Size = new System.Drawing.Size(203, 25);
            this.change_box.TabIndex = 1;
            this.change_box.Text = "";
            this.change_box.TextChanged += new System.EventHandler(this.change_box_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(76, 5);
            this.textBox1.MaximumSize = new System.Drawing.Size(200, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 16);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Change Value:";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.WordWrap = false;
            // 
            // EnterValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(227, 87);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.change_box);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.change_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnterValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EnterValue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button change_button;
        private System.Windows.Forms.RichTextBox change_box;
        private System.Windows.Forms.TextBox textBox1;
    }
}
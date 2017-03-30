namespace Compiler
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textbox = new System.Windows.Forms.RichTextBox();
            this.label = new System.Windows.Forms.Label();
            this.dmButtonClose1 = new DMSkin.Controls.DMButtonClose();
            this.dmButtonMin1 = new DMSkin.Controls.DMButtonMin();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textbox.Location = new System.Drawing.Point(8, 64);
            this.textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox.Name = "textbox";
            this.textbox.ReadOnly = true;
            this.textbox.Size = new System.Drawing.Size(659, 459);
            this.textbox.TabIndex = 9;
            this.textbox.Text = "";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(9, 44);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(43, 17);
            this.label.TabIndex = 10;
            this.label.Text = "label1";
            // 
            // dmButtonClose1
            // 
            this.dmButtonClose1.BackColor = System.Drawing.Color.Transparent;
            this.dmButtonClose1.Location = new System.Drawing.Point(641, 0);
            this.dmButtonClose1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dmButtonClose1.MaximumSize = new System.Drawing.Size(34, 36);
            this.dmButtonClose1.MinimumSize = new System.Drawing.Size(34, 36);
            this.dmButtonClose1.Name = "dmButtonClose1";
            this.dmButtonClose1.Size = new System.Drawing.Size(34, 36);
            this.dmButtonClose1.TabIndex = 11;
            this.dmButtonClose1.Click += new System.EventHandler(this.dmButtonClose1_Click);
            // 
            // dmButtonMin1
            // 
            this.dmButtonMin1.BackColor = System.Drawing.Color.Transparent;
            this.dmButtonMin1.Location = new System.Drawing.Point(608, 0);
            this.dmButtonMin1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dmButtonMin1.Name = "dmButtonMin1";
            this.dmButtonMin1.Size = new System.Drawing.Size(34, 36);
            this.dmButtonMin1.TabIndex = 12;
            this.dmButtonMin1.Click += new System.EventHandler(this.dmButtonMin1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(238)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(675, 533);
            this.Controls.Add(this.dmButtonMin1);
            this.Controls.Add(this.dmButtonClose1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textbox);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "输出显示";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DMSkin.Controls.DMButtonClose dmButtonClose1;
        private DMSkin.Controls.DMButtonMin dmButtonMin1;
        public System.Windows.Forms.Label label;
        public System.Windows.Forms.RichTextBox textbox;
    }
}
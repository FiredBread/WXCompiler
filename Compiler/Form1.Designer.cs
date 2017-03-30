namespace Compiler
{
    partial class Compiler
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compiler));
            this.fileButton = new DMSkin.Controls.DMButton();
            this.hirtreeTextBox = new System.Windows.Forms.RichTextBox();
            this.errrorTextBox = new System.Windows.Forms.RichTextBox();
            this.dmButtonClose1 = new DMSkin.Controls.DMButtonClose();
            this.dmButtonMin1 = new DMSkin.Controls.DMButtonMin();
            this.startButton = new DMSkin.Controls.DMButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lexButton = new DMSkin.Controls.DMButton();
            this.parseButton = new DMSkin.Controls.DMButton();
            this.symbolButton = new DMSkin.Controls.DMButton();
            this.SuspendLayout();
            // 
            // fileButton
            // 
            this.fileButton.BackColor = System.Drawing.Color.Transparent;
            this.fileButton.DM_DisabledColor = System.Drawing.Color.Empty;
            this.fileButton.DM_DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(238)))), ((int)(((byte)(58)))));
            this.fileButton.DM_MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(62)))));
            this.fileButton.DM_NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(255)))), ((int)(((byte)(112)))));
            this.fileButton.DM_Radius = 8;
            this.fileButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileButton.Image = null;
            this.fileButton.Location = new System.Drawing.Point(845, 48);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(125, 45);
            this.fileButton.TabIndex = 0;
            this.fileButton.Text = "打开源码文件";
            this.fileButton.UseVisualStyleBackColor = false;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // hirtreeTextBox
            // 
            this.hirtreeTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hirtreeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hirtreeTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hirtreeTextBox.Location = new System.Drawing.Point(7, 48);
            this.hirtreeTextBox.Name = "hirtreeTextBox";
            this.hirtreeTextBox.Size = new System.Drawing.Size(800, 336);
            this.hirtreeTextBox.TabIndex = 1;
            this.hirtreeTextBox.Text = "";
            // 
            // errrorTextBox
            // 
            this.errrorTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.errrorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errrorTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errrorTextBox.Location = new System.Drawing.Point(7, 412);
            this.errrorTextBox.Name = "errrorTextBox";
            this.errrorTextBox.ReadOnly = true;
            this.errrorTextBox.Size = new System.Drawing.Size(800, 150);
            this.errrorTextBox.TabIndex = 2;
            this.errrorTextBox.Text = "";
            // 
            // dmButtonClose1
            // 
            this.dmButtonClose1.BackColor = System.Drawing.Color.Transparent;
            this.dmButtonClose1.Location = new System.Drawing.Point(970, 0);
            this.dmButtonClose1.Margin = new System.Windows.Forms.Padding(4);
            this.dmButtonClose1.MaximumSize = new System.Drawing.Size(30, 27);
            this.dmButtonClose1.MinimumSize = new System.Drawing.Size(30, 27);
            this.dmButtonClose1.Name = "dmButtonClose1";
            this.dmButtonClose1.Size = new System.Drawing.Size(30, 27);
            this.dmButtonClose1.TabIndex = 4;
            this.dmButtonClose1.Click += new System.EventHandler(this.dmButtonClose1_Click);
            // 
            // dmButtonMin1
            // 
            this.dmButtonMin1.BackColor = System.Drawing.Color.Transparent;
            this.dmButtonMin1.Location = new System.Drawing.Point(940, 0);
            this.dmButtonMin1.Margin = new System.Windows.Forms.Padding(4);
            this.dmButtonMin1.Name = "dmButtonMin1";
            this.dmButtonMin1.Size = new System.Drawing.Size(30, 27);
            this.dmButtonMin1.TabIndex = 5;
            this.dmButtonMin1.Click += new System.EventHandler(this.dmButtonMin1_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.DM_DisabledColor = System.Drawing.Color.Empty;
            this.startButton.DM_DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(238)))), ((int)(((byte)(58)))));
            this.startButton.DM_MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(62)))));
            this.startButton.DM_NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(255)))), ((int)(((byte)(112)))));
            this.startButton.DM_Radius = 5;
            this.startButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startButton.Image = null;
            this.startButton.Location = new System.Drawing.Point(845, 101);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(125, 45);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "编译";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "源代码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(7, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "错误提示";
            // 
            // lexButton
            // 
            this.lexButton.BackColor = System.Drawing.Color.Transparent;
            this.lexButton.DM_DisabledColor = System.Drawing.Color.Empty;
            this.lexButton.DM_DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(238)))), ((int)(((byte)(58)))));
            this.lexButton.DM_MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(62)))));
            this.lexButton.DM_NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(255)))), ((int)(((byte)(112)))));
            this.lexButton.DM_Radius = 5;
            this.lexButton.Image = null;
            this.lexButton.Location = new System.Drawing.Point(845, 237);
            this.lexButton.Name = "lexButton";
            this.lexButton.Size = new System.Drawing.Size(125, 45);
            this.lexButton.TabIndex = 14;
            this.lexButton.Text = "词法分析输出";
            this.lexButton.UseVisualStyleBackColor = false;
            this.lexButton.Click += new System.EventHandler(this.lexButton_Click);
            // 
            // parseButton
            // 
            this.parseButton.BackColor = System.Drawing.Color.Transparent;
            this.parseButton.DM_DisabledColor = System.Drawing.Color.Empty;
            this.parseButton.DM_DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(238)))), ((int)(((byte)(58)))));
            this.parseButton.DM_MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(62)))));
            this.parseButton.DM_NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(255)))), ((int)(((byte)(112)))));
            this.parseButton.DM_Radius = 5;
            this.parseButton.Image = null;
            this.parseButton.Location = new System.Drawing.Point(845, 288);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(125, 45);
            this.parseButton.TabIndex = 15;
            this.parseButton.Text = "语法树";
            this.parseButton.UseVisualStyleBackColor = false;
            this.parseButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // symbolButton
            // 
            this.symbolButton.BackColor = System.Drawing.Color.Transparent;
            this.symbolButton.DM_DisabledColor = System.Drawing.Color.Empty;
            this.symbolButton.DM_DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(238)))), ((int)(((byte)(58)))));
            this.symbolButton.DM_MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(62)))));
            this.symbolButton.DM_NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(255)))), ((int)(((byte)(112)))));
            this.symbolButton.DM_Radius = 5;
            this.symbolButton.Image = null;
            this.symbolButton.Location = new System.Drawing.Point(845, 339);
            this.symbolButton.Name = "symbolButton";
            this.symbolButton.Size = new System.Drawing.Size(125, 45);
            this.symbolButton.TabIndex = 16;
            this.symbolButton.Text = "符号表";
            this.symbolButton.UseVisualStyleBackColor = false;
            this.symbolButton.Click += new System.EventHandler(this.symbolButton_Click);
            // 
            // Compiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(238)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1000, 579);
            this.Controls.Add(this.symbolButton);
            this.Controls.Add(this.parseButton);
            this.Controls.Add(this.lexButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.dmButtonMin1);
            this.Controls.Add(this.dmButtonClose1);
            this.Controls.Add(this.errrorTextBox);
            this.Controls.Add(this.hirtreeTextBox);
            this.Controls.Add(this.fileButton);
            this.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Compiler";
            this.Text = "WXCompiler";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Compiler_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DMSkin.Controls.DMButton fileButton;
        private System.Windows.Forms.RichTextBox hirtreeTextBox;
        private System.Windows.Forms.RichTextBox errrorTextBox;
        private DMSkin.Controls.DMButtonClose dmButtonClose1;
        private DMSkin.Controls.DMButtonMin dmButtonMin1;
        private DMSkin.Controls.DMButton startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DMSkin.Controls.DMButton lexButton;
        private DMSkin.Controls.DMButton parseButton;
        private DMSkin.Controls.DMButton symbolButton;
    }
}


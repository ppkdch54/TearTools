namespace TearTools
{
    partial class tearToolsForm
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
            this.dataSendButton = new System.Windows.Forms.Button();
            this.alarmButton = new System.Windows.Forms.Button();
            this.selectCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dataSendButton
            // 
            this.dataSendButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataSendButton.Location = new System.Drawing.Point(32, 45);
            this.dataSendButton.Name = "dataSendButton";
            this.dataSendButton.Size = new System.Drawing.Size(150, 50);
            this.dataSendButton.TabIndex = 0;
            this.dataSendButton.Text = "开启心跳";
            this.dataSendButton.UseVisualStyleBackColor = true;
            this.dataSendButton.Click += new System.EventHandler(this.DataSendButton_Click);
            // 
            // alarmButton
            // 
            this.alarmButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alarmButton.Location = new System.Drawing.Point(214, 45);
            this.alarmButton.Name = "alarmButton";
            this.alarmButton.Size = new System.Drawing.Size(150, 50);
            this.alarmButton.TabIndex = 1;
            this.alarmButton.Text = "报警";
            this.alarmButton.UseVisualStyleBackColor = true;
            this.alarmButton.Click += new System.EventHandler(this.AlarmButton_Click);
            // 
            // selectCombobox
            // 
            this.selectCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCombobox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectCombobox.FormattingEnabled = true;
            this.selectCombobox.Location = new System.Drawing.Point(46, 160);
            this.selectCombobox.Name = "selectCombobox";
            this.selectCombobox.Size = new System.Drawing.Size(121, 24);
            this.selectCombobox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(43, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "串口号";
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox.Location = new System.Drawing.Point(106, 116);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(61, 26);
            this.textBox.TabIndex = 4;
            // 
            // tearToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectCombobox);
            this.Controls.Add(this.alarmButton);
            this.Controls.Add(this.dataSendButton);
            this.Name = "tearToolsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TearTools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button dataSendButton;
        private System.Windows.Forms.Button alarmButton;
        private System.Windows.Forms.ComboBox selectCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
    }
}


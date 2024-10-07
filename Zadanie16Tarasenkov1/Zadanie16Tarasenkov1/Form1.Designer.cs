namespace Zadanie16Tarasenkov1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnChangePin = new System.Windows.Forms.Button();
            this.txtEventLog = new System.Windows.Forms.ListBox();
            this.txtNewPin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(844, 125);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "button1";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnChangePin
            // 
            this.btnChangePin.Location = new System.Drawing.Point(844, 192);
            this.btnChangePin.Name = "btnChangePin";
            this.btnChangePin.Size = new System.Drawing.Size(75, 23);
            this.btnChangePin.TabIndex = 1;
            this.btnChangePin.Text = "button2";
            this.btnChangePin.UseVisualStyleBackColor = true;
            // 
            // txtEventLog
            // 
            this.txtEventLog.FormattingEnabled = true;
            this.txtEventLog.Location = new System.Drawing.Point(385, 401);
            this.txtEventLog.Name = "txtEventLog";
            this.txtEventLog.Size = new System.Drawing.Size(120, 95);
            this.txtEventLog.TabIndex = 2;
            // 
            // txtNewPin
            // 
            this.txtNewPin.Location = new System.Drawing.Point(375, 217);
            this.txtNewPin.Name = "txtNewPin";
            this.txtNewPin.Size = new System.Drawing.Size(100, 20);
            this.txtNewPin.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 713);
            this.Controls.Add(this.txtNewPin);
            this.Controls.Add(this.txtEventLog);
            this.Controls.Add(this.btnChangePin);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnChangePin;
        private System.Windows.Forms.ListBox txtEventLog;
        private System.Windows.Forms.TextBox txtNewPin;
    }
}


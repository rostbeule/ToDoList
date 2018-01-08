namespace ToDoList
{
    partial class Concept
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.BtnRead = new System.Windows.Forms.Button();
            this.LblOut = new System.Windows.Forms.Label();
            this.DtpCalendar = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtCalendar = new System.Windows.Forms.TextBox();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.LstDate = new System.Windows.Forms.ListBox();
            this.ChkLstEntries = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // BtnRead
            // 
            this.BtnRead.Location = new System.Drawing.Point(12, 41);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(75, 23);
            this.BtnRead.TabIndex = 1;
            this.BtnRead.Text = "Read XML";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // LblOut
            // 
            this.LblOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblOut.Location = new System.Drawing.Point(135, 12);
            this.LblOut.Name = "LblOut";
            this.LblOut.Size = new System.Drawing.Size(424, 285);
            this.LblOut.TabIndex = 2;
            // 
            // DtpCalendar
            // 
            this.DtpCalendar.Location = new System.Drawing.Point(135, 343);
            this.DtpCalendar.Name = "DtpCalendar";
            this.DtpCalendar.Size = new System.Drawing.Size(200, 20);
            this.DtpCalendar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Calendar";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(12, 340);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 5;
            this.BtnAdd.Text = "Add Entry";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtCalendar
            // 
            this.TxtCalendar.Location = new System.Drawing.Point(135, 369);
            this.TxtCalendar.Name = "TxtCalendar";
            this.TxtCalendar.Size = new System.Drawing.Size(424, 20);
            this.TxtCalendar.TabIndex = 6;
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(12, 402);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnRemove.TabIndex = 7;
            this.BtnRemove.Text = "Remove Entry";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // LstDate
            // 
            this.LstDate.FormattingEnabled = true;
            this.LstDate.Location = new System.Drawing.Point(135, 202);
            this.LstDate.Name = "LstDate";
            this.LstDate.Size = new System.Drawing.Size(120, 95);
            this.LstDate.TabIndex = 8;
            this.LstDate.SelectedIndexChanged += new System.EventHandler(this.LstDate_SelectedIndexChanged);
            // 
            // ChkLstEntries
            // 
            this.ChkLstEntries.FormattingEnabled = true;
            this.ChkLstEntries.Location = new System.Drawing.Point(261, 203);
            this.ChkLstEntries.Name = "ChkLstEntries";
            this.ChkLstEntries.Size = new System.Drawing.Size(298, 94);
            this.ChkLstEntries.TabIndex = 9;
            // 
            // Concept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 497);
            this.Controls.Add(this.ChkLstEntries);
            this.Controls.Add(this.LstDate);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.TxtCalendar);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpCalendar);
            this.Controls.Add(this.LblOut);
            this.Controls.Add(this.BtnRead);
            this.Controls.Add(this.button1);
            this.Name = "Concept";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.Label LblOut;
        private System.Windows.Forms.DateTimePicker DtpCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TxtCalendar;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.ListBox LstDate;
        private System.Windows.Forms.CheckedListBox ChkLstEntries;
    }
}


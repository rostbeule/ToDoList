namespace ToDoList
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.MnuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuNewEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuCloseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMnuStrp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PanNew_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PanNew = new System.Windows.Forms.Panel();
            this.PanNew_BtnAdd = new System.Windows.Forms.Button();
            this.PanNew_BtnCancel = new System.Windows.Forms.Button();
            this.PanNew_TextBox = new System.Windows.Forms.TextBox();
            this.PanEdit = new System.Windows.Forms.Panel();
            this.PanEdit_ChkMove = new System.Windows.Forms.CheckBox();
            this.PanEdit_BtnEdit = new System.Windows.Forms.Button();
            this.PanEdit_BtnCancel = new System.Windows.Forms.Button();
            this.PanEdit_TextBox = new System.Windows.Forms.TextBox();
            this.PanEdit_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.MnuStrip.SuspendLayout();
            this.ConMnuStrp.SuspendLayout();
            this.PanNew.SuspendLayout();
            this.PanEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnuStrip
            // 
            this.MnuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.MnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuApplication,
            this.MnuOptions});
            this.MnuStrip.Location = new System.Drawing.Point(0, 0);
            this.MnuStrip.Name = "MnuStrip";
            this.MnuStrip.Size = new System.Drawing.Size(284, 24);
            this.MnuStrip.TabIndex = 15;
            this.MnuStrip.Text = "menuStrip1";
            // 
            // MnuApplication
            // 
            this.MnuApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuNewEntry,
            this.toolStripSeparator1,
            this.MnuCloseApp});
            this.MnuApplication.Name = "MnuApplication";
            this.MnuApplication.Size = new System.Drawing.Size(80, 20);
            this.MnuApplication.Text = "Application";
            // 
            // MnuNewEntry
            // 
            this.MnuNewEntry.Name = "MnuNewEntry";
            this.MnuNewEntry.Size = new System.Drawing.Size(152, 22);
            this.MnuNewEntry.Text = "New Entry";
            this.MnuNewEntry.Click += new System.EventHandler(this.Context_New_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MnuCloseApp
            // 
            this.MnuCloseApp.Name = "MnuCloseApp";
            this.MnuCloseApp.Size = new System.Drawing.Size(152, 22);
            this.MnuCloseApp.Text = "Close";
            this.MnuCloseApp.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // MnuOptions
            // 
            this.MnuOptions.Name = "MnuOptions";
            this.MnuOptions.Size = new System.Drawing.Size(61, 20);
            this.MnuOptions.Text = "Options";
            // 
            // ConMnuStrp
            // 
            this.ConMnuStrp.AutoSize = false;
            this.ConMnuStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextNew,
            this.ContextEdit,
            this.toolStripSeparator2,
            this.ContextDelete});
            this.ConMnuStrp.Name = "contextMenuStrip1";
            this.ConMnuStrp.Size = new System.Drawing.Size(100, 98);
            // 
            // ContextNew
            // 
            this.ContextNew.Name = "ContextNew";
            this.ContextNew.Size = new System.Drawing.Size(107, 22);
            this.ContextNew.Text = "New";
            this.ContextNew.Click += new System.EventHandler(this.Context_New_Click);
            // 
            // ContextEdit
            // 
            this.ContextEdit.Name = "ContextEdit";
            this.ContextEdit.Size = new System.Drawing.Size(107, 22);
            this.ContextEdit.Text = "Edit";
            this.ContextEdit.Click += new System.EventHandler(this.Context_Edit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(96, 6);
            // 
            // ContextDelete
            // 
            this.ContextDelete.Name = "ContextDelete";
            this.ContextDelete.Size = new System.Drawing.Size(107, 22);
            this.ContextDelete.Text = "Delete";
            this.ContextDelete.Click += new System.EventHandler(this.Context_Delete_Click);
            // 
            // PanNew_DateTimePicker
            // 
            this.PanNew_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PanNew_DateTimePicker.Location = new System.Drawing.Point(3, 3);
            this.PanNew_DateTimePicker.Name = "PanNew_DateTimePicker";
            this.PanNew_DateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.PanNew_DateTimePicker.TabIndex = 16;
            // 
            // PanNew
            // 
            this.PanNew.BackColor = System.Drawing.SystemColors.Control;
            this.PanNew.Controls.Add(this.PanNew_BtnAdd);
            this.PanNew.Controls.Add(this.PanNew_BtnCancel);
            this.PanNew.Controls.Add(this.PanNew_TextBox);
            this.PanNew.Controls.Add(this.PanNew_DateTimePicker);
            this.PanNew.Location = new System.Drawing.Point(0, 27);
            this.PanNew.Name = "PanNew";
            this.PanNew.Size = new System.Drawing.Size(300, 53);
            this.PanNew.TabIndex = 17;
            // 
            // PanNew_BtnAdd
            // 
            this.PanNew_BtnAdd.Location = new System.Drawing.Point(228, 30);
            this.PanNew_BtnAdd.Name = "PanNew_BtnAdd";
            this.PanNew_BtnAdd.Size = new System.Drawing.Size(50, 20);
            this.PanNew_BtnAdd.TabIndex = 19;
            this.PanNew_BtnAdd.Text = "Add";
            this.PanNew_BtnAdd.UseVisualStyleBackColor = true;
            // 
            // PanNew_BtnCancel
            // 
            this.PanNew_BtnCancel.Location = new System.Drawing.Point(228, 3);
            this.PanNew_BtnCancel.Name = "PanNew_BtnCancel";
            this.PanNew_BtnCancel.Size = new System.Drawing.Size(50, 20);
            this.PanNew_BtnCancel.TabIndex = 18;
            this.PanNew_BtnCancel.Text = "Cancel";
            this.PanNew_BtnCancel.UseVisualStyleBackColor = true;
            // 
            // PanNew_TextBox
            // 
            this.PanNew_TextBox.Location = new System.Drawing.Point(3, 30);
            this.PanNew_TextBox.Name = "PanNew_TextBox";
            this.PanNew_TextBox.Size = new System.Drawing.Size(219, 20);
            this.PanNew_TextBox.TabIndex = 17;
            // 
            // PanEdit
            // 
            this.PanEdit.BackColor = System.Drawing.SystemColors.Control;
            this.PanEdit.Controls.Add(this.PanEdit_ChkMove);
            this.PanEdit.Controls.Add(this.PanEdit_BtnEdit);
            this.PanEdit.Controls.Add(this.PanEdit_BtnCancel);
            this.PanEdit.Controls.Add(this.PanEdit_TextBox);
            this.PanEdit.Controls.Add(this.PanEdit_DateTimePicker);
            this.PanEdit.Location = new System.Drawing.Point(0, 83);
            this.PanEdit.Name = "PanEdit";
            this.PanEdit.Size = new System.Drawing.Size(300, 53);
            this.PanEdit.TabIndex = 18;
            // 
            // PanEdit_ChkMove
            // 
            this.PanEdit_ChkMove.AutoSize = true;
            this.PanEdit_ChkMove.Location = new System.Drawing.Point(110, 3);
            this.PanEdit_ChkMove.Name = "PanEdit_ChkMove";
            this.PanEdit_ChkMove.Size = new System.Drawing.Size(53, 17);
            this.PanEdit_ChkMove.TabIndex = 21;
            this.PanEdit_ChkMove.Text = "Move";
            this.PanEdit_ChkMove.UseVisualStyleBackColor = true;
            // 
            // PanEdit_BtnEdit
            // 
            this.PanEdit_BtnEdit.Location = new System.Drawing.Point(228, 30);
            this.PanEdit_BtnEdit.Name = "PanEdit_BtnEdit";
            this.PanEdit_BtnEdit.Size = new System.Drawing.Size(50, 20);
            this.PanEdit_BtnEdit.TabIndex = 19;
            this.PanEdit_BtnEdit.Text = "Edit";
            this.PanEdit_BtnEdit.UseVisualStyleBackColor = true;
            // 
            // PanEdit_BtnCancel
            // 
            this.PanEdit_BtnCancel.Location = new System.Drawing.Point(229, 3);
            this.PanEdit_BtnCancel.Name = "PanEdit_BtnCancel";
            this.PanEdit_BtnCancel.Size = new System.Drawing.Size(50, 20);
            this.PanEdit_BtnCancel.TabIndex = 18;
            this.PanEdit_BtnCancel.Text = "Cancel";
            this.PanEdit_BtnCancel.UseVisualStyleBackColor = true;
            // 
            // PanEdit_TextBox
            // 
            this.PanEdit_TextBox.Location = new System.Drawing.Point(3, 30);
            this.PanEdit_TextBox.Name = "PanEdit_TextBox";
            this.PanEdit_TextBox.Size = new System.Drawing.Size(219, 20);
            this.PanEdit_TextBox.TabIndex = 17;
            // 
            // PanEdit_DateTimePicker
            // 
            this.PanEdit_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PanEdit_DateTimePicker.Location = new System.Drawing.Point(3, 3);
            this.PanEdit_DateTimePicker.Name = "PanEdit_DateTimePicker";
            this.PanEdit_DateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.PanEdit_DateTimePicker.TabIndex = 16;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(284, 561);
            this.Controls.Add(this.PanEdit);
            this.Controls.Add(this.PanNew);
            this.Controls.Add(this.MnuStrip);
            this.MainMenuStrip = this.MnuStrip;
            this.Name = "MainWindow";
            this.Text = "ToDoList";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MnuStrip.ResumeLayout(false);
            this.MnuStrip.PerformLayout();
            this.ConMnuStrp.ResumeLayout(false);
            this.PanNew.ResumeLayout(false);
            this.PanNew.PerformLayout();
            this.PanEdit.ResumeLayout(false);
            this.PanEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MnuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuApplication;
        private System.Windows.Forms.ToolStripMenuItem MnuCloseApp;
        private System.Windows.Forms.ToolStripMenuItem MnuOptions;
        private System.Windows.Forms.ContextMenuStrip ConMnuStrp;
        private System.Windows.Forms.DateTimePicker PanNew_DateTimePicker;
        private System.Windows.Forms.Panel PanNew;
        private System.Windows.Forms.TextBox PanNew_TextBox;
        private System.Windows.Forms.Button PanNew_BtnAdd;
        private System.Windows.Forms.Button PanNew_BtnCancel;
        private System.Windows.Forms.ToolStripMenuItem MnuNewEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ContextNew;
        private System.Windows.Forms.ToolStripMenuItem ContextEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ContextDelete;
        private System.Windows.Forms.Panel PanEdit;
        private System.Windows.Forms.Button PanEdit_BtnEdit;
        private System.Windows.Forms.Button PanEdit_BtnCancel;
        private System.Windows.Forms.TextBox PanEdit_TextBox;
        private System.Windows.Forms.DateTimePicker PanEdit_DateTimePicker;
        private System.Windows.Forms.CheckBox PanEdit_ChkMove;
    }
}


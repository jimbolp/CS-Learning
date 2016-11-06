using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExcelTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
        protected void InitializeComponent()
        {
            this.startReplacing = new Button();
            ExceptionLabel = new Label();
            this.filePathTextBox = new TextBox();
            this.label1 = new Label();
            this.killExcelButton = new Button();
            this.loadExcelFile = new Button();
            this.openExcelFile = new OpenFileDialog();
            this.SuspendLayout();
            // 
            // startReplacing
            // 
            this.startReplacing.Anchor = AnchorStyles.Left;
            this.startReplacing.FlatStyle = FlatStyle.Popup;
            this.startReplacing.Location = new Point(23, 90);
            this.startReplacing.Name = "startReplacing";
            this.startReplacing.Size = new Size(90, 51);
            this.startReplacing.TabIndex = 0;
            this.startReplacing.Text = "Замести PZN-а във файла";
            this.startReplacing.UseVisualStyleBackColor = true;
            this.startReplacing.Click += new EventHandler(this.startReplacing_Click);
            // 
            // ExceptionLabel
            // 
            ExceptionLabel.Dock = DockStyle.Bottom;
            ExceptionLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            ExceptionLabel.Location = new Point(0, 179);
            ExceptionLabel.Name = "ExceptionLabel";
            ExceptionLabel.Size = new Size(389, 94);
            ExceptionLabel.TabIndex = 1;
            ExceptionLabel.Click += new EventHandler(this.ExceptionLabel_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.AllowDrop = true;
            this.filePathTextBox.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.filePathTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.filePathTextBox.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
            this.filePathTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.filePathTextBox.ForeColor = Color.LightGray;
            this.filePathTextBox.Location = new Point(23, 30);
            this.filePathTextBox.Multiline = true;
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new Size(353, 38);
            this.filePathTextBox.TabIndex = 2;
            this.filePathTextBox.Text = "(Хвани и поостави Excel файла тук)";
            this.filePathTextBox.TextChanged += new EventHandler(this.filePathTextBox_TextChanged);
            this.filePathTextBox.DragDrop += new DragEventHandler(this.filePathTextBox_DragDrop);
            this.filePathTextBox.DragOver += new DragEventHandler(this.filePathTextBox_DragOver);
            this.filePathTextBox.Enter += new EventHandler(this.filePathTextBox_Enter);
            this.filePathTextBox.Leave += new EventHandler(this.filePathTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Excel File Path:";
            // 
            // killExcelButton
            // 
            this.killExcelButton.Anchor = AnchorStyles.Right;
            this.killExcelButton.Cursor = Cursors.No;
            this.killExcelButton.Enabled = false;
            this.killExcelButton.FlatStyle = FlatStyle.Popup;
            this.killExcelButton.Location = new Point(286, 90);
            this.killExcelButton.Name = "killExcelButton";
            this.killExcelButton.Size = new Size(90, 51);
            this.killExcelButton.TabIndex = 4;
            this.killExcelButton.Text = "Kill Excel Processes";
            this.killExcelButton.UseVisualStyleBackColor = true;
            this.killExcelButton.Click += new EventHandler(this.killExcelButton_Click);
            // 
            // loadExcelFile
            // 
            this.loadExcelFile.Anchor = AnchorStyles.None;
            this.loadExcelFile.FlatStyle = FlatStyle.Popup;
            this.loadExcelFile.Location = new Point(163, 90);
            this.loadExcelFile.Name = "loadExcelFile";
            this.loadExcelFile.Size = new Size(80, 51);
            this.loadExcelFile.TabIndex = 5;
            this.loadExcelFile.Text = "Зареди файл";
            this.loadExcelFile.UseVisualStyleBackColor = true;
            this.loadExcelFile.Click += new EventHandler(this.loadExcelFile_Click);
            // 
            // openExcelFile
            // 
            this.openExcelFile.DefaultExt = "xlsx";
            this.openExcelFile.SupportMultiDottedExtensions = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(389, 273);
            this.Controls.Add(this.loadExcelFile);
            this.Controls.Add(this.killExcelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(ExceptionLabel);
            this.Controls.Add(this.startReplacing);
            this.Name = "Form1";
            this.Text = "PZN - Добавяне на контролна цифра";
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startReplacing;
        protected static Label ExceptionLabel;
        private TextBox filePathTextBox;
        private Label label1;
        private Button killExcelButton;
        private Button loadExcelFile;
        private OpenFileDialog openExcelFile;
    }
}


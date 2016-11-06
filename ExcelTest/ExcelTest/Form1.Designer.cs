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
            this.startReplacing = new System.Windows.Forms.Button();
            ExceptionLabel = new System.Windows.Forms.Label();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.killExcelButton = new System.Windows.Forms.Button();
            this.loadExcelFile = new System.Windows.Forms.Button();
            this.openExcelFile = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startReplacing
            // 
            this.startReplacing.BackgroundImage = global::ExcelTest.Properties.Resources.Run;
            this.startReplacing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startReplacing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startReplacing.Location = new System.Drawing.Point(23, 86);
            this.startReplacing.Name = "startReplacing";
            this.startReplacing.Size = new System.Drawing.Size(90, 51);
            this.startReplacing.TabIndex = 0;
            this.startReplacing.UseVisualStyleBackColor = true;
            this.startReplacing.Click += new System.EventHandler(this.startReplacing_Click);
            // 
            // ExceptionLabel
            // 
            ExceptionLabel.AutoEllipsis = true;
            ExceptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ExceptionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            ExceptionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ExceptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ExceptionLabel.Location = new System.Drawing.Point(0, 193);
            ExceptionLabel.Name = "ExceptionLabel";
            ExceptionLabel.Size = new System.Drawing.Size(440, 145);
            ExceptionLabel.TabIndex = 1;
            ExceptionLabel.Click += new System.EventHandler(ExceptionLabel_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.AllowDrop = true;
            this.filePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.filePathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filePathTextBox.ForeColor = System.Drawing.Color.LightGray;
            this.filePathTextBox.Location = new System.Drawing.Point(23, 30);
            this.filePathTextBox.Multiline = true;
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(404, 38);
            this.filePathTextBox.TabIndex = 2;
            this.filePathTextBox.Text = "(Хвани и поостави Excel файла тук)";
            this.filePathTextBox.TextChanged += new System.EventHandler(this.filePathTextBox_TextChanged);
            this.filePathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.filePathTextBox_DragDrop);
            this.filePathTextBox.DragOver += new System.Windows.Forms.DragEventHandler(this.filePathTextBox_DragOver);
            this.filePathTextBox.Enter += new System.EventHandler(this.filePathTextBox_Enter);
            this.filePathTextBox.Leave += new System.EventHandler(this.filePathTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Excel File Path:";
            // 
            // killExcelButton
            // 
            this.killExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.killExcelButton.BackgroundImage = global::ExcelTest.Properties.Resources.Disclaimer;
            this.killExcelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.killExcelButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.killExcelButton.Enabled = false;
            this.killExcelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.killExcelButton.Location = new System.Drawing.Point(337, 86);
            this.killExcelButton.Name = "killExcelButton";
            this.killExcelButton.Size = new System.Drawing.Size(90, 51);
            this.killExcelButton.TabIndex = 4;
            this.killExcelButton.UseVisualStyleBackColor = true;
            this.killExcelButton.Click += new System.EventHandler(this.killExcelButton_Click);
            // 
            // loadExcelFile
            // 
            this.loadExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadExcelFile.BackgroundImage = global::ExcelTest.Properties.Resources.DocumentsFolder;
            this.loadExcelFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loadExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadExcelFile.Location = new System.Drawing.Point(182, 86);
            this.loadExcelFile.Name = "loadExcelFile";
            this.loadExcelFile.Size = new System.Drawing.Size(91, 51);
            this.loadExcelFile.TabIndex = 5;
            this.loadExcelFile.UseVisualStyleBackColor = true;
            this.loadExcelFile.Click += new System.EventHandler(this.loadExcelFile_Click);
            // 
            // openExcelFile
            // 
            this.openExcelFile.DefaultExt = "xlsx";
            this.openExcelFile.SupportMultiDottedExtensions = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 35);
            this.label2.TabIndex = 6;
            this.label2.Text = "Стартирай";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(182, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 35);
            this.label3.TabIndex = 7;
            this.label3.Text = "Зареди файл";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(337, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 35);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kill Excel";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 338);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loadExcelFile);
            this.Controls.Add(this.killExcelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(ExceptionLabel);
            this.Controls.Add(this.startReplacing);
            this.MinimumSize = new System.Drawing.Size(456, 377);
            this.Name = "Form1";
            this.Text = "PZN - Добавяне на контролна цифра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startReplacing;
        private TextBox filePathTextBox;
        private Label label1;
        private Button killExcelButton;
        private Button loadExcelFile;
        private OpenFileDialog openExcelFile;
        private Label label2;
        private Label label3;
        private Label label4;
        protected static Label ExceptionLabel;
    }
}


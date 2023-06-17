namespace CRUD_Operations
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            txtStudentName = new TextBox();
            label1 = new Label();
            StudentRecordDataGridView = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            txtRollNumber = new TextBox();
            label3 = new Label();
            txtAddress = new TextBox();
            label4 = new Label();
            txtCourse = new TextBox();
            label5 = new Label();
            txtPhoneNumber = new TextBox();
            ((System.ComponentModel.ISupportInitialize)StudentRecordDataGridView).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(32, 296);
            button1.Name = "button1";
            button1.Size = new Size(139, 46);
            button1.TabIndex = 0;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(145, 58);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(209, 27);
            txtStudentName.TabIndex = 1;
            txtStudentName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 61);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 2;
            label1.Text = "Student name :";
            // 
            // StudentRecordDataGridView
            // 
            StudentRecordDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StudentRecordDataGridView.Location = new Point(30, 366);
            StudentRecordDataGridView.Name = "StudentRecordDataGridView";
            StudentRecordDataGridView.RowHeadersWidth = 51;
            StudentRecordDataGridView.RowTemplate.Height = 29;
            StudentRecordDataGridView.Size = new Size(645, 188);
            StudentRecordDataGridView.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(200, 296);
            button2.Name = "button2";
            button2.Size = new Size(139, 46);
            button2.TabIndex = 4;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(368, 296);
            button3.Name = "button3";
            button3.Size = new Size(139, 46);
            button3.TabIndex = 5;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(536, 296);
            button4.Name = "button4";
            button4.Size = new Size(139, 46);
            button4.TabIndex = 6;
            button4.Text = "Reset";
            button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 110);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 8;
            label2.Text = "Roll No  :";
            // 
            // txtRollNumber
            // 
            txtRollNumber.Location = new Point(145, 107);
            txtRollNumber.Name = "txtRollNumber";
            txtRollNumber.Size = new Size(209, 27);
            txtRollNumber.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 159);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 10;
            label3.Text = "Address :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(145, 156);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(209, 27);
            txtAddress.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(405, 65);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 12;
            label4.Text = "Course :";
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(482, 61);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(209, 27);
            txtCourse.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(368, 113);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 14;
            label5.Text = "Phone number:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(482, 110);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(209, 27);
            txtPhoneNumber.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(712, 575);
            Controls.Add(label5);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label4);
            Controls.Add(txtCourse);
            Controls.Add(label3);
            Controls.Add(txtAddress);
            Controls.Add(label2);
            Controls.Add(txtRollNumber);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(StudentRecordDataGridView);
            Controls.Add(label1);
            Controls.Add(txtStudentName);
            Controls.Add(button1);
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student information";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)StudentRecordDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtStudentName;
        private Label label1;
        private DataGridView StudentRecordDataGridView;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label2;
        private TextBox txtRollNumber;
        private Label label3;
        private TextBox txtAddress;
        private Label label4;
        private TextBox txtCourse;
        private Label label5;
        private TextBox txtPhoneNumber;
    }
}
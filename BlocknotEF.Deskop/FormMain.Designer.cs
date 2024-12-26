namespace BlocknotEF.Deskop
{
    partial class FormMain
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
            listBox1 = new ListBox();
            txtName = new TextBox();
            label1 = new Label();
            txtPhone = new TextBox();
            label2 = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(1065, 58);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(551, 906);
            listBox1.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(335, 58);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 47);
            txtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 63);
            label1.Name = "label1";
            label1.Size = new Size(104, 41);
            label1.TabIndex = 2;
            label1.Text = "Name:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(335, 184);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 47);
            txtPhone.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(159, 189);
            label2.Name = "label2";
            label2.Size = new Size(103, 41);
            label2.TabIndex = 2;
            label2.Text = "Phone";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.OliveDrab;
            btnSave.Location = new Point(335, 296);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(250, 58);
            btnSave.TabIndex = 3;
            btnSave.Text = "Add";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1628, 1047);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(listBox1);
            Name = "FormMain";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox txtName;
        private Label label1;
        private TextBox txtPhone;
        private Label label2;
        private Button btnSave;
    }
}

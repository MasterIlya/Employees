namespace Employees
{
    partial class Employees
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Report = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Posts = new System.Windows.Forms.ComboBox();
            this.OnFiltrCheck = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(776, 343);
            this.dataGridView1.TabIndex = 0;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(3, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(188, 29);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Удалить Сотрудника";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(3, 38);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(188, 29);
            this.Add.TabIndex = 2;
            this.Add.Text = "Добавить Сотрудника";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Report
            // 
            this.Report.Location = new System.Drawing.Point(197, 3);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(191, 29);
            this.Report.TabIndex = 3;
            this.Report.Text = "Отчет";
            this.Report.UseVisualStyleBackColor = true;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Posts);
            this.panel1.Controls.Add(this.OnFiltrCheck);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 77);
            this.panel1.TabIndex = 4;
            // 
            // Posts
            // 
            this.Posts.Enabled = false;
            this.Posts.FormattingEnabled = true;
            this.Posts.Location = new System.Drawing.Point(204, 23);
            this.Posts.Name = "Posts";
            this.Posts.Size = new System.Drawing.Size(151, 28);
            this.Posts.TabIndex = 1;
            this.Posts.UseWaitCursor = true;
            this.Posts.SelectedIndexChanged += new System.EventHandler(this.Posts_SelectedIndexChanged);
            // 
            // OnFiltrCheck
            // 
            this.OnFiltrCheck.AutoSize = true;
            this.OnFiltrCheck.Location = new System.Drawing.Point(16, 15);
            this.OnFiltrCheck.Name = "OnFiltrCheck";
            this.OnFiltrCheck.Size = new System.Drawing.Size(152, 44);
            this.OnFiltrCheck.TabIndex = 0;
            this.OnFiltrCheck.Text = "Включить фильтр\r\nпо должности";
            this.OnFiltrCheck.UseVisualStyleBackColor = true;
            this.OnFiltrCheck.CheckedChanged += new System.EventHandler(this.OnFiltrCheck_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Update);
            this.panel2.Controls.Add(this.Report);
            this.panel2.Controls.Add(this.Add);
            this.panel2.Controls.Add(this.Delete);
            this.panel2.Location = new System.Drawing.Point(397, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 77);
            this.panel2.TabIndex = 5;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(197, 38);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(191, 29);
            this.Update.TabIndex = 4;
            this.Update.Text = "Сохранить изменения";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Employees";
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.Employees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button Delete;
        private Button Add;
        private Button Report;
        private Panel panel1;
        private ComboBox Posts;
        private CheckBox OnFiltrCheck;
        private Panel panel2;
        private Button Update;
    }
}
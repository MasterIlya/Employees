using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.Reporting.WinForms;

namespace Employees
{
    public partial class Employees : Form
    {

        private string connectionString;

        private SqlConnection sqlConnection;

        private SqlCommandBuilder sqlCommandBuilder;

        private SqlDataAdapter sqlDataAdapter;

        public DataSet dataSet;

        Report report;

        public Employees()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Employees", sqlConnection);

                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlCommandBuilder.GetInsertCommand();
                sqlCommandBuilder.GetUpdateCommand();
                sqlCommandBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "Employees");

                dataGridView1.DataSource = dataSet.Tables["Employees"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData()
        {
            try
            {
                dataSet.Tables["Employees"].Clear();

                sqlDataAdapter.Fill(dataSet, "Employees");

                dataGridView1.DataSource = dataSet.Tables["Employees"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            //To Do need to use user secrets
            string pathToCurrentDirectory = Path.GetFullPath("../../../Employees.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={pathToCurrentDirectory};Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            LoadData();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.Rows.Count - 2;

            DataRow dataRow = dataSet.Tables["Employees"].NewRow();

            dataRow["FName"] = dataGridView1.Rows[rowIndex].Cells["FName"].Value;
            dataRow["LName"] = dataGridView1.Rows[rowIndex].Cells["LName"].Value;
            dataRow["Post"] = dataGridView1.Rows[rowIndex].Cells["Post"].Value;
            dataRow["BirthDate"] = dataGridView1.Rows[rowIndex].Cells["BirthDate"].Value;
            dataRow["Salary"] = dataGridView1.Rows[rowIndex].Cells["Salary"].Value;

            dataSet.Tables["Employees"].Rows.Add(dataRow);

            dataGridView1.Rows.RemoveAt(rowIndex);

            sqlDataAdapter.Update(dataSet, "Employees");

            ReloadData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridView1.CurrentCell.RowIndex;
            if (currentIndex != null)
            {
                if (MessageBox.Show($"Вы точно хотите изменить {currentIndex + 1} строку", "Изменение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataSet.Tables["Employees"].Rows[currentIndex]["FName"] = dataGridView1.Rows[currentIndex].Cells["FName"].Value;
                    dataSet.Tables["Employees"].Rows[currentIndex]["LName"] = dataGridView1.Rows[currentIndex].Cells["LName"].Value;
                    dataSet.Tables["Employees"].Rows[currentIndex]["Post"] = dataGridView1.Rows[currentIndex].Cells["Post"].Value;
                    dataSet.Tables["Employees"].Rows[currentIndex]["BirthDate"] = dataGridView1.Rows[currentIndex].Cells["BirthDate"].Value;
                    dataSet.Tables["Employees"].Rows[currentIndex]["Salary"] = dataGridView1.Rows[currentIndex].Cells["Salary"].Value;

                    sqlDataAdapter.Update(dataSet, "Employees");

                    ReloadData();
                };
            }
            else
            {
                MessageBox.Show("Ошибка! Выберите строку для которой хотите сохранить изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridView1.CurrentCell.RowIndex;
            if(currentIndex != null)
            {
                if(MessageBox.Show($"Вы точно хотите удалить {currentIndex + 1} строку", "Удаление",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(currentIndex);

                    dataSet.Tables["Employees"].Rows[currentIndex].Delete();

                    sqlDataAdapter.Update(dataSet, "Employees");

                    ReloadData();
                };
            }
            else
            {
                MessageBox.Show("Ошибка! Выберите строку которую хотите удалить.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFiltrCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(OnFiltrCheck.Checked)
            {
                Posts.Enabled = true;
                Add.Enabled = false;
                Delete.Enabled = false;
                Update.Enabled = false;
                Report.Enabled = false;
                HashSet<string> posts = new HashSet<string>();
                for(int i = 0; i < dataSet.Tables["Employees"].Rows.Count; i++)
                {
                    string value = (string)dataSet.Tables["Employees"].Rows[i]["Post"];
                    posts.Add(value);
                }

                Posts.DataSource = posts.ToList();

                DataView view = new DataView(dataSet.Tables["Employees"]);
                view.RowFilter = $"Post = '{Posts.Items[0]}'";
                dataGridView1.DataSource = view;

            }
            else
            {
                Posts.DataSource = null;
                Posts.Enabled = false;
                Add.Enabled = true;
                Delete.Enabled = true;
                Update.Enabled = true;
                Report.Enabled = true;
                ReloadData();
            }
        }

        private void Posts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = Posts.SelectedIndex;
            DataView view = new DataView(dataSet.Tables["Employees"]);
            view.RowFilter = $"Post = '{Posts.Items[selectedIndex]}'";
            dataGridView1.DataSource = view;
        }

        private void Report_Click(object sender, EventArgs e)
        {
            if (report == null || report.IsDisposed)
                report = new Report();
            report.ShowDialog(this);
        }
    }
}
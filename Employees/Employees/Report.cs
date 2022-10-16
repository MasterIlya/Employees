using Microsoft.Reporting.WinForms;
using System.Data;
using System.Text;


namespace Employees
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.Controls.Add(this.reportViewer1);

            reportViewer1.Width = 776;
            reportViewer1.Height = 426;
            reportViewer1.Left = 10;
            reportViewer1.Top = 10;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            Employees main = this.Owner as Employees;

            if (main != null)
            {
                DataSet ds = main.dataSet;

                Dictionary<string, decimal> avaregeSalalryByPost = new Dictionary<string, decimal>();
                HashSet<string> posts = new HashSet<string>();

                for (int i = 0; i < ds.Tables["Employees"].Rows.Count; i++)
                {
                    string value = (string)ds.Tables["Employees"].Rows[i]["Post"];
                    posts.Add(value);
                }

                var newPosts = posts.ToList();

                for (int i = 0; i < newPosts.Count; i++)
                {  
                    int count = 0;
                    decimal salary = 0;
                    for (int j = 0; j < ds.Tables["Employees"].Rows.Count; j++)
                    {
                        if (ds.Tables["Employees"].Rows[j]["Post"] == newPosts[i])
                        {
                            count++;
                            salary += (decimal)ds.Tables["Employees"].Rows[j]["Salary"];
                        }
                    }
                    avaregeSalalryByPost.Add(newPosts[i], salary/count);
                }

                StringBuilder reportString = new StringBuilder();

                for (int i = 0; i < avaregeSalalryByPost.Count; i++)
                {
                    reportString.AppendLine($"{newPosts[i]} : {avaregeSalalryByPost[newPosts[i]]} Br;");
                }
                reportViewer1.LocalReport.ReportPath = "../../../Report.rdlc";
                ReportParameter report = new ReportParameter("reportString", reportString.ToString());
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { report });
                reportViewer1.RefreshReport();

            }
        }
    }
}
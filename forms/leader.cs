using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ES_projects
{
    public partial class leader : Form
    {
        public leader(string name)
        {
            InitializeComponent();
            string connectionstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";
            string projectName = "";
            using (SqlConnection connection = new SqlConnection(connectionstr))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM AssignDetail where teamLeader = @name"; // Select the columns you need

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projectName = reader["pname"].ToString();

                        }
                    }
                }
            }
            projData(projectName);
        }

        private void projData(string projName)
        {
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Bug where pname = @pname"; // Select the columns you need

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@pname", projName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string projectName = reader["pname"].ToString();
                            string type = reader["Bugtype"].ToString();
                            string desc = reader["BugDescription"].ToString();

                            label6.Text = projectName;
                            label7.Text = type; 
                            label8.Text = desc;
                        }
                    }
                }
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void leader_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

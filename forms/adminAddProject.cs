using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ES_projects
{
    public partial class adminAddProject : Form
    {
        public adminAddProject()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            adminDashboard form= new adminDashboard();
            form.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            adminDashboard form = new adminDashboard();
            form.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string detail = textBox2.Text;
            string des = textBox3.Text;

            // Replace the connection string with the correct one for your database.
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string insertQuery = "INSERT INTO ADDProjects  (projName, projDetail, projDescription) VALUES (@Designation, @Name, @Password)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Designation", name);
                    cmd.Parameters.AddWithValue("@Name", detail);
                    cmd.Parameters.AddWithValue("@Password", des);

                    cmd.ExecuteNonQuery(); // Execute the INSERT query.
                }
            }
            this.Hide();
            adminDashboard form = new adminDashboard();
            form.ShowDialog();
        }
    }
}

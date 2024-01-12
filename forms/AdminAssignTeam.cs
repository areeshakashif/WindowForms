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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ES_projects
{
    public partial class AdminAssignTeam : Form
    {
        public AdminAssignTeam()
        {
            InitializeComponent();
            populate();
            populate2();
            populateprog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            adminDashboard form = new adminDashboard();
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
            string proj = comboBox1.Text;
            string programmer = comboBox2.Text;
            string leader = comboBox3.Text;

            // Replace the connection string with the correct one for your database.
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string insertQuery = "INSERT INTO AssignDetail (pname, programmer, teamleader) VALUES (@Designation, @Name, @Password)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Designation", proj);
                    cmd.Parameters.AddWithValue("@Name", programmer);
                    cmd.Parameters.AddWithValue("@Password", leader);

                    cmd.ExecuteNonQuery(); // Execute the INSERT query.
                }
            }
            this.Hide();
            adminDashboard form = new adminDashboard();
            form.ShowDialog();
        }
        private void populate()
        {
            string proj = "";
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM ADDProjects"; // Select the columns you need

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            proj = reader["projName"].ToString();
                            comboBox1.Items.Add(proj);
                        }
                    }
                }
            }
        }
        private void populate2()
        {
            string leader = "";
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";
            string l = "Project Leader";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employee where Designation=@des "; // Select the columns you need

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@des", l);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            leader = reader["Name"].ToString();
                            comboBox3.Items.Add(leader);
                        }
                    }
                }
            }
        }
        private void populateprog()
        {
            string programmer = "";
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";
            string l = "Programmer";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employee where Designation=@des "; // Select the columns you need

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@des", l);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            programmer = reader["Name"].ToString();
                            comboBox2.Items.Add(programmer);
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AdminAssignTeam_Load(object sender, EventArgs e)
        {

        }
    }
}

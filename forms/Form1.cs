using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ES_projects
{
    public partial class Form1 : Form
    {
        private bool showDropdownButton_Click;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void cshowDropdownButton_Click(object sender, EventArgs e)
        {
            string des = comboBox1.Text;
            string name = textBox1.Text;
            string pass = textBox2.Text;
            
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm signUpForm = new SignUpForm();

            // Show the SignupForm
            signUpForm.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;
            string designation = comboBox1.Text;

            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employee WHERE Name = @name AND Password = @password AND Designation = @designation";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", pass);
                    cmd.Parameters.AddWithValue("@designation", designation);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Credentials and designation exist, proceed to the respective form.
                            this.Hide();
                            if (designation == "Admin")
                            {
                                adminDashboard ad = new adminDashboard();
                                ad.ShowDialog();
                            }
                            else if (designation == "Programmer")
                            {
                                prgrammer ad = new prgrammer(name);
                                ad.ShowDialog();
                            }
                            else if (designation == "Project Leader")
                            {
                                leader ad = new leader(name);
                                ad.ShowDialog();
                            }
                        }
                        else
                        {
                            // Credentials or designation don't exist, inform the user and allow them to enter data again.
                            MessageBox.Show("Invalid credentials or designation. Please enter the correct information.");
                        }
                    }
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

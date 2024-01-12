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
using Microsoft.Identity.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace ES_projects
{
    public partial class prgrammer : Form
    {
        public prgrammer(string programmer)
        {
            InitializeComponent();
            progData(programmer);
            
        }
        private void progData(string programmer) {
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT pname FROM AssignDetail where programmer = @programmer"; // Select the columns you need

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@programmer", programmer);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            label6.Text = reader["pname"].ToString();
                        }
                    }
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string bugType = comboBox2.Text;
            //string bugDesc = textBox1.Text;
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Bug (pname, Bugtype, BugDescription) VALUES (@pname, @BugType, @BugDescription)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@pname", label6.Text);
                    cmd.Parameters.AddWithValue("@BugType", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@BugDescription", textBox1.Text);

                    cmd.ExecuteNonQuery(); // Execute the INSERT query.
                    MessageBox.Show("Bug added");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
            
        }

        private void prgrammer_Load(object sender, EventArgs e)
        {

        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ES_projects
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string des = comboBox1.Text;
            string name = textBox1.Text;
            string pass = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string des = comboBox1.Text;
            //string name = textBox1.Text;
            //string pass = textBox2.Text;

            //// Replace the connection string with the correct one for your database.
            //string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\HAMZA FAROOQI\\DESKTOP\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            //using (SqlConnection connection = new SqlConnection(connectionstring))
            //{
            //    connection.Open();
            //    string insertQuery = "INSERT INTO Employee (Designation, Name, Password) VALUES (@Designation, @Name, @Password)";

            //    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            //    {
            //        cmd.Parameters.AddWithValue("@Designation", des);
            //        cmd.Parameters.AddWithValue("@Name", name);
            //        cmd.Parameters.AddWithValue("@Password", pass);

            //        cmd.ExecuteNonQuery(); // Execute the INSERT query.
            //    }
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string des = comboBox1.Text;
            string name = textBox1.Text;
            string pass = textBox2.Text;

            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\AR\\DOWNLOADS\\ES PROJECTS\\DATABASE1.MDF;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Check if the username already exists in the table.
                string checkUserQuery = "SELECT COUNT(*) FROM Employee WHERE Name = @Name";

                using (SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, connection))
                {
                    checkUserCmd.Parameters.AddWithValue("@Name", name);
                    int userCount = (int)checkUserCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        // Username already exists, inform the user and allow them to enter data again.
                        MessageBox.Show("Username already exists. Please choose a different username.");
                        return;
                    }
                }

                // Check if the password length is less than 8 characters.
                if (pass.Length < 8)
                {
                    // Password length is less than 8 characters, inform the user and allow them to enter data again.
                    MessageBox.Show("Password must be at least 8 characters long.");
                    textBox2.Text = ""; // Clear the password field.
                    return;
                }

                // If both checks passed, proceed with inserting the data.
                string insertQuery = "INSERT INTO Employee (Designation, Name, Password) VALUES (@Designation, @Name, @Password)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Designation", des);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Password", pass);

                    cmd.ExecuteNonQuery(); // Execute the INSERT query.
                }
            }

            // After successful insertion, hide the form and show Form1.
            this.Hide();
            adminDashboard form = new adminDashboard();
            form.ShowDialog();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}

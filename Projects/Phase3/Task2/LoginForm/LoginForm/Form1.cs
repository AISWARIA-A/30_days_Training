using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\Aiswaria A\Desktop\30_days_Training\Databases\EDUHUB.mdf'; Integrated Security=True; Connect Timeout=30;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter sd = new SqlDataAdapter("SELECT COUNT(*) FROM Logins WHERE Username ='"+textBox1.Text+"' AND Password= '"+textBox2.Text+"'",con ); 
                DataTable dt = new DataTable();
                sd.Fill(dt);

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter the usernamme");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter the password");
                }
                else if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Home home = new();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            

        }
    }
}
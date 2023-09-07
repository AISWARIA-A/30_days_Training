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

namespace CRUDOperations
{
    public partial class Form1 : Form
    {
        public int StudentID = 1;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\Aiswaria A\Desktop\30_days_Training\Databases\EDUHUB.mdf'; Integrated Security=True; Connect Timeout=30;";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }

        private void GetStudentsRecord()
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\Aiswaria A\Desktop\30_days_Training\Databases\EDUHUB.mdf'; Integrated Security=True; Connect Timeout=30;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Isvalid())
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\Aiswaria A\Desktop\30_days_Training\Databases\EDUHUB.mdf'; Integrated Security=True; Connect Timeout=30;";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("INSERT INTO Students(Name, FatherName,Address,Phone) VALUES (@firstname,@lastname,@address,@mobile)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                cmd.Parameters.AddWithValue("@mobile", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox5.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close() ;

                MessageBox.Show("Successfully saved in the database","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                this.studentsTableAdapter.Fill(this.eDUHUBDataSet.Students);

            }
        }

        private bool Isvalid()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("First name is required","Failed", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eDUHUBDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.eDUHUBDataSet.Students);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }
    }
}

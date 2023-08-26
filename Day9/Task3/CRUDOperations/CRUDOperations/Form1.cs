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

        private void button2_Click(object sender, EventArgs e)
        {
            if(StudentID > 0)
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\Aiswaria A\Desktop\30_days_Training\Databases\EDUHUB.mdf'; Integrated Security=True; Connect Timeout=30;";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Students SET Name = @firstname,FatherName = @lastname,Address = @address,Phone = @mobile WHERE Id = @id)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                cmd.Parameters.AddWithValue("@mobile", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox5.Text);
                cmd.Parameters.AddWithValue("id", this.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfully updated", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();

            }
            else
            {
                MessageBox.Show("Please select a student to update");
            }
        }

        private void StudentRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            button1.Text = "Update Student";
        }

    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        if (StudentID > 0)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Students_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", this.StudentID);

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student is deleted from the system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            GetStudentsRecord();
            ResetFormControls();
        }
        else
        {
            MessageBox.Show("Please Select an student to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}

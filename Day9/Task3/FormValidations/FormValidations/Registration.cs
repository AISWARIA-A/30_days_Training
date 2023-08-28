using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormValidations
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail(textBox1.Text);
        }

        private void ValidateEmail(string email)
        {
            if (IsValidEmail(email))
            {
                errorProvider5.SetError(textBox1, "");
            }
            else
            {
                errorProvider5.SetError(textBox1, "Invalid email address");
            }
        }

        private bool IsValidEmail(string email)
        {
            // Use a regular expression to validate email format
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private void textBoxUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBoxUsername, "Username is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBoxUsername, "");
            }
        }

        private void textBoxFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBoxFirstName, "First name is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBoxFirstName, "");
            }
        }

        private void textBoxLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBoxLastName, "Last name is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBoxLastName, "");
            }
        }

        private void dateTimePickerDOB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DateTime selectedDate = dateTimePickerDOB.Value.Date;
            if (selectedDate >= DateTime.Now.Date)
            {
                e.Cancel = true;
                errorProvider.SetError(dateTimePickerDOB, "Please select a valid future date.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(dateTimePickerDOB, "");
            }
        }

        private void textBoxPassword2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox.Text != textBoxConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider7.SetError(textBoxConfirmPassword, "Passwords do not match.");
            }
            else
            {
                e.Cancel = false;
                errorProvider7.SetError(textBoxConfirmPassword, "");
            }
        }
    }
}

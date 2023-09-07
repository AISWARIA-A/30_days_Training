using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            textBoxFirstName_Validating(textBox1.Text, new CancelEventArgs());
        }

        private void ValidateEmail(string email)
        {
            if (IsValidEmail(email))
            {
                errorProvider1.SetError(textBox6, "");
            }
            else
            {
                errorProvider1.SetError(textBox6, "Invalid email address");
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private void textBoxUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider3.SetError(textBox4, "Username is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textBox4, "");
            }
        }

        private void textBoxFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidFirstName(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "First name should contain only letters.");
                e.Cancel = true; // Cancel event to prevent losing focus
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                e.Cancel = false; // Continue with event
            }
        }

        private bool IsValidFirstName(string input)
        {
            return input.All(char.IsLetter);
        }



        private void textBoxLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidFirstName(textBox2.Text))
            {
                errorProvider3.SetError(textBox2, "First name should contain only letters.");
                e.Cancel = true; 
            }
            else
            {
                errorProvider3.SetError(textBox2, "");
                e.Cancel = false; 
            }
        }

        private void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DateTime.TryParseExact(textBox3.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime selectedDate))
            {
                // Invalid date format
                e.Cancel = true;
                errorProvider4.SetError(textBox3, "Invalid date format. Please enter a valid date in the format 'yyyy-MM-dd'.");
            }
            else if (selectedDate > DateTime.Now)
            {
                // Date is a future date
                e.Cancel = true;
                errorProvider4.SetError(textBox3, "Please enter a valid past or current date.");
            }
            else
            {
                // Valid date
                e.Cancel = false;
                errorProvider4.SetError(textBox3, "");

                int age = CalculateAge(selectedDate);
                textBox4.Text = age.ToString(); 
            }
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dateOfBirth.Year;

            if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
            {
                age--; 
            }

            return age;
        }


        private void confirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox13.Text != textBox12.Text)
            {
                e.Cancel = true;
                errorProvider4.SetError(textBox13, "");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(textBox13, "");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail(textBox6.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBoxLastName_Validating(textBox2.Text, new CancelEventArgs());
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3_Validating(textBox3.Text, new CancelEventArgs());
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            confirmPassword_Validating(textBox13.Text, new CancelEventArgs());
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (IsPasswordValid(textBox9.Text))
            {
                errorProvider7.SetError(textBox9, "");
            }
            else
            {
                errorProvider7.SetError(textBox9, "Password must have at least 7 characters including a special character, a number, and an uppercase letter.");
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            confirmPassword_Validating(textBox13.Text, new CancelEventArgs());
        }

        private void textBox13_Validating(object sender, CancelEventArgs e)
        {
            confirmPassword_Validating(textBox13.Text, new CancelEventArgs());
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (IsPhoneNumberValid(textBox7.Text))
            {
                errorProvider5.SetError(textBox7, "");
            }
            else
            {
                errorProvider5.SetError(textBox7, "Phone number must have 10 digits.");
            }
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            // Remove any non-digit characters from the phone number
            string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Check if the phone number has exactly 10 digits
            return digitsOnly.Length == 10;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (IsUsernameValid(textBox10.Text))
            {
                errorProvider6.SetError(textBox10, "");
            }
            else
            {
                errorProvider6.SetError(textBox10, "Username must have at least 6 characters including a capital letter, a number, and a special character.");
            }
        }

        private bool IsUsernameValid(string username)
        {
            if (username.Length < 6)
            {
                return false;
            }

            bool hasCapitalLetter = false;
            bool hasNumber = false;
            bool hasSpecialCharacter = false;

            foreach (char c in username)
            {
                if (char.IsUpper(c))
                {
                    hasCapitalLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
                else if (!char.IsLetterOrDigit(c))
                {
                    hasSpecialCharacter = true;
                }
            }

            return hasCapitalLetter && hasNumber && hasSpecialCharacter;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool IsPasswordValid(string password)
        {
            if (password.Length < 7)
            {
                return false;
            }

            bool hasSpecialCharacter = false;
            bool hasNumber = false;
            bool hasUpperCase = false;

            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    hasSpecialCharacter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
                else if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
            }

            return hasSpecialCharacter && hasNumber && hasUpperCase;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != textBox12.Text)
            {

                errorProvider4.SetError(textBox13, "Passwords does not match");
            }
            else
            {
                errorProvider4.SetError(textBox13, "");
                this.Hide();
                Home home = new Home();
                home.Show();

            }
        }

        private void textBox13_MouseLeave(object sender, EventArgs e)
        {

        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text != textBox12.Text)
            {

                errorProvider4.SetError(textBox13, "Passwords do not match.");
            }
            else
            {
                errorProvider4.SetError(textBox13, "");
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace registrationCRUD
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=LAPTOP-P7FT8L5E\\SQLEXPRESS;Initial Catalog=registrationCRUD;Integrated Security=True");
        private ErrorProvider errorProvider;
        public Form1()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();

            txtFirstname.TextChanged += txtFirstname_TextChanged;
            txtLastname.TextChanged += txtLastname_TextChanged;
            txtAge.TextChanged += txtAge_TextChanged;
            txtState.TextChanged += txtState_TextChanged;
            txtCity.TextChanged += txtCity_TextChanged;
            txtPhonenumber.TextChanged += txtPhonenumber_TextChanged;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtConfirmpassword.TextChanged += txtConfirmpassword_TextChanged;
            txtEmail.TextChanged += txtEmail_TextChanged;
        }

        public int id;
        private void Form1_Load(object sender, EventArgs e)
        {
            GetUserRecord();
            

        }

        private void GetUserRecord()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from  registrationtb", con);
            DataTable dt = new DataTable();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            userRecordDataGridView.DataSource = dt;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (IsValid())
            {
              SqlCommand cmd = new SqlCommand("insert into registrationtb values(@first_name,@last_name,@date_of_birth,@age,@gender,@state,@city,@phone_number,@email,@password,@confirm_password)", con);
                cmd.Parameters.AddWithValue("@first_name", txtFirstname.Text);
                cmd.Parameters.AddWithValue("@last_name", txtLastname.Text);
                cmd.Parameters.AddWithValue("@date_of_birth", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
                if (rbMale.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Male");
                }
                else if (rbFemale.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Female");
                }
                else if (rbOther.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Other");
                }
                cmd.Parameters.AddWithValue("@state", txtState.Text);
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                cmd.Parameters.AddWithValue("@phone_number", txtPhonenumber.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@confirm_password", txtConfirmpassword.Text);

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Registration Successfull","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                GetUserRecord();
                ResetFormControls();
                errorProvider.Clear();


            }

        }
        


        private bool IsValid()
        {
           

            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                errorProvider.SetError(txtFirstname, "First name is required");

                return false;
            }
            else if (txtFirstname.Text.Any(char.IsDigit))
            {

                errorProvider.SetError(txtFirstname, "Digits are not allowed");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLastname.Text))

            {
                errorProvider.SetError(txtLastname, "Last name is required");
                return false;

            }
            else if (txtLastname.Text.Any(char.IsDigit))
            {
                errorProvider.SetError(txtLastname, "Digits are not allowed");
                return false;
            }
            else if (dateTimePicker1.Value == DateTime.MaxValue)
            {
                errorProvider.SetError(dateTimePicker1, "Date of birth is required");
                return false;

            }
            else if (txtAge.Text == string.Empty)
            {
                errorProvider.SetError(txtAge, "Age is required");
                return false;

            }
            else if (txtState.Text == string.Empty)
            {
                errorProvider.SetError(txtState, "State is required");
                return false;

            }
            else if (txtCity.Text == string.Empty)
            {
                errorProvider.SetError(txtCity, "City is required");
                return false;
            }
            else if (txtPhonenumber.Text == string.Empty)
            {
                errorProvider.SetError(txtPhonenumber, "Phone number is required");
                return false;

            }
            else if (!Regex.IsMatch(txtPhonenumber.Text, @"^\d{10}$"))
            {
                errorProvider.SetError(txtPhonenumber, "Please provide a valid 10-digit phone number");
                return false;
            }
            else if (txtEmail.Text == string.Empty)
            {
                errorProvider.SetError(txtEmail, "Email is required");
                return false;

            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider.SetError(txtEmail, "Please provide a valid email address");
                return false;
            }

            else if (txtPassword.Text == string.Empty)
            {
                errorProvider.SetError(txtPassword, "Password is required");
                return false;

            }
            else if (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
            {
                errorProvider.SetError(txtPassword, "\"Please enter a valid password. It should contain at least one uppercase letter, one lowercase letter, one digit, and be at least 8 characters long\"");
                return false;
            }
            else if (txtConfirmpassword.Text == string.Empty)
            {
                errorProvider.SetError(txtConfirmpassword, "Please confirm your password");
                return false;

            }
            else if (txtPassword.Text != txtConfirmpassword.Text)
            {
                errorProvider.SetError(txtConfirmpassword, "The password and confirm password entries do not match.");

                return false;
            }

            return true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtConfirmpassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtPhonenumber_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();

        }

        private void ResetFormControls()
        {
            id = 0;
            txtFirstname.Clear();
            txtLastname.Clear();
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            txtAge.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            rbOther.Checked = false;
            txtState.Clear();
            txtCity.Clear();
            txtPhonenumber.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmpassword.Clear();

            txtFirstname.Focus();
        }

        private void userRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {   

            id =  Convert.ToInt32( userRecordDataGridView.SelectedRows[0].Cells[0].Value);
            txtFirstname.Text = userRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtLastname.Text = userRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            string dateOfBirthString = userRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();

            DateTime dateOfBirth;
            if (DateTime.TryParse(dateOfBirthString, out dateOfBirth))
            {
                dateTimePicker1.Value = dateOfBirth;
            }


            float age = Convert.ToSingle(userRecordDataGridView.SelectedRows[0].Cells[4].Value);
            txtAge.Text = age.ToString();

            string gender = userRecordDataGridView.SelectedRows[0].Cells[5].Value.ToString();

            if (gender == "Male")
            {
                rbMale.Checked = true;
            }
            else if (gender == "Female")
            {
                rbFemale.Checked = true;
            }
            else if (gender == "Other")
            {
                rbOther.Checked = true;
            }

            txtState.Text = userRecordDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            txtCity.Text = userRecordDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            txtPhonenumber.Text = userRecordDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            txtEmail.Text = userRecordDataGridView.SelectedRows[0].Cells[9].Value.ToString();
            txtPassword.Text = userRecordDataGridView.SelectedRows[0].Cells[10].Value.ToString();
            txtConfirmpassword.Text = userRecordDataGridView.SelectedRows[0].Cells[11].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id > 0)
            {
                SqlCommand cmd = new SqlCommand("update registrationtb set first_name = @first_name,last_name = @last_name,date_of_birth = @date_of_birth,age = @age,gender = @gender,state = @state,city = @city,phone_number = @phone_number,email = @email,password = @password,confirm_password = @confirm_password where id=@id" , con);
                cmd.Parameters.AddWithValue("@first_name", txtFirstname.Text);
                cmd.Parameters.AddWithValue("@last_name", txtLastname.Text);
                cmd.Parameters.AddWithValue("@date_of_birth", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
                if (rbMale.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Male");
                }
                else if (rbFemale.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Female");
                }
                else if (rbOther.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Other");
                }
                cmd.Parameters.AddWithValue("@state", txtState.Text);
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                cmd.Parameters.AddWithValue("@phone_number", txtPhonenumber.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@confirm_password", txtConfirmpassword.Text);
                cmd.Parameters.AddWithValue("@id",this.id);


                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetUserRecord();
                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Please select a user to update information","select?",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id > 0)
            {
                SqlCommand cmd = new SqlCommand("delete from registrationtb where id=@id", con);
                cmd.Parameters.AddWithValue("@id", this.id);


                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User information deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetUserRecord();
                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Please select a user to delete", "select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - selectedDate.Year;

            if (currentDate.Month < selectedDate.Month || (currentDate.Month == selectedDate.Month && currentDate.Day < selectedDate.Day))
            {
                age--;
            }

            txtAge.Text = age.ToString();
        }
    }
}

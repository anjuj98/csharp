using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registrationCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-P7FT8L5E\\SQLEXPRESS;Initial Catalog=registrationCRUD;Integrated Security=True");
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


            }

        }

        private bool IsValid()
        {
            if(txtFirstname.Text == string.Empty)
            {
                MessageBox.Show("First name is required","Failed",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
    }
}

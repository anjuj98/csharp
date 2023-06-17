using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;



namespace CRUD_Operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-P7FT8L5E\\SQLEXPRESS;Initial Catalog=Application;Integrated Security=True");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }

        private void GetStudentsRecord()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentsTb ", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();


            StudentRecordDataGridView.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentsTb VALUES (@Name,@Course,@RollNumber,@Address,@PhoneNumber)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@Course",txtCourse.Text);
                cmd.Parameters.AddWithValue("@RollNumber",int.Parse(txtRollNumber.Text));
                cmd.Parameters.AddWithValue("@Address",txtAddress.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber",int.Parse(txtPhoneNumber.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New student successfully saved in the database","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);

                GetStudentsRecord();


            }
        }

        private bool isValid()
        {
            if(txtStudentName.Text == string.Empty)
            {
                MessageBox.Show("Student name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
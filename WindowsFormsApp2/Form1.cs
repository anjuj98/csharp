using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-P7FT8L5E\SQLEXPRESS;Initial Catalog=login;Integrated Security=True");
        private ErrorProvider errorProvider;

        public Form1()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();

            txt_username.TextChanged += txt_username_TextChanged;
            txt_password.TextChanged += txt_password_TextChanged;
        }


        private void button_login_Click(object sender, EventArgs e)
         {

            String username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;
            errorProvider.Clear();

            try
            {
                String querry = "SELECT * FROM Login WHERE username = '" + txt_username.Text + "' AND password = '"+ txt_password.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password = txt_password.Text;
                    menuform form2 = new menuform();
                    form2.Show();
                    this.Hide();
                }
                else if (string.IsNullOrWhiteSpace(txt_username.Text))
                {
                    errorProvider.SetError(txt_username, "Please provide a valid username");
                }
                
                else if (string.IsNullOrWhiteSpace(txt_password.Text))
                {
                    errorProvider.SetError(txt_password, "Please provide a valid password");
                }
                else
                { 

                MessageBox.Show("Please provide valid username and password ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();
                    txt_username.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            txt_username.Clear();
            txt_password.Clear();
            txt_username.Focus();
        }

    }
}

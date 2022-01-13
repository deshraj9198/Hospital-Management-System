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

namespace HospitalManagementSystem
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\onedrive\documents\visual studio 2012\Projects\HospitalManagementSystem\HospitalManagementSystem\HMS.mdf;Integrated Security=True;");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            con.Open();
            if (txt_Username.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {


                SqlCommand cmd = new SqlCommand("Select * from Login where Username = @Un and Password = @Pass", con);

                cmd.Parameters.AddWithValue("@Un", txt_Username.Text);
                cmd.Parameters.AddWithValue("@Pass", txt_Password.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int i = cmd.ExecuteNonQuery();
               
                if (dt.Rows.Count > 0)
                {

                 //   MessageBox.Show("welcome to database connection");
                    Record ss = new Record();
                    ss.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            con.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}

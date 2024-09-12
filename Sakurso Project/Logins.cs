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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Bunifu.UI.WinForms;

namespace Sakurso_Project
{
    public partial class Logins : Form
    { 
        public Logins()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = bunifuTextBox1.Text;
            user_password = bunifuTextBox2.Text;
            HighClass main = new HighClass();
            if(username!="" && user_password!="")
            {
                SqlCommand cmd = new SqlCommand("select * from Authorisation where UserMail=@mail and Password=@password",con);
                cmd.Parameters.AddWithValue("@mail", bunifuTextBox1.Text);
                cmd.Parameters.AddWithValue("@password", bunifuTextBox2.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    string usertype = dt.Rows[0][2].ToString();
                    if((usertype == "11") || (usertype=="10")||(usertype== "9")||(usertype == "8"))
                    {
                        main.ShowDialog();
                        this.Hide();
                    }
                    else if ((usertype == "7"))
                    {
                        Sawyobi sawyobi= new Sawyobi();
                        sawyobi.ShowDialog();
                        this.Hide();
                    }
                    else if ((usertype == "6"))
                    {
                        Maghazia maghazia= new Maghazia();
                        maghazia.ShowDialog();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("ელ-ფოსტა ან პაროლი არასწორია!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("გთხოვთ შეავსოთ გრაფები!");
                return;
            }
        }
    }
}

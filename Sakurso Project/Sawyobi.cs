using Bunifu.UI.WinForms;
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

namespace Sakurso_Project
{
    public partial class Sawyobi : Form
    {
        public Sawyobi()
        {
            InitializeComponent();
        }

        private void Sawyobi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moderntechnics_DataSet.Sawyobi' table. You can move, or remove it, as needed.
            this.sawyobiTableAdapter.Fill(this.moderntechnics_DataSet.Sawyobi);

        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ნამდვილად გნებავთ პროგრამის დახურვა ?", "ყურადღება!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void bunifuFormCaptionButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Logins logss = new Logins();
            logss.Show();
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Sawyobi values (@Produqtis_dasaxeleba,@Gamoshvebis_tarighi,@Mwarmoebeli,@Produqtis_maragi)", con);
                cmd.Parameters.AddWithValue("@Produqtis_dasaxeleba", bunifuTextBox2.Text);
                cmd.Parameters.AddWithValue("@Gamoshvebis_tarighi", bunifuTextBox3.Text);
                cmd.Parameters.AddWithValue("@Mwarmoebeli", bunifuTextBox4.Text);
                cmd.Parameters.AddWithValue("@Produqtis_maragi", int.Parse(bunifuTextBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("მონაცემები წარმატებით შეინახა!");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuTextBox4.Text = "";
            bunifuTextBox5.Text = "";

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                bunifuTextBox1.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value; //User
                bunifuTextBox2.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value; //Password
                bunifuTextBox3.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value; //Role
                bunifuTextBox4.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value; //User
                bunifuTextBox5.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value; //Password
            }

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Sawyobi where ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", bunifuTextBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bunifuDataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int Raod;
                SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
                con.Open();
                string asql = "update Sawyobi set Produqtis_dasaxeleba='" + bunifuTextBox2.Text + "',Gamoshvebis_tarighi='" + bunifuTextBox3.Text + "',Mwarmoebeli='" + bunifuTextBox4.Text + "',Produqtis_maragi='" + int.Parse(bunifuTextBox5.Text) + "'where ID=" + bunifuDataGridView1.Rows[bunifuDataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                SqlCommand acom = new SqlCommand(asql, con);
                Raod = acom.ExecuteNonQuery();
                if (Raod > 0)
                {
                    MessageBox.Show("ჩანაწერი განახლებულია!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            int Raod;
            if (bunifuTextBox1.Text == "")
            {
                MessageBox.Show("აირჩიეთ ერთი სტრიქონი !");
                return;
            }
            if (MessageBox.Show("ნამდვილად გნებავთ არჩეული სტრიქონის წაშლა ?", "ყურადღება!!!", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
                con.Open();
                string asql = string.Format("delete from Sawyobi where ID=" + int.Parse(bunifuTextBox1.Text));
                SqlCommand acom = new SqlCommand(asql, con);
                //MessageBox.Show(asql);
                Raod = acom.ExecuteNonQuery();
                if (Raod > 0)
                {
                    MessageBox.Show("სტრიქონი წაიშალა !");
                }
                bunifuTextBox1.Text = "";
                bunifuTextBox2.Text = "";
                bunifuTextBox3.Text = "";
                bunifuTextBox4.Text = "";
                bunifuTextBox5.Text = "";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            string asql = "select*from Sawyobi";
            SqlCommand acom = new SqlCommand(asql, acon);
            DataSet ads = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(acom);
            ada.Fill(ads, "res");
            bunifuDataGridView1.DataSource = ads.Tables["res"];
            ada.Dispose();
            acon.Dispose();
        }
    }
}

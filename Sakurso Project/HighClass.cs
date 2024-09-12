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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sakurso_Project
{
    public partial class HighClass : Form
    {
        SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
        public HighClass()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moderntechnics_DataSet.Vakansia' table. You can move, or remove it, as needed.
            this.vakansiaTableAdapter.Fill(this.moderntechnics_DataSet.Vakansia);
            // TODO: This line of code loads data into the 'moderntechnics_DataSet.Momxmareblebi' table. You can move, or remove it, as needed.
            this.momxmareblebiTableAdapter.Fill(this.moderntechnics_DataSet.Momxmareblebi);
            // TODO: This line of code loads data into the 'moderntechnics_DataSet.Tanamdebobebi' table. You can move, or remove it, as needed.
            this.tanamdebobebiTableAdapter.Fill(this.moderntechnics_DataSet.Tanamdebobebi);
            // TODO: This line of code loads data into the 'moderntechnics_DataSet.Authorisation' table. You can move, or remove it, as needed.
            this.authorisationTableAdapter.Fill(this.moderntechnics_DataSet.Authorisation);
            // TODO: This line of code loads data into the 'moderntechnics_DataSet.Tanamshromlebi' table. You can move, or remove it, as needed.
            this.tanamshromlebiTableAdapter.Fill(this.moderntechnics_DataSet.Tanamshromlebi);
            bunifuPages1.PageIndex = 1;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            int Raod;
            try
            {
                SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
                string asql = "update Tanamshromlebi set Gvari='" + bunifuTextBox2.Text + "',Saxeli='" + bunifuTextBox3.Text + "',Dabadebistarighi='" + bunifuTextBox4.Text + "',Misamarti='" + bunifuTextBox5.Text + "',Telefonisnomeri='" + bunifuTextBox6.Text + "',elfosta='" + bunifuTextBox7.Text + "',Ojaxurimdgomareoba='" + bunifuDropdown2.Text + "',Tanamdeboba='" + bunifuDropdown1.Text + "',Xelfasi='" + bunifuTextBox8.Text + "'where Piradinomeri=" + bunifuDataGridView1.Rows[bunifuDataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                SqlCommand acom = new SqlCommand(asql, acon);
                //MessageBox.Show(acom.CommandText);
                acon.Open();
                Raod = acom.ExecuteNonQuery();
                if (Raod > 0)
                {
                    MessageBox.Show("ჩანაწერი განახლებულია!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("შეასწორეთ ერთი ჩანაწერი" + "აირჩიეთ რომელიმე გვარი," + "ცაკსახა სტუდ_ნომერი და " + "სხვა მონაცემები!!!");
            }
            acon.Close();
            datvaliereba();
        }
        private void ekranze_gamotana()
        {
            SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            string asql = "select * from Tanamshromlebi";
            SqlCommand acom = new SqlCommand(asql, acon);
            DataSet ads = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(acom);
            ada.Fill(ads, "res");
            bunifuDataGridView1.DataSource = ads.Tables["res"];
            ada.Dispose();
            acon.Dispose();
        }
        private void bunifuDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)// washla
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
                SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
                string asql = string.Format("delete from Tanamshromlebi where Piradinomeri=" + int.Parse(bunifuTextBox1.Text));
                SqlCommand acom = new SqlCommand(asql, acon);
                //MessageBox.Show(asql);
                acon.Open();
                Raod = acom.ExecuteNonQuery();
                if (Raod > 0)
                {
                    MessageBox.Show("სტრიქონი წაიშალა !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuTextBox4.Text = "";
            bunifuTextBox5.Text = "";
            bunifuTextBox6.Text = "";
            bunifuTextBox7.Text = "";
            bunifuDropdown2.Text = "";
            bunifuDropdown1.Text = "";
            bunifuTextBox8.Text = "";
            acon.Close();
        }
        private void datvaliereba()
        {
            try
            {
                acon.Open();
                SqlCommand acom = new SqlCommand();
                acom.CommandText = "select*from Tanamshromlebi";
                ekranze_gamotana();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            acon.Close();
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuTextBox4.Text = "";
            bunifuTextBox5.Text = "";
            bunifuTextBox6.Text = "";
            bunifuTextBox7.Text = "";
            bunifuDropdown2.Text = "";
            bunifuDropdown1.Text = "";
            bunifuTextBox8.Text = "";
        }

        private void bunifuButton2_Click(object sender, EventArgs e) // Refresh
        {
            SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            string asql = "select*from Tanamshromlebi";
            SqlCommand acom = new SqlCommand(asql, acon);
            DataSet ads = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(acom);
            ada.Fill(ads, "res");
            bunifuDataGridView1.DataSource = ads.Tables["res"];
            ada.Dispose();
            acon.Dispose();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            acon.Open();
            string asql = string.Format(@"Insert into Tanamshromlebi values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", 
                bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox4.Text, bunifuTextBox5.Text, 
                int.Parse(bunifuTextBox6.Text), bunifuTextBox7.Text, bunifuDropdown2.SelectedText.ToString(), 
                bunifuDropdown1.SelectedText.ToString(), float.Parse(bunifuTextBox8.Text));
            SqlCommand acom = new SqlCommand(asql, acon);
            acom.ExecuteNonQuery();
            MessageBox.Show("მონაცემები წარმატებით შეინახა!");
            acon.Close();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuTextBox4.Text = "";
            bunifuTextBox5.Text = "";
            bunifuTextBox6.Text = "";
            bunifuTextBox7.Text = "";
            bunifuDropdown2.Text = "";
            bunifuDropdown1.Text = "";
            bunifuTextBox8.Text = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                bunifuTextBox1.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value; //piradinom
                bunifuTextBox2.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value; //Gvari
                bunifuTextBox3.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value; //Saxeli
                bunifuTextBox4.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value; //dabadebus..
                bunifuTextBox5.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value; //misamarti
                bunifuTextBox6.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value; //telefonis nomer
                bunifuTextBox7.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value; //elfosta
                bunifuDropdown2.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[7].Value; //ojaxuri mdgomareoba
                bunifuDropdown1.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[8].Value; //tanamdeboba
                bunifuTextBox8.Text += bunifuDataGridView1.Rows[e.RowIndex].Cells[9].Value; //xelfasi
            }
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
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.MaximizedBounds = workingArea;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void bunifuFormCaptionButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuButton5_Click(object sender, EventArgs e) //Stage 1 End
        {
            if(bunifuPages1.PageIndex==1)
            {
                bunifuPages1.PageIndex = 0;
            }
            else
            {
                bunifuPages1.PageIndex = 1;
            }
        }
        private void bunifuButton10_Click(object sender, EventArgs e) //Stage auth End
        {
            if (bunifuPages1.PageIndex == 1)
            {
                bunifuPages1.PageIndex = 3;
            }
            else
            {
                bunifuPages1.PageIndex = 1;
            }
        }


        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) // Autorisation
        {
            bunifuTextBox9.Text = "";
            bunifuTextBox10.Text = "";
            bunifuDropdown3.Text = "";

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                bunifuTextBox9.Text += bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value; //User
                bunifuTextBox10.Text += bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value; //Password
                bunifuDropdown3.Text += bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value; //Role
            }
        }

        private void bunifuButton9_Click(object sender, EventArgs e) // auth Save
        {
            SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Authorisation values (@UserMail,@Password,@RoleID)", con);
            cmd.Parameters.AddWithValue("@UserMail", bunifuTextBox9.Text);
            cmd.Parameters.AddWithValue("@Password", bunifuTextBox10.Text);
            cmd.Parameters.AddWithValue("@RoleID", bunifuDropdown3.SelectedValue.ToString());
            cmd.ExecuteNonQuery();
            MessageBox.Show("მონაცემები წარმატებით შეინახა!");
            con.Close();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            string asql = "select*from Authorisation";
            SqlCommand acom = new SqlCommand(asql, acon);
            DataSet ads = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(acom);
            ada.Fill(ads, "res");
            bunifuDataGridView2.DataSource = ads.Tables["res"];
            ada.Dispose();
            acon.Dispose();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox9.Text == "")
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
                SqlCommand cmd = new SqlCommand("Delete Authorisation where UserMail=@mail", con);
                cmd.Parameters.AddWithValue("@mail", bunifuTextBox9.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ჩანაწერი წაიშალა!");
                bunifuTextBox9.Text = "";
                bunifuTextBox10.Text = "";
                bunifuDropdown3.Text = "";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Authorisation set Password=@password,RoleID=@role where UserMail=@mail", con);
            cmd.Parameters.AddWithValue("@mail", bunifuTextBox9.Text);
            cmd.Parameters.AddWithValue("@password", bunifuTextBox10.Text);
            cmd.Parameters.AddWithValue("@role", bunifuDropdown3.SelectedValue.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ჩანაწერი განახლებულია!");
        }

        private void bunifuLabel15_Click(object sender, EventArgs e)
        {
            Logins logss = new Logins();
            logss.Show();
            this.Close();
        }

        private void bunifuButton11_Click(object sender, EventArgs e)//Bughalteria
        {
            if (bunifuPages1.PageIndex == 1)
            {
                bunifuPages1.PageIndex = 2;
            }
            else
            {
                bunifuPages1.PageIndex = 1;
            }
        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)//home icon
        {
            bunifuPages1.PageIndex = 1;
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Piradinomeri,Gvari,Saxeli,Tanamdeboba,Xelfasi from Tanamshromlebi Where Piradinomeri=@Piradi", con);
            cmd.Parameters.AddWithValue("Piradi", bunifupiradinom.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bunifuDataGridView3.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton15_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Tanamshromlebi where @Xelfasi", con);
            cmd.Parameters.AddWithValue("@Xelfasi", float.Parse(bunifuxelfasi.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ჩანაწერი განახლებულია!");
        }

        private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifupiradinom.Text = "";
            bunifugvari.Text = "";
            bunifusaxeli.Text = "";
            bunifutanamdeboba.Text = "";
            bunifuxelfasi.Text = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                bunifupiradinom.Text += bunifuDataGridView3.Rows[e.RowIndex].Cells[0].Value; //piradinom
                bunifugvari.Text += bunifuDataGridView3.Rows[e.RowIndex].Cells[1].Value; //Gvari
                bunifusaxeli.Text += bunifuDataGridView3.Rows[e.RowIndex].Cells[2].Value; //Saxeli
                bunifutanamdeboba.Text += bunifuDataGridView3.Rows[e.RowIndex].Cells[3].Value; //tanamdeboba
                bunifuxelfasi.Text += bunifuDataGridView3.Rows[e.RowIndex].Cells[4].Value; //xelfasi
            }
        }

        private void bunifuButton16_Click(object sender, EventArgs e)
        {
            SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            string asql = "select*from Tanamshromlebi";
            SqlCommand acom = new SqlCommand(asql, acon);
            DataSet ads = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(acom);
            ada.Fill(ads, "res");
            bunifuDataGridView3.DataSource = ads.Tables["res"];
            ada.Dispose();
            acon.Dispose();
        }

        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            if (bunifuPages1.PageIndex == 1)
            {
                bunifuPages1.PageIndex = 4;
            }
            else
            {
                bunifuPages1.PageIndex = 1;
            }
        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            if (bunifuPages1.PageIndex == 1)
            {
                bunifuPages1.PageIndex = 5;
            }
            else
            {
                bunifuPages1.PageIndex = 1;
            }
        }

        private void bunifuButton20_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox17.Text == "")
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
                SqlCommand cmd = new SqlCommand("Delete Momxmareblebi where @SesiisID", con);
                cmd.Parameters.AddWithValue("@SesiisID", bunifuTextBox17.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ჩანაწერი წაიშალა!");
                bunifuTextBox18.Text = "";
                bunifuTextBox19.Text = "";
                bunifuTextBox20.Text = "";
                bunifuTextBox21.Text = "";
                bunifuTextBox22.Text = "";
                bunifuTextBox23.Text = "";
                bunifuTextBox17.Text = "";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            string asql = "select*from vakansia";
            SqlCommand acom = new SqlCommand(asql, acon);
            DataSet ads = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(acom);
            ada.Fill(ads, "res");
            bunifuDataGridView5.DataSource = ads.Tables["res"];
            ada.Dispose();
            acon.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sakurso_Project
{
    internal class Class2
    {/*
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel3tanam.Visible == false)
            {
                panel3tanam.Visible = true;
                SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
                string asql = "select*from Tanamshromlebi";
                SqlCommand acom = new SqlCommand(asql, acon);
                DataSet ads = new DataSet();
                SqlDataAdapter ada = new SqlDataAdapter(acom);
                ada.Fill(ads, "res");
                dataGridView1.DataSource = ads.Tables["res"];
                ada.Dispose();
                acon.Dispose();
            }
            else
            {
                panel3tanam.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Raod;
            if (textBox1.Text == "")
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
                string asql = string.Format("delete from Tanamshromlebi where Piradinomeri=" + int.Parse(textBox1.Text));
                SqlCommand acom = new SqlCommand(asql, acon);
                MessageBox.Show(asql);
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
            acon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            acon.Open();
            string asql = string.Format(@"Insert into Tanamshromlebi values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, int.Parse(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text, int.Parse(textBox9.Text), float.Parse(textBox10.Text));
            SqlCommand acom = new SqlCommand(asql, acon);
            acom.ExecuteNonQuery();
            MessageBox.Show("მონაცემები წარმატებით შეინახა!");
            acon.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            string asql = "select*from Tanamshromlebi";
            SqlCommand acom = new SqlCommand(asql, acon);
            DataSet ads = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(acom);
            ada.Fill(ads, "res");
            dataGridView1.DataSource = ads.Tables["res"];
            ada.Dispose();
            acon.Dispose();
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }
        private void ekranze_gamotana()
        {
            SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
            string asql = "select * from Tanamshromlebi";
            SqlCommand acom = new SqlCommand(asql, acon);
            DataSet ads = new DataSet();
            SqlDataAdapter ada = new SqlDataAdapter(acom);
            ada.Fill(ads, "res");
            dataGridView1.DataSource = ads.Tables["res"];
            ada.Dispose();
            acon.Dispose();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                textBox1.Text += dataGridView1.Rows[e.RowIndex].Cells[0].Value; //piradinom
                textBox2.Text += dataGridView1.Rows[e.RowIndex].Cells[1].Value; //Gvari
                textBox3.Text += dataGridView1.Rows[e.RowIndex].Cells[2].Value; //Saxeli
                textBox4.Text += dataGridView1.Rows[e.RowIndex].Cells[3].Value; //dabadebus..
                textBox5.Text += dataGridView1.Rows[e.RowIndex].Cells[4].Value; //misamarti
                textBox6.Text += dataGridView1.Rows[e.RowIndex].Cells[5].Value; //telefonis nomer
                textBox7.Text += dataGridView1.Rows[e.RowIndex].Cells[6].Value; //elfosta
                textBox8.Text += dataGridView1.Rows[e.RowIndex].Cells[7].Value; //ojaxuri mdgomareoba
                textBox9.Text += dataGridView1.Rows[e.RowIndex].Cells[8].Value; //tanamdeboba
                textBox10.Text += dataGridView1.Rows[e.RowIndex].Cells[9].Value; //xelfasi
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Raod;
            try
            {
                SqlConnection acon = new SqlConnection(@"Data Source=INSTANCE-1\SQLEXPRESS;Initial Catalog=Moderntechnics;Integrated Security=True");
                string asql = "update Tanamshromlebi set Gvari='" + textBox2.Text + "',Saxeli='" + textBox3.Text + "',Dabadebistarighi='" + textBox4.Text + "',Misamarti='" + textBox5.Text + "',Telefonisnomeri='" + textBox6.Text + "',elfosta='" + textBox7.Text + "',Ojaxurimdgomareoba='" + textBox8.Text + "',Tanamdeboba='" + textBox9.Text + "',Xelfasi='" + textBox10.Text + "'where Piradinomeri=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                SqlCommand acom = new SqlCommand(asql, acon);
                MessageBox.Show(acom.CommandText);
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }*/
    }
}


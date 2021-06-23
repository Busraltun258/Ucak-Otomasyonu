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

namespace UÇAK
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        static string constring = ("Data Source=DESKTOP-46EO3S1;Initial Catalog=ucus;Integrated Security=True");
        SqlConnection baglan=new SqlConnection(constring);

        public void ucus_listele()
        {
        
            string getir = "Select *From ucusaraa";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xuıButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 formyeni = new Form5();
            formyeni.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_liste_Click(object sender, EventArgs e)
        {
            ucus_listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(baglan.State==ConnectionState.Closed)
                {
                    baglan.Open();
                    string ucus = " İnsert into ucusara(Firma Adi,Nereden,Nereye,Tarih,Saat,Koltuk No,Fiyat)values(@firmaadi," +
                       "@nereden,@nereye,@tarih,@saat,@koltukno,@fiyat)";
                    SqlCommand komut = new SqlCommand(ucus, baglan);
                    komut.Parameters.AddWithValue("@firmaadi", textBox1.Text);
                    komut.Parameters.AddWithValue("@nereden", textBox2.Text);
                    komut.Parameters.AddWithValue("@nereye", textBox3.Text);
                    komut.Parameters.AddWithValue("@tarih", textBox4.Text);
                    komut.Parameters.AddWithValue("@saat", textBox5.Text);
                    komut.Parameters.AddWithValue("@koltukno", textBox6.Text);
                    komut.Parameters.AddWithValue("@fiyat", textBox7.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("ucus arama işlemi tamamlandı.");
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("bir hata var!" + hata.Message);
            }
        }
    }
}

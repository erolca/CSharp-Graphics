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

namespace DBase1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnwrite_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection())
            {
                connect.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                connect.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO kullanicilar(KULLANICIADI,AD,SOYADI,FAKULTE,BOLUM,NUMARA,SINIF,YETKI) VALUES('osman1970','OSMAN','MERT','MUHENDISLIK FAKULTESI','MAKINE MUHENDISLIGI','B1212.10045','1','0')", connect))
                {
                    command.ExecuteNonQuery();

                }//SqlCommand using sonu
                connect.Close();
            }//SqlConnection using sonu

        }







        private void btnread_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection())
            {
                connect.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                connect.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM kullanicilar", connect))
                {
                    SqlDataReader reader=   command.ExecuteReader();
                    //reader.Read(); //satır1
                    //reader.Read(); //satır2
                    lbl1.Text = "";
                    while (reader.Read())
                    {
                        string veri = "\n " + reader.GetString(0);
                        veri += "\n " + reader.GetString(1);
                        veri += "\n " + reader.GetString(2);
                        veri += "\n " + reader.GetString(3);
                        veri += "\n " + reader.GetString(4);
                        veri += "\n " + reader.GetString(5);

                        veri += "\n " + reader.GetInt32(6);
                        veri += "\n " + reader.GetInt32(7);
                        //lbl1.Text += veri;
                        lstbx.Items.Add(veri);


                    }// while sonu

                   // string veri = reader.GetString(0);
                 
                  //  lbl1.Text = veri;

                }//SqlCommand using sonu
                connect.Close();
            }//SqlConnection using sonu

        }

        
    }
}

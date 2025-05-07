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
using System.Windows.Forms.VisualStyles;

namespace Habit_Tracker
{
    public partial class FrmAddHabit : Form
    {
        // form 3'un global degiskenleri.
        #region form3_global_variables
        SensitiveInfo credentials = new SensitiveInfo();
        String UserID = Form1.Form3User;
        String isim;
        String NameCheck;
        #endregion

        // form 3'u baslangica hazirlama.
        #region form3_initialize
        public FrmAddHabit()
        {
            InitializeComponent();
        }
        #endregion


        // pencereyi kapatma calismazsa diye ana forma donen buton.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // bu buton eger veritabaninda bu kullanici icin ayni isimde bir aliskanlik yoksa.
        // girilen aliskanligi veritabanina ekler
        private void button2_Click(object sender, EventArgs e)
        {
            HabitCheck();
        }
       
        
        // veritabaninda ; bu kullanici icin ayni adda bir baska aliskanlik var mmi diye kontrol eder.
        #region HabitNameCheck
        private void HabitCheck()
        {
            String BaglantiCumlesi = credentials.ConnString();    
            isim = txtHabitName.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(BaglantiCumlesi))
                {  
                    conn.Open();
                   

                    StringBuilder sbd = new StringBuilder();
                    sbd.Append("Select HabitName From Habits Where HabitName = '");
                    sbd.Append(isim);
                    sbd.Append("';");

                    String Querry = sbd.ToString();

                    using (SqlCommand cmd = new SqlCommand(Querry,conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NameCheck = reader.GetString(0);
                           // MessageBox.Show(NameCheck.ToString());  // debug mesaj kutularini iptal ediyoruz artik.
                        }

                        if (NameCheck == isim)
                        {
                            // bu debug degil kullanicinin bilmesi lazim.
                            MessageBox.Show("Bu isimde bir Habit zaten mevcut");
                        }

                        else 
                        {
                            // eger ayni isimde aliskanlik yoksa yaratiyoruz.
                            AddHabit();
                        }
                    }
                        conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        #endregion


        // veritabanina aliskanligi ekleyen kisim burasi. yukarisi ayni aliskanlik isminde bir
        // aliskanlik yoksa burayi cagiriyor.
        #region AddHabit
        private void AddHabit()
        {
            String BaglantiCumlesi = credentials.ConnString();
            isim = txtHabitName.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(BaglantiCumlesi))
                {
                    conn.Open();


                    StringBuilder sbd = new StringBuilder();
                    sbd.Append("Insert Into Habits (HabitName,UserID) Values ");
                    sbd.Append("('");
                    sbd.Append(isim);
                    sbd.Append("',");
                    sbd.Append(UserID);
                    sbd.Append(");");
                    String HabitQuery = sbd.ToString();
                    
                    /// hataaa ayiklamaaaaaaaaaa
                    /// MessageBox.Show(HabitQuery);

                    using (SqlCommand command = new SqlCommand(HabitQuery, conn))
                    {
                        command.ExecuteNonQuery();
                    }

                    String Querry = "Create Table " + isim + " ( HabitID INT Primary Key Identity (10,10), " +
                                                            " DaysElapsed Datetime Default GetDate() , Completed BIT);       ";
                    using (SqlCommand cmd = new SqlCommand(Querry, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

                
            }

         
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion
    

        // bununla ilgili sonradan planlarim var o yuzden simdilik burada kalsin. 
        // eger mumkunse kullanici yaziyi yazarken, daha bir butona basmadan veritabaninda yazilan yazi var
        // mi yok mu diye kontrol saglamayi hedefliyorum.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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

namespace Habit_Tracker
{
    public partial class UserAdding : Form
    {

        // form 2'nin ihtiyac duydugu evrensel degiskenler.
        #region form2_global_variables
        SensitiveInfo credentials = new SensitiveInfo();
        String UserName,NameCheck;

        //ayni kullanici adinda iki kisi olmasina gerek yok.
        Boolean UserNameUnique = true;

        #endregion

        // form 2 icin baslangic kodu.
        #region initialize_form2
        public UserAdding()
        {
            InitializeComponent();
        }
        #endregion

        // ana menuye donmek icin bir return butonu. olur da pencereyi kapatmak ise yaramazsa diye.
        #region BTN_return
        private void btnReturnMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        // kullanici adinin essiz olmasini kontrol eden kod.
        #region UserNameCheck
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {

            String BaglantiCumlesi = credentials.ConnString();
            try
            {
                UserName = txtNewUser.Text;

                using (SqlConnection AddingUser = new SqlConnection(BaglantiCumlesi))
                {
                    AddingUser.Open();
                    String UserSearch = "Select UserName From Users WHERE UserName = '" + txtNewUser.Text + "'";
                    // MessageBox.Show(UserSearch); // query satirlarini en az 10 kere kontrol etmeden calismiyorlar.

                    using (SqlCommand command = new SqlCommand(UserSearch,AddingUser))
                    {
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        {
                            while (sqlDataReader.Read())
                            {  
                                /// hata ayiklama
                                /// MessageBox.Show("While dongusune giriyor");
                                NameCheck = sqlDataReader.GetString(0);

                                // / MessageBox.Show(NameCheck);   // hata ayiklamaaaa
                            }

                            if (NameCheck == UserName)
                            {
                                // hata ayiklama olmayan bir message box.
                                // eger kullanici adi veritabaninda varsa bunu bize soyler
                                MessageBox.Show("There is Already a User with the Name " + txtNewUser.Text, "User Already Exists !");
                            }
                            else
                            {
                                // kullanici adi alinmamis ise kullanici eklme fonksiyonunu cagirabiliriz.
                                MessageBox.Show("Kullanici adi alinmamis.");
                                AddThisUser(UserName);
                            }
                        }
                    }
                        AddingUser.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("hata : " + Ex.ToString());
            }
        }
#endregion

        // kullaniciyi veritabanina ekleme.
        #region UserAdding
        private void AddThisUser(String kullaniciAdi)
        {
            String BaglantiCumlesi = credentials.ConnString();
            try
            {
                using (SqlConnection AddingUser = new SqlConnection(BaglantiCumlesi))
                {
                    AddingUser.Open();
                    String Query = "INSERT INTO Users (UserName) VALUES ('" + kullaniciAdi + "');";

                    using (SqlCommand command = new SqlCommand(Query,AddingUser))
                    {
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                                command.ExecuteNonQuery();
                           
                        }
                    }
                    // bu mesaj kutusunu kaldirmamak daha iyi sanirim.
                    MessageBox.Show("user added succesfully");
                    AddingUser.Close();
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("hata : " + EX.Message.ToString());
            }
        }
        #endregion
    }
}

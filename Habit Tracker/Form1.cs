using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Habit_Tracker
{
    public partial class Form1 : Form

    {   // birden fazla fonksiyonun kullanmasi gereken degiskenleri buraya yazdim 
        #region global_variables

        // SensitiveInfo kismi bir gitIgnore dosyasi olustururken bilgisayarimdaki SQL server bilgilerimi gizlemek icin.
        SensitiveInfo credentials = new SensitiveInfo();    
       
        // aydaki gunleri bu buton Array ile tasarladim.
        public Button[] Buttonlarim;

        // bu string aliskanlik ekleme formuna UserID bilgisini gondermek icin var.
        public static String Form3User;

        String UserID,UserName, SelectedHabit;
       
        int usercheck = 1000;  // bu sayi 1000'den farkli olabilir sizin veritabani tasariminiza bagli.
                               // benimkinde kullanici ID'leri 1000 sayisindan baslatilmis.

        int TotalUsers;
        #endregion
        //
        //  Use HabitTracker;
        //  Select HabitName From Habits Where UserID = 1000;
        //
        // asagida form1 icin baslangic degerleri verilmistir.
        #region form1
        public Form1()
        {
           
            InitializeComponent();
            lbxHabits.Items.Clear();
            FindTotalUsers();
            MonthPlacement();

            this.Width = 670;
            this.Height = 540;

            // burada DateTimePicker elementinden sadece ay ve yili istedigimiz belli ediyorum.
            // degistirmek icin yukari asagi iki ok var zaten 
            Tarih.Format = DateTimePickerFormat.Custom;
            Tarih.CustomFormat = "MMMM yyyy";
            Tarih.ShowUpDown = true;
        }
#endregion
        private void label1_Click(object sender, EventArgs e)
        {

        }
        // burada listbox icinde sadece O KULLANICIYA AIT olan aliskanliklar gorunuyor.
        // hangisinin secildigini global degiskene aktariyorum
        #region SelectedHabit
        private void lbxHabits_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SelectedHabit = lbxHabits.SelectedItem.ToString();
            this.SelectedHabit = SelectedHabit;
            
            // asagidaki satiri Debug icin kullandim su anda gerekli degil ama ilerisi icin silmiyorum.
            // MessageBox.Show(this.SelectedHabit);
        }
        #endregion

        // kullanici sayisinin cok olmayacagini var sayarak uygulmayi tasarladim o yuzden butona basarak kullanicilar
        // arasinda gecis yapan bir sistem var. aslinda tek kullanici olacakti ama masaustu PC'lerde birden fazla
        // kullanici olabilecegi icin boyle yaptim.
        #region ChangeUsers
        private void button2_Click(object sender, EventArgs e)
        {
            AddLbxHabits();
            String BaglantiCumlesi = credentials.ConnString();
            try 
            {
                using (SqlConnection UserConnection = new SqlConnection(BaglantiCumlesi))
                {
                    UserConnection.Open();
                    
                    UserID = usercheck.ToString();
                    Form3User = usercheck.ToString();

                    String UserNameQuery = "SELECT UserName FROM Users Where UserID = ";
                    UserNameQuery += UserID;
                    usercheck += 10;  
                    if (usercheck >= TotalUsers)
                        { usercheck = 1000; }

                    // Asagidaki mesaj kutusu Debug icin su an lazim degil.
                    // MessageBox.Show(UserNameQuery);

                    using (SqlCommand UserNameCommand = new SqlCommand(UserNameQuery, UserConnection))
                    {
                        SqlDataReader UserReader = UserNameCommand.ExecuteReader();
                        while (UserReader.Read())
                        {
                            btnChangeUser.Text =  UserReader.GetString(0);
                            UserName = UserReader.GetString(0);
                        }
                    }
                    
                    UserConnection.Close();
                }
            } 
            
            catch (Exception EX)
            {
                MessageBox.Show("hata : " + EX.Message.ToString());
            }
        }
#endregion
        // yeni kullanici ekleme formunu acan buton.
        #region NewUser
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            UserAdding Form2 = new UserAdding();
            Form2.ShowDialog();
        }
        #endregion

        // listbox elementine O KULLANICIYA AIT olan aliskanliklari item olarak eklemek icin fonksiyon.
        // bu fonksiyon lbxSelectedIndex fonksiyonu degil.
        #region listboxHabits
        public void AddLbxHabits()
        {
            String BaglantiCumlesi = credentials.ConnString();
            lbxHabits.Items.Clear();

            try
            {
                using (SqlConnection HabitConnection = new SqlConnection(BaglantiCumlesi))
                {
                    HabitConnection.Open();

                    String HabitQuery = "SELECT HabitName FROM Habits Where UserID = ";
                    HabitQuery += usercheck;

                    using (SqlCommand HabitCommand = new SqlCommand(HabitQuery, HabitConnection))
                    {
                        SqlDataReader HabitReader = HabitCommand.ExecuteReader();
                        while (HabitReader.Read())
                        {
                            lbxHabits.Items.Add(HabitReader.GetString(0));
                        }

                    }
                        HabitConnection.Close();
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show("hata: " + Ex.Message.ToString());
            }
        }
#endregion

        // toplam kullanici sayisini bulmak icin kulllandigim fonksiyon.
        // kullanici sayisini bulduktan sonra buton kac tiklamadan sonra reset olacak onu ayarliyorum.
        #region FindTotalUsers
        private void FindTotalUsers()
        {
            String BaglantiCumlesi = credentials.ConnString();
            try
            {
                using (SqlConnection conn = new SqlConnection(BaglantiCumlesi))
                {
                    conn.Open();
                    String Query = "Select Count(*) from Users";

                    using (SqlCommand command = new SqlCommand(Query,conn))
                    {
                        TotalUsers = 1000 + (int)command.ExecuteScalar() * 10;
                    }
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        // Bir ayda kac gun oldugunu bulmak icin kullandigim fonksiyon.
        // bunun daha kolay bir yolu olduguna eminim ama be bulammadim sonraki versiyonlarda guncellerim.
        #region DaysInMonth
        private int DaysInMonth() 
        {
            DateTime datetime = Tarih.Value;
            int month = datetime.Month;
            int year = datetime.Year;
          
            /// for debugging purposes
            /// MessageBox.Show(month.ToString());
            
            if(month == 1 || month == 3 || month == 5|| month == 7 || month == 8 || month == 10 || month == 12) 
                { return 31; }
            if(month == 4 || month == 6 || month == 9 || month == 11 )
                { return 30; }
            
            // artik yili unutmamak lazim tabi
            if (month == 2 || year % 4 == 0)
                { return 29; }
            else 
                { return 28; }

        }
        #endregion

        // Yeni aliskanlik ekleme formunu acan buton.
        #region AddHabit

        
        private void btnAddHabit_Click(object sender, EventArgs e)
        {
            FrmAddHabit Form3 = new FrmAddHabit();
            Form3.ShowDialog();
            AddLbxHabits();
        }
        #endregion
        #region FirstDayOfMonth
        private int FirstDayOfMonth()
        {
            DateTime firstDay = new DateTime(Tarih.Value.Year, Tarih.Value.Month, 1);
            String WeekDay = firstDay.DayOfWeek.ToString();

            switch (WeekDay)
            {
                case "Monday":
                    return 0;
                    break;

                case "Tuesday":
                    return 1;
                    break;

                case "Wednesday":
                    return 2;
                    break;

                case "Thursday":
                    return 3;
                    break;

                case "Friday":
                    return 4;
                    break;

                case "Saturday":
                    return 5;
                    break;

                case "Sunday":
                    return 6;
                    break;

                default:
                    MessageBox.Show("Date Error");
                    return -1;
                    break;
                    
            }

        }
        #endregion
        #region monthPlacement
         private int MonthPlacement()
        {


            int buttonCount = DaysInMonth();
            int xStart = 220;
            int yStart = 135;
            int btnSize = 40;
            int spacing = 15;

            int currentX = xStart + FirstDayOfMonth() * (btnSize + spacing); // Offset for first day
            int currentY = yStart;

            Buttonlarim = new Button[buttonCount];

            for (int i = 0; i < buttonCount; i++)
            {
                Buttonlarim[i] = new Button();
                Buttonlarim[i].Size = new Size(btnSize, btnSize);
                Buttonlarim[i].Location = new Point(currentX, currentY);
                Buttonlarim[i].Text = (i + 1).ToString();
              ///  Buttonlarim[i].BackColor = Color.Red;
                this.Controls.Add(Buttonlarim[i]);

                // Move X for the next button
                currentX += btnSize + spacing;

                // If currentX exceeds calendar width, go to next row
                if (currentX > 580)
                {
                    currentX = xStart;
                    currentY += btnSize + spacing;
                }
            }

            List<DateTime> markedDates = new List<DateTime>();

            return Buttonlarim.Length;

            #endregion

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // aylar her yeniden secildiginde eski aydan kalma butonlari temizlemek icin kullanilan metod.
        #region Button_remover_
        private void ButtonRemoverXXl()
        {

            foreach (Button btn in Buttonlarim)
            {
                this.Controls.Remove(btn); // Remove the button from the form controls
            }
        }
        #endregion

        // Today icin aliskanliginizi tamamladiysaniz bastiginiz buton.
        #region MarkToday
        private void button4_Click(object sender, EventArgs e)
        {
            String BaglantiCumlesi = credentials.ConnString();
            String Table,Month,Day,Year,Query;
            DateTime Date;
            try
            {
                using (SqlConnection conn = new SqlConnection(BaglantiCumlesi))
                {

                    Table = SelectedHabit;
                    Date = DateTime.Now;
                    Month = Date.Month.ToString();
                    Day = Date.Day.ToString();
                    Year = Date.Year.ToString();

                    StringBuilder sb = new StringBuilder();
                    sb.Append("'" + Year + "-" + Month + "-" + Day +"'");
                    String Today = sb.ToString();
                   
                    
                    // MessageBox.Show(Today);  // Today'i dogru olarak stringe parse edebildim mi onu kontrol ediyorum.
                    
                    conn.Open();
                    Query = ("Insert Into " + Table + " Values (" + Today + ", 1 );" );
                    // MessageBox.Show(Query);  // Query satiri SQQL server'deki ile ayni mi onu kontrol ediyorum.
                    using (SqlCommand command = new SqlCommand(Query,conn))
                    {
                        command.ExecuteNonQuery();
                      
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


        // sectiginiz aydaki her gun icin tekrar tekrar cagirilacak olan fonksiyon. o gun icin aliskanligin tamamlanip,
        // tamamlanmadigini kontrol eder. veritabaninda bu kontrol icin BIT degiskeni kullanildi.
        #region Habit_Complete
        private void HabitComplete()
        {
            MonthPlacement();
            int pickedDay;
            int pickedMonth = Tarih.Value.Month; // Tarih.Value.Month;
            int pickedYear = Tarih.Value.Year; // Tarih.Value.Year;
            string placeholder = "error listbox secimi yapilmamis.";
            int aydakiGun = DaysInMonth();
            String BaglantiCumlesi = credentials.ConnString();
            try
            {
                using (SqlConnection conn = new SqlConnection(BaglantiCumlesi))
                {
                    conn.Open();

                    // Retrieve the HabitName from the database
                    string QueryString = "SELECT HabitName FROM Habits WHERE HabitName = '" + SelectedHabit   + "';";
                    using (SqlCommand command = new SqlCommand(QueryString, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            placeholder = reader.GetString(0); // Assuming HabitName is in the first column
                        }
                        reader.Close();
                    }
                    // Debug icin kullanildi su anda lazim degil.
                    // MessageBox.Show(placeholder);

                    // Check for invalid habit table name
                    if (string.IsNullOrWhiteSpace(placeholder) || placeholder.Contains(";"))
                    {
                       // bu da debug icin kullanildi su an lazim degul.
                       // MessageBox.Show("Invalid habit table name.");
                        return;
                    }

                    // aydaki her gunun BIT degerini veritabanindan alip kontolunu sagliyor.
                    for (int day = 1; day <= aydakiGun; day++)
                    {
                        string Querry = "SELECT Completed FROM " + placeholder  +
                                        " WHERE MONTH(DaysElapsed) = " + pickedMonth +
                                        " AND YEAR(DaysElapsed) = " + pickedYear +
                                        " AND DAY(DaysElapsed) = " + day ;


                        // burada baglantiyip acip kapatmadigim zaman baglanti kapali hatasi aliyorum.
                        // sonraki versiyonlarda kontrol edilecek.
                        conn.Close();
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(Querry, conn))
                        {
                           // MessageBox.Show(Querry); // debug islemi icin kullandil

                            SqlDataReader read = cmd.ExecuteReader();

                            // veri okunmadiysa islem yapmamasi icin.
                            if (read.Read()) 
                            {
                                bool Completed = read.GetBoolean(0); // BIT degerini Boolean degere aktarabiliyoruz.

                               //  MessageBox.Show("Completed for day " + day + ": " completed );
                               //  aliskanligin tamalandigi gunlerde mesaj kutusu cikartiyor
                                
                                if (day - 1 < Buttonlarim.Length)
                                {
                                    Buttonlarim[day - 1].BackColor = Completed ? Color.LightBlue : Color.Red;
                                    // MessageBox.Show("Button " + day + " boyandi.");  // bu da debug islemi icin 
                                }
                           
                            }
                            else
                            {
                             // MessageBox.Show("No data for day " + day); // eger o gun aliskanlik yapilmadiysa ne
                                // yapacagini soyleyen kod.
                            }
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // hata mesaji
                MessageBox.Show(ex.Message);
            }
        }
#endregion
        #region label_Click
        private void label6_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region DateTimePicker_value
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion
        
        // ilk once bir kullanici secip
        // daha sonra listbox'ta bir aliskanlik sectiyseniz.
        // bir de tarih belirlediyseniz.
        // bu butona dokunarak sectiginiz bilgilerdeki aliskanlik butonlar uzerinden size getirilecek.
        #region ViewHabit

        private void btnTheme_Click(object sender, EventArgs e)
        {
            // eski butonlari kaldirir.
            ButtonRemoverXXl();
            // aliskanligin tamamlandigi gunleri buton Arrayina aktarir.
            HabitComplete();
        }
        #endregion
        private void lbxHabits_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}

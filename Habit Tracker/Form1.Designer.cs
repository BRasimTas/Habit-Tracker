namespace Habit_Tracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTheme = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnAddHabit = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Baslik = new System.Windows.Forms.Label();
            this.lbxHabits = new System.Windows.Forms.ListBox();
            this.version = new System.Windows.Forms.Label();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Tarih = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnTheme
            // 
            this.btnTheme.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnTheme.Location = new System.Drawing.Point(12, 259);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(150, 50);
            this.btnTheme.TabIndex = 0;
            this.btnTheme.Text = "View Habit";
            this.btnTheme.UseVisualStyleBackColor = false;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnChangeUser.Location = new System.Drawing.Point(12, 404);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(150, 50);
            this.btnChangeUser.TabIndex = 1;
            this.btnChangeUser.Text = "Change User";
            this.btnChangeUser.UseVisualStyleBackColor = false;
            this.btnChangeUser.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddHabit
            // 
            this.btnAddHabit.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnAddHabit.Location = new System.Drawing.Point(12, 474);
            this.btnAddHabit.Name = "btnAddHabit";
            this.btnAddHabit.Size = new System.Drawing.Size(150, 50);
            this.btnAddHabit.TabIndex = 2;
            this.btnAddHabit.Text = "Add Habit";
            this.btnAddHabit.UseVisualStyleBackColor = false;
            this.btnAddHabit.Click += new System.EventHandler(this.btnAddHabit_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkSalmon;
            this.button4.Location = new System.Drawing.Point(313, 558);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(456, 50);
            this.button4.TabIndex = 4;
            this.button4.Text = "Mark Today";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Baslik
            // 
            this.Baslik.AutoSize = true;
            this.Baslik.Font = new System.Drawing.Font("MV Boli", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Baslik.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Baslik.Location = new System.Drawing.Point(223, 9);
            this.Baslik.Name = "Baslik";
            this.Baslik.Size = new System.Drawing.Size(565, 105);
            this.Baslik.TabIndex = 6;
            this.Baslik.Text = "Habit Tracker";
            this.Baslik.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbxHabits
            // 
            this.lbxHabits.FormattingEnabled = true;
            this.lbxHabits.ItemHeight = 16;
            this.lbxHabits.Location = new System.Drawing.Point(12, 43);
            this.lbxHabits.Name = "lbxHabits";
            this.lbxHabits.Size = new System.Drawing.Size(150, 164);
            this.lbxHabits.TabIndex = 7;
            this.lbxHabits.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbxHabits_MouseClick);
            this.lbxHabits.SelectedIndexChanged += new System.EventHandler(this.lbxHabits_SelectedIndexChanged);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(771, 78);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(31, 16);
            this.version.TabIndex = 8;
            this.version.Text = "v0.1";
            // 
            // btnNewUser
            // 
            this.btnNewUser.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnNewUser.Location = new System.Drawing.Point(12, 331);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(150, 50);
            this.btnNewUser.TabIndex = 41;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "pazartesi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "sali";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "carsamba";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(510, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "persembe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(591, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "cuma";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(656, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "cumartesi";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(744, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "pazar";
            // 
            // Tarih
            // 
            this.Tarih.CustomFormat = "MMMM yyyy";
            this.Tarih.Location = new System.Drawing.Point(12, 213);
            this.Tarih.Name = "Tarih";
            this.Tarih.Size = new System.Drawing.Size(150, 22);
            this.Tarih.TabIndex = 49;
            this.Tarih.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1137, 640);
            this.Controls.Add(this.Tarih);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.version);
            this.Controls.Add(this.lbxHabits);
            this.Controls.Add(this.Baslik);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnAddHabit);
            this.Controls.Add(this.btnChangeUser);
            this.Controls.Add(this.btnTheme);
            this.Name = "Form1";
            this.Text = "HabitTracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.Button btnAddHabit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label Baslik;
        private System.Windows.Forms.ListBox lbxHabits;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker Tarih;
    }
}


namespace Habit_Tracker
{
    partial class FrmAddHabit
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.txtHabitName = new System.Windows.Forms.TextBox();
            this.btnAddHabit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(12, 185);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(203, 70);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtHabitName
            // 
            this.txtHabitName.Location = new System.Drawing.Point(12, 73);
            this.txtHabitName.Name = "txtHabitName";
            this.txtHabitName.Size = new System.Drawing.Size(408, 22);
            this.txtHabitName.TabIndex = 1;
            this.txtHabitName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAddHabit
            // 
            this.btnAddHabit.Location = new System.Drawing.Point(221, 185);
            this.btnAddHabit.Name = "btnAddHabit";
            this.btnAddHabit.Size = new System.Drawing.Size(199, 70);
            this.btnAddHabit.TabIndex = 2;
            this.btnAddHabit.Text = "Add";
            this.btnAddHabit.UseVisualStyleBackColor = true;
            this.btnAddHabit.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmAddHabit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 358);
            this.Controls.Add(this.btnAddHabit);
            this.Controls.Add(this.txtHabitName);
            this.Controls.Add(this.btnReturn);
            this.Name = "FrmAddHabit";
            this.Text = "Add New Habit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.TextBox txtHabitName;
        private System.Windows.Forms.Button btnAddHabit;
    }
}
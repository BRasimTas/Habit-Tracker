namespace Habit_Tracker
{
    partial class UserAdding
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
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.btnReturnMain = new System.Windows.Forms.Button();
            this.txtNewUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(82)))), ((int)(((byte)(209)))));
            this.btnAddNewUser.Location = new System.Drawing.Point(235, 166);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(150, 50);
            this.btnAddNewUser.TabIndex = 0;
            this.btnAddNewUser.Text = "Add User";
            this.btnAddNewUser.UseVisualStyleBackColor = false;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // btnReturnMain
            // 
            this.btnReturnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(82)))), ((int)(((byte)(209)))));
            this.btnReturnMain.Location = new System.Drawing.Point(42, 166);
            this.btnReturnMain.Name = "btnReturnMain";
            this.btnReturnMain.Size = new System.Drawing.Size(150, 50);
            this.btnReturnMain.TabIndex = 1;
            this.btnReturnMain.Text = "Return";
            this.btnReturnMain.UseVisualStyleBackColor = false;
            this.btnReturnMain.Click += new System.EventHandler(this.btnReturnMain_Click);
            // 
            // txtNewUser
            // 
            this.txtNewUser.Location = new System.Drawing.Point(87, 104);
            this.txtNewUser.Name = "txtNewUser";
            this.txtNewUser.Size = new System.Drawing.Size(261, 22);
            this.txtNewUser.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please Enter a User Name";
            // 
            // UserAdding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(132)))), ((int)(((byte)(165)))));
            this.ClientSize = new System.Drawing.Size(432, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewUser);
            this.Controls.Add(this.btnReturnMain);
            this.Controls.Add(this.btnAddNewUser);
            this.Name = "UserAdding";
            this.Text = "Create New User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Button btnReturnMain;
        private System.Windows.Forms.TextBox txtNewUser;
        private System.Windows.Forms.Label label1;
    }
}
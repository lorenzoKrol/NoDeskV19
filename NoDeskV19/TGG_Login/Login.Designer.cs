namespace TGG_App
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UnameTxtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PasswdTxtbox = new System.Windows.Forms.TextBox();
            this.Loginbtn = new System.Windows.Forms.Button();
            this.RemMeCheckBox = new System.Windows.Forms.CheckBox();
            this.ForgorPassLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(60, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "NoDesk: The Garden Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please provide login credentials to login to NoDesk for The Garden Group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username";
            // 
            // UnameTxtbox
            // 
            this.UnameTxtbox.Location = new System.Drawing.Point(109, 151);
            this.UnameTxtbox.Name = "UnameTxtbox";
            this.UnameTxtbox.Size = new System.Drawing.Size(269, 20);
            this.UnameTxtbox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(106, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // PasswdTxtbox
            // 
            this.PasswdTxtbox.AcceptsReturn = true;
            this.PasswdTxtbox.Location = new System.Drawing.Point(109, 253);
            this.PasswdTxtbox.Name = "PasswdTxtbox";
            this.PasswdTxtbox.Size = new System.Drawing.Size(275, 20);
            this.PasswdTxtbox.TabIndex = 3;
            this.PasswdTxtbox.UseSystemPasswordChar = true;
            // 
            // Loginbtn
            // 
            this.Loginbtn.BackColor = System.Drawing.Color.LightGreen;
            this.Loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Loginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loginbtn.Location = new System.Drawing.Point(176, 339);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(107, 45);
            this.Loginbtn.TabIndex = 4;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = false;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // RemMeCheckBox
            // 
            this.RemMeCheckBox.AutoSize = true;
            this.RemMeCheckBox.Location = new System.Drawing.Point(109, 305);
            this.RemMeCheckBox.Name = "RemMeCheckBox";
            this.RemMeCheckBox.Size = new System.Drawing.Size(95, 17);
            this.RemMeCheckBox.TabIndex = 5;
            this.RemMeCheckBox.Text = "Remember Me";
            this.RemMeCheckBox.UseVisualStyleBackColor = true;
            this.RemMeCheckBox.CheckedChanged += new System.EventHandler(this.RemMeCheckBox_CheckedChanged);
            // 
            // ForgorPassLinkLabel
            // 
            this.ForgorPassLinkLabel.AutoSize = true;
            this.ForgorPassLinkLabel.Location = new System.Drawing.Point(292, 309);
            this.ForgorPassLinkLabel.Name = "ForgorPassLinkLabel";
            this.ForgorPassLinkLabel.Size = new System.Drawing.Size(92, 13);
            this.ForgorPassLinkLabel.TabIndex = 6;
            this.ForgorPassLinkLabel.TabStop = true;
            this.ForgorPassLinkLabel.Text = "Forgot Password?";
            this.ForgorPassLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForgorPassLinkLabel_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 406);
            this.Controls.Add(this.ForgorPassLinkLabel);
            this.Controls.Add(this.RemMeCheckBox);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.PasswdTxtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UnameTxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UnameTxtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PasswdTxtbox;
        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.CheckBox RemMeCheckBox;
        private System.Windows.Forms.LinkLabel ForgorPassLinkLabel;
    }
}


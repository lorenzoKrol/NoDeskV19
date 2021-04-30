namespace NoDesk
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
            this.pnl_ResetPassword_Email = new System.Windows.Forms.Panel();
            this.btn_PassReset_Email_SendButton = new System.Windows.Forms.Button();
            this.tb_Passreset_Email_Input = new System.Windows.Forms.TextBox();
            this.lbl_PassReset_Email_Title = new System.Windows.Forms.Label();
            this.pnl_ResetPassword_CodeInput = new System.Windows.Forms.Panel();
            this.btn_ResetPass_CodeInput_Authorize = new System.Windows.Forms.Button();
            this.lbl_ResetPass_CodeInput_Title = new System.Windows.Forms.Label();
            this.tb_ResetPass_CodeInput_Authcode = new System.Windows.Forms.TextBox();
            this.pnl_ResetPassword_ChangePass = new System.Windows.Forms.Panel();
            this.btn_PassReset_ChangePass_ChangePassword = new System.Windows.Forms.Button();
            this.lbl_PassReset_ChangePass_Pass2 = new System.Windows.Forms.Label();
            this.lbl_PassReset_ChangePass_Pass1 = new System.Windows.Forms.Label();
            this.tb_PassReset_ChangePass_PassInput2 = new System.Windows.Forms.TextBox();
            this.tb_PassReset_ChangePass_PassInput1 = new System.Windows.Forms.TextBox();
            this.pnl_ResetPassword_Email.SuspendLayout();
            this.pnl_ResetPassword_CodeInput.SuspendLayout();
            this.pnl_ResetPassword_ChangePass.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_ResetPassword_Email
            // 
            this.pnl_ResetPassword_Email.Controls.Add(this.btn_PassReset_Email_SendButton);
            this.pnl_ResetPassword_Email.Controls.Add(this.tb_Passreset_Email_Input);
            this.pnl_ResetPassword_Email.Controls.Add(this.lbl_PassReset_Email_Title);
            this.pnl_ResetPassword_Email.Location = new System.Drawing.Point(0, 0);
            this.pnl_ResetPassword_Email.Name = "pnl_ResetPassword_Email";
            this.pnl_ResetPassword_Email.Size = new System.Drawing.Size(803, 450);
            this.pnl_ResetPassword_Email.TabIndex = 0;
            // 
            // btn_PassReset_Email_SendButton
            // 
            this.btn_PassReset_Email_SendButton.Location = new System.Drawing.Point(325, 227);
            this.btn_PassReset_Email_SendButton.Name = "btn_PassReset_Email_SendButton";
            this.btn_PassReset_Email_SendButton.Size = new System.Drawing.Size(140, 43);
            this.btn_PassReset_Email_SendButton.TabIndex = 2;
            this.btn_PassReset_Email_SendButton.Text = "Send Auth Code";
            this.btn_PassReset_Email_SendButton.UseVisualStyleBackColor = true;
            this.btn_PassReset_Email_SendButton.Click += new System.EventHandler(this.btn_PassReset_Email_SendButton_Click);
            // 
            // tb_Passreset_Email_Input
            // 
            this.tb_Passreset_Email_Input.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Passreset_Email_Input.Location = new System.Drawing.Point(274, 179);
            this.tb_Passreset_Email_Input.Name = "tb_Passreset_Email_Input";
            this.tb_Passreset_Email_Input.Size = new System.Drawing.Size(250, 28);
            this.tb_Passreset_Email_Input.TabIndex = 1;
            // 
            // lbl_PassReset_Email_Title
            // 
            this.lbl_PassReset_Email_Title.AutoSize = true;
            this.lbl_PassReset_Email_Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PassReset_Email_Title.Location = new System.Drawing.Point(322, 136);
            this.lbl_PassReset_Email_Title.Name = "lbl_PassReset_Email_Title";
            this.lbl_PassReset_Email_Title.Size = new System.Drawing.Size(143, 22);
            this.lbl_PassReset_Email_Title.TabIndex = 0;
            this.lbl_PassReset_Email_Title.Text = "Enter your Email";
            // 
            // pnl_ResetPassword_CodeInput
            // 
            this.pnl_ResetPassword_CodeInput.Controls.Add(this.btn_ResetPass_CodeInput_Authorize);
            this.pnl_ResetPassword_CodeInput.Controls.Add(this.lbl_ResetPass_CodeInput_Title);
            this.pnl_ResetPassword_CodeInput.Controls.Add(this.tb_ResetPass_CodeInput_Authcode);
            this.pnl_ResetPassword_CodeInput.Location = new System.Drawing.Point(0, 0);
            this.pnl_ResetPassword_CodeInput.Name = "pnl_ResetPassword_CodeInput";
            this.pnl_ResetPassword_CodeInput.Size = new System.Drawing.Size(803, 450);
            this.pnl_ResetPassword_CodeInput.TabIndex = 3;
            // 
            // btn_ResetPass_CodeInput_Authorize
            // 
            this.btn_ResetPass_CodeInput_Authorize.Location = new System.Drawing.Point(353, 227);
            this.btn_ResetPass_CodeInput_Authorize.Name = "btn_ResetPass_CodeInput_Authorize";
            this.btn_ResetPass_CodeInput_Authorize.Size = new System.Drawing.Size(134, 43);
            this.btn_ResetPass_CodeInput_Authorize.TabIndex = 2;
            this.btn_ResetPass_CodeInput_Authorize.Text = "Authorize code";
            this.btn_ResetPass_CodeInput_Authorize.UseVisualStyleBackColor = true;
            this.btn_ResetPass_CodeInput_Authorize.Click += new System.EventHandler(this.btn_ResetPass_CodeInput_Authorize_Click);
            // 
            // lbl_ResetPass_CodeInput_Title
            // 
            this.lbl_ResetPass_CodeInput_Title.AutoSize = true;
            this.lbl_ResetPass_CodeInput_Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ResetPass_CodeInput_Title.Location = new System.Drawing.Point(298, 136);
            this.lbl_ResetPass_CodeInput_Title.Name = "lbl_ResetPass_CodeInput_Title";
            this.lbl_ResetPass_CodeInput_Title.Size = new System.Drawing.Size(242, 28);
            this.lbl_ResetPass_CodeInput_Title.TabIndex = 1;
            this.lbl_ResetPass_CodeInput_Title.Text = "Enter your AuthCode:";
            // 
            // tb_ResetPass_CodeInput_Authcode
            // 
            this.tb_ResetPass_CodeInput_Authcode.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ResetPass_CodeInput_Authcode.Location = new System.Drawing.Point(274, 179);
            this.tb_ResetPass_CodeInput_Authcode.Name = "tb_ResetPass_CodeInput_Authcode";
            this.tb_ResetPass_CodeInput_Authcode.Size = new System.Drawing.Size(301, 34);
            this.tb_ResetPass_CodeInput_Authcode.TabIndex = 0;
            // 
            // pnl_ResetPassword_ChangePass
            // 
            this.pnl_ResetPassword_ChangePass.Controls.Add(this.btn_PassReset_ChangePass_ChangePassword);
            this.pnl_ResetPassword_ChangePass.Controls.Add(this.lbl_PassReset_ChangePass_Pass2);
            this.pnl_ResetPassword_ChangePass.Controls.Add(this.lbl_PassReset_ChangePass_Pass1);
            this.pnl_ResetPassword_ChangePass.Controls.Add(this.tb_PassReset_ChangePass_PassInput2);
            this.pnl_ResetPassword_ChangePass.Controls.Add(this.tb_PassReset_ChangePass_PassInput1);
            this.pnl_ResetPassword_ChangePass.Location = new System.Drawing.Point(0, 0);
            this.pnl_ResetPassword_ChangePass.Name = "pnl_ResetPassword_ChangePass";
            this.pnl_ResetPassword_ChangePass.Size = new System.Drawing.Size(802, 450);
            this.pnl_ResetPassword_ChangePass.TabIndex = 3;
            // 
            // btn_PassReset_ChangePass_ChangePassword
            // 
            this.btn_PassReset_ChangePass_ChangePassword.Location = new System.Drawing.Point(213, 267);
            this.btn_PassReset_ChangePass_ChangePassword.Name = "btn_PassReset_ChangePass_ChangePassword";
            this.btn_PassReset_ChangePass_ChangePassword.Size = new System.Drawing.Size(168, 35);
            this.btn_PassReset_ChangePass_ChangePassword.TabIndex = 4;
            this.btn_PassReset_ChangePass_ChangePassword.Text = "Change Password";
            this.btn_PassReset_ChangePass_ChangePassword.UseVisualStyleBackColor = true;
            this.btn_PassReset_ChangePass_ChangePassword.Click += new System.EventHandler(this.btn_PassReset_ChangePass_ChangePassword_Click);
            // 
            // lbl_PassReset_ChangePass_Pass2
            // 
            this.lbl_PassReset_ChangePass_Pass2.AutoSize = true;
            this.lbl_PassReset_ChangePass_Pass2.Location = new System.Drawing.Point(213, 199);
            this.lbl_PassReset_ChangePass_Pass2.Name = "lbl_PassReset_ChangePass_Pass2";
            this.lbl_PassReset_ChangePass_Pass2.Size = new System.Drawing.Size(114, 13);
            this.lbl_PassReset_ChangePass_Pass2.TabIndex = 3;
            this.lbl_PassReset_ChangePass_Pass2.Text = "Confirm new Password";
            // 
            // lbl_PassReset_ChangePass_Pass1
            // 
            this.lbl_PassReset_ChangePass_Pass1.AutoSize = true;
            this.lbl_PassReset_ChangePass_Pass1.Location = new System.Drawing.Point(213, 125);
            this.lbl_PassReset_ChangePass_Pass1.Name = "lbl_PassReset_ChangePass_Pass1";
            this.lbl_PassReset_ChangePass_Pass1.Size = new System.Drawing.Size(129, 13);
            this.lbl_PassReset_ChangePass_Pass1.TabIndex = 2;
            this.lbl_PassReset_ChangePass_Pass1.Text = "Enter Your new Password";
            // 
            // tb_PassReset_ChangePass_PassInput2
            // 
            this.tb_PassReset_ChangePass_PassInput2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_PassReset_ChangePass_PassInput2.Location = new System.Drawing.Point(213, 219);
            this.tb_PassReset_ChangePass_PassInput2.Name = "tb_PassReset_ChangePass_PassInput2";
            this.tb_PassReset_ChangePass_PassInput2.PasswordChar = '*';
            this.tb_PassReset_ChangePass_PassInput2.Size = new System.Drawing.Size(316, 29);
            this.tb_PassReset_ChangePass_PassInput2.TabIndex = 1;
            // 
            // tb_PassReset_ChangePass_PassInput1
            // 
            this.tb_PassReset_ChangePass_PassInput1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_PassReset_ChangePass_PassInput1.Location = new System.Drawing.Point(213, 144);
            this.tb_PassReset_ChangePass_PassInput1.Name = "tb_PassReset_ChangePass_PassInput1";
            this.tb_PassReset_ChangePass_PassInput1.PasswordChar = '*';
            this.tb_PassReset_ChangePass_PassInput1.Size = new System.Drawing.Size(316, 29);
            this.tb_PassReset_ChangePass_PassInput1.TabIndex = 0;
            this.tb_PassReset_ChangePass_PassInput1.TextChanged += new System.EventHandler(this.tb_PassReset_ChangePass_PassInput1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_ResetPassword_Email);
            this.Controls.Add(this.pnl_ResetPassword_CodeInput);
            this.Controls.Add(this.pnl_ResetPassword_ChangePass);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnl_ResetPassword_Email.ResumeLayout(false);
            this.pnl_ResetPassword_Email.PerformLayout();
            this.pnl_ResetPassword_CodeInput.ResumeLayout(false);
            this.pnl_ResetPassword_CodeInput.PerformLayout();
            this.pnl_ResetPassword_ChangePass.ResumeLayout(false);
            this.pnl_ResetPassword_ChangePass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_ResetPassword_Email;
        private System.Windows.Forms.Button btn_PassReset_Email_SendButton;
        private System.Windows.Forms.TextBox tb_Passreset_Email_Input;
        private System.Windows.Forms.Label lbl_PassReset_Email_Title;
        private System.Windows.Forms.Panel pnl_ResetPassword_CodeInput;
        private System.Windows.Forms.Button btn_ResetPass_CodeInput_Authorize;
        private System.Windows.Forms.Label lbl_ResetPass_CodeInput_Title;
        private System.Windows.Forms.TextBox tb_ResetPass_CodeInput_Authcode;
        private System.Windows.Forms.Panel pnl_ResetPassword_ChangePass;
        private System.Windows.Forms.TextBox tb_PassReset_ChangePass_PassInput2;
        private System.Windows.Forms.TextBox tb_PassReset_ChangePass_PassInput1;
        private System.Windows.Forms.Button btn_PassReset_ChangePass_ChangePassword;
        private System.Windows.Forms.Label lbl_PassReset_ChangePass_Pass2;
        private System.Windows.Forms.Label lbl_PassReset_ChangePass_Pass1;
    }
}


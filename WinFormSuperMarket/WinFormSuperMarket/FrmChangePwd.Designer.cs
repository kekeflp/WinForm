namespace WinFormSuperMarket
{
    partial class FrmChangePwd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_fcpOldPwd = new System.Windows.Forms.TextBox();
            this.lbl_fcpNewPwd = new System.Windows.Forms.TextBox();
            this.lbl_fcpConfirmPwd = new System.Windows.Forms.TextBox();
            this.btn_fcpOK = new System.Windows.Forms.Button();
            this.btn_fcpClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码：";
            // 
            // lbl_fcpOldPwd
            // 
            this.lbl_fcpOldPwd.Location = new System.Drawing.Point(100, 24);
            this.lbl_fcpOldPwd.Name = "lbl_fcpOldPwd";
            this.lbl_fcpOldPwd.Size = new System.Drawing.Size(171, 21);
            this.lbl_fcpOldPwd.TabIndex = 3;
            // 
            // lbl_fcpNewPwd
            // 
            this.lbl_fcpNewPwd.Location = new System.Drawing.Point(100, 53);
            this.lbl_fcpNewPwd.Name = "lbl_fcpNewPwd";
            this.lbl_fcpNewPwd.PasswordChar = '*';
            this.lbl_fcpNewPwd.Size = new System.Drawing.Size(171, 21);
            this.lbl_fcpNewPwd.TabIndex = 4;
            // 
            // lbl_fcpConfirmPwd
            // 
            this.lbl_fcpConfirmPwd.Location = new System.Drawing.Point(100, 80);
            this.lbl_fcpConfirmPwd.Name = "lbl_fcpConfirmPwd";
            this.lbl_fcpConfirmPwd.PasswordChar = '*';
            this.lbl_fcpConfirmPwd.Size = new System.Drawing.Size(171, 21);
            this.lbl_fcpConfirmPwd.TabIndex = 5;
            // 
            // btn_fcpOK
            // 
            this.btn_fcpOK.Location = new System.Drawing.Point(115, 124);
            this.btn_fcpOK.Name = "btn_fcpOK";
            this.btn_fcpOK.Size = new System.Drawing.Size(75, 23);
            this.btn_fcpOK.TabIndex = 6;
            this.btn_fcpOK.Text = "确认";
            this.btn_fcpOK.UseVisualStyleBackColor = true;
            this.btn_fcpOK.Click += new System.EventHandler(this.btn_fcpOK_Click);
            // 
            // btn_fcpClose
            // 
            this.btn_fcpClose.Location = new System.Drawing.Point(196, 124);
            this.btn_fcpClose.Name = "btn_fcpClose";
            this.btn_fcpClose.Size = new System.Drawing.Size(75, 23);
            this.btn_fcpClose.TabIndex = 7;
            this.btn_fcpClose.Text = "取消";
            this.btn_fcpClose.UseVisualStyleBackColor = true;
            this.btn_fcpClose.Click += new System.EventHandler(this.btn_fcpClose_Click);
            // 
            // FrmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 172);
            this.Controls.Add(this.btn_fcpClose);
            this.Controls.Add(this.btn_fcpOK);
            this.Controls.Add(this.lbl_fcpConfirmPwd);
            this.Controls.Add(this.lbl_fcpNewPwd);
            this.Controls.Add(this.lbl_fcpOldPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lbl_fcpOldPwd;
        private System.Windows.Forms.TextBox lbl_fcpNewPwd;
        private System.Windows.Forms.TextBox lbl_fcpConfirmPwd;
        private System.Windows.Forms.Button btn_fcpOK;
        private System.Windows.Forms.Button btn_fcpClose;
    }
}
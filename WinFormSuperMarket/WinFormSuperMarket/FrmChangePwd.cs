using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WinFormSuperMarket
{
    public partial class FrmChangePwd : Form
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        #region 窗体传值
        public TransUser FcpUser { get; set; }
        #endregion
        DBHelper dbHelper;
        private void btn_fcpClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_fcpOK_Click(object sender, EventArgs e)
        {
            if (this.lbl_fcpOldPwd.Text != string.Empty && this.lbl_fcpNewPwd.Text != string.Empty && this.lbl_fcpConfirmPwd.Text != string.Empty)
            {
                ChangePwd();
            }
            else
            {
                MessageBox.Show("填写信息不能为空!", "错误信息");
            }
        }

        public void ChangePwd()
        {
            // 如果当前输入的密码与原密码匹配,且新密码与确认密码一致时,则进行修改
            if (this.lbl_fcpOldPwd.Text.Equals(FcpUser.Pwd) && this.lbl_fcpNewPwd.Text.Equals(this.lbl_fcpConfirmPwd.Text))
            {
                string sql = "update users set pwd=@pwd where  username=@name";
                dbHelper = new DBHelper();
                SqlCommand cmd = new SqlCommand(sql, dbHelper.LiteCon);
                cmd.Parameters.AddWithValue("@pwd", this.lbl_fcpConfirmPwd.Text);
                cmd.Parameters.AddWithValue("@name", FcpUser.UserName);
                try
                {
                    dbHelper.OpenDB();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("密码修改成功!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dbHelper.CloseDB();
                }
            }
            else if (this.lbl_fcpNewPwd.Text.Trim() != this.lbl_fcpConfirmPwd.Text.Trim())
            {
                MessageBox.Show("新密码与确认密码不一致!", "提示");
            }
            else
            {
                MessageBox.Show("原密码不正确!", "提示");
            }
        }
    }
}

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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        DBHelper dbHelper;
        SqlCommand cmd;

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (tbx_userName.Text != string.Empty && tbx_passWord.Text != string.Empty)
            {
                // 创建查询的sql语句
                string sql = "select count(*) from users where username = @username and pwd = @pwd";

                dbHelper = new DBHelper();

                // 参数化sql语句,防止sql注入
                cmd = new SqlCommand(sql, dbHelper.LiteCon);
                cmd.Parameters.AddWithValue("@username", this.tbx_userName.Text);
                cmd.Parameters.AddWithValue("@pwd", this.tbx_passWord.Text);
                try
                {
                    // 打开数据库(使用command方法就涉及到打开和关闭数据库;如果是adapter则不用)
                    dbHelper.OpenDB();

                    // ExecuteScalar返回查询到的第一行第一列,如果用户名密码匹配则返回1行,说明可以登录
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("登录成功!");

                        // 此处进行窗体传值,为了修改密码窗口能够获取到用户名和密码
                        TransUser tu = new TransUser();
                        tu.UserName = this.tbx_userName.Text.Trim();
                        tu.Pwd = this.tbx_passWord.Text.Trim();

                        FormSuperMarketMain fsmm = new FormSuperMarketMain();
                        // 显示第二窗体前隐藏当前窗口;依然会占用内存.
                        this.Hide();
                        fsmm.FsmmUser = tu;
                        fsmm.Show();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误!", "提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // 关闭数据库
                    dbHelper.CloseDB();
                }
            }
            else
            {
                MessageBox.Show("请输入用户名和密码!", "提示");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

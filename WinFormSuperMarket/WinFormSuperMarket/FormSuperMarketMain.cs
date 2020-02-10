using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSuperMarket
{
    public partial class FormSuperMarketMain : Form
    {
        public FormSuperMarketMain()
        {
            InitializeComponent();
        }

        #region 窗体传值
        // 把整个对象作为传值
        public TransUser FsmmUser { get; set; }
        #endregion

        #region 菜单栏动作
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePwd fcp = new FrmChangePwd();
            // 窗体传值
            fcp.FcpUser = FsmmUser;
            fcp.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout fa = new FrmAbout();
            fa.ShowDialog();
        }
        private void FormSuperMarketMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 图片动作区
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmCommodityMange fcm = new FrmCommodityMange();
            fcm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmSortList fsl = new FrmSortList();
            fsl.ShowDialog();
        }
        #endregion


    }
}

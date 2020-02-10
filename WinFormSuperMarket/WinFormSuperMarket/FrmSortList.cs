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
    public partial class FrmSortList : Form
    {
        public FrmSortList()
        {
            InitializeComponent();
        }

        #region 变量
        DBHelper dBHelper = new DBHelper();
        SqlDataAdapter adapter;
        DataSet ds;
        #endregion

        #region 事件
        private void FrmSortList_Load(object sender, EventArgs e)
        {
            this.LoadList();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmSort fs = new FrmSort();
            fs.ShowDialog();
            LoadList();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            FrmSort fs = new FrmSort();
            fs.sortId = Convert.ToInt32(dgv_SortList.CurrentRow.Cells[0].Value);
            fs.ShowDialog();
            LoadList();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // 尝试使用adapter隐式的对表操作(不使用SQL语句,SqlCommand为显示)
            // 获取DataSet视图表中的选中行的索引
            int number = dgv_SortList.CurrentRow.Index;
            string sn = dgv_SortList.CurrentRow.Cells[1].Value.ToString();
            DialogResult dr = MessageBox.Show(string.Format("是否要删除商品分类：{0} ？", sn), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            try
            {
                if (dr == DialogResult.Yes)
                {
                    // 删除选中行
                    ds.Tables["Commoditysort"].Rows[number].Delete();
                    // 关键步骤,关联实体数据库
                    new SqlCommandBuilder(adapter);
                    // 重新生成表
                    adapter.Update(ds, "Commoditysort");
                    MessageBox.Show("删除成功!");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("商品分类已被使用,无法被删除!");
            }
            finally
            {
                this.LoadList();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 方法
        private void LoadList()
        {
            string sql = @"select SortId as 编号 , sortName as 类别名称 from Commoditysort;";
            adapter = new SqlDataAdapter(sql, dBHelper.LiteCon);
            ds = new DataSet();
            adapter.Fill(ds, "Commoditysort");

            dgv_SortList.DataSource = ds.Tables["Commoditysort"];
        }
        #endregion


    }
}

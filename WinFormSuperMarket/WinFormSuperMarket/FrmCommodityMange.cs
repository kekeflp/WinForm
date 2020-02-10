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
    public partial class FrmCommodityMange : Form
    {
        public FrmCommodityMange()
        {
            InitializeComponent();
        }
        DBHelper dbHelper;
        SqlDataAdapter adapter;
        DataSet ds;

        // 窗体加载时间
        private void FrmCommodityMange_Load(object sender, EventArgs e)
        {
            tv_Tree.Nodes[0].Expand();
            FillList();
        }

        // 窗体加载时显示所有条目
        public void FillList()
        {
            //commodityid commodityname categoryid purchaseprice isdiscount selingprice
            string sql = string.Format(@"SELECT 
                                                A.CommodityId 商品编号,
                                                A.CommodityName 商品名称,
                                                B.SortName 商品类别,
                                                A.CommodityPrice 商品价格,
                                                A.IsDiscount 是否特价,
                                                A.ReducedPrice 打折价格
                                         FROM     
                                                Commodity AS A
                                                    INNER JOIN
                                                CommoditySort AS B ON A.SortID = B.SortID;");
            dbHelper = new DBHelper();
            adapter = new SqlDataAdapter(sql, dbHelper.LiteCon);

            // 在缓存中创建数据建库表的映射
            ds = new DataSet();
            adapter.Fill(ds, "Commodity");

            dgv_List.DataSource = ds.Tables["Commodity"];
        }

        #region TreeView事件
        // 过滤的方法(-----------重点思路)
        private void Filter(bool IsDiscount)
        {
            DataView dv = new DataView(ds.Tables["Commodity"]);
            // 1表示特价,0表示原价
            if (IsDiscount == true)
            {
                // 重点,属性RowFilter,需掌握
                dv.RowFilter = "是否特价=1";
            }
            else
            {
                dv.RowFilter = "是否特价=0";
            }
            dgv_List.DataSource = dv;
        }

        private void tv_Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // e表示当前选中的节点----重点思路
            if (e.Node.Text == "正价商品")
            {
                Filter(true);
            }
            else if (e.Node.Text == "特价商品")
            {
                Filter(false);
            }
            else
            {
                this.dgv_List.DataSource = ds.Tables["Commodity"];
            }
        }
        #endregion

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmEditCommodity fec = new FrmEditCommodity();
            fec.frmStatus = 0;
            fec.ShowDialog();
            // 刷新商品显示列表
            FillList();
        }

        private void btn_Mod_Click(object sender, EventArgs e)
        {
            FrmEditCommodity fec = new FrmEditCommodity();
            // 获取当前datagridview当前行的id
            fec.frmStatus = Convert.ToInt32(dgv_List.CurrentRow.Cells[0].Value);
            fec.ShowDialog();
            // 刷新商品显示列表
            FillList();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            this.DeleteCommit();
            FillList();
        }

        /// <summary>
        /// 删除商品的方法
        /// </summary>
        private void DeleteCommit()
        {
            if (dgv_List.CurrentRow != null)
            {
                try
                {
                    // UPDATE 表名称 SET 列名称 = 新值 WHERE 列名称 = 某值
                    string sql = string.Format(@"DELETE FROM Commodity WHERE CommodityID=@CommodityID");

                    SqlCommand cmd = new SqlCommand(sql, dbHelper.LiteCon);
                    // CurrentRow表示你选择的当前行,只有1行
                    // SelectRows也是表示你选择的行,但是这个可能是1行,也可能是多行,.count表示选择的总行数
                    cmd.Parameters.AddWithValue("@CommodityID", dgv_List.CurrentRow.Cells["CommodityID"].Value);

                    dbHelper.OpenDB();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("删除成功!");
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
        }
    }
}
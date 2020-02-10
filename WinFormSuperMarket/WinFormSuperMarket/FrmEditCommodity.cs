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
    public partial class FrmEditCommodity : Form
    {
        public FrmEditCommodity()
        {
            InitializeComponent();
            this.numericUpDown2.Enabled = false;
        }

        #region 变量
        // 设值0时,表示为增加数据的窗体
        public int frmStatus = 0;
        SqlCommand cmd;
        DBHelper dbHelper;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataSet ds = new DataSet();
        #endregion

        #region 事件
        private void FrmEditCommodity_Load(object sender, EventArgs e)
        {

            // 窗体载入时判断,添加时调用添加窗体,编辑时调用编辑窗体
            // 0 : 添加 ; 其他: 修改
            if (frmStatus == 0)
            {
                this.cmbLoad();
            }
            else
            {
                this.GetCommit();
                this.btn_Save.Text = "修改";
            }
        }

        /// <summary>
        /// 打折显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chb_IsDiscount_CheckedChanged(object sender, EventArgs e)
        {
            // 判断是否打折,打折时才能输入打折价格
            if (this.chb_IsDiscount.Checked)
            {
                this.numericUpDown2.Enabled = true;
            }
            else
            {
                this.numericUpDown2.Enabled = false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (frmStatus == 0)
            {
                this.InsertCommit();
            }
            else
            {
                this.UpdataCommit();
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 添加商品的方法
        /// </summary>
        private void InsertCommit()
        {
            if (CheckNull())
            {
                if (frmStatus == 0)
                {
                    try
                    {
                        string sql = @"INSERT INTO Commodity (CommodityName,SortId,CommodityPrice,IsDiscount,ReducedPrice) 
                                VALUES (@CommodityName,@SortId,@CommodityPrice,@IsDiscount,@ReducedPrice)";
                        cmd = new SqlCommand(sql, dbHelper.LiteCon);
                        cmd.Parameters.AddWithValue("@CommodityName", this.tbx_CommodityName.Text.Trim());
                        cmd.Parameters.AddWithValue("@SortId", Convert.ToInt32(this.cmb_CommoditySort.SelectedValue));
                        cmd.Parameters.AddWithValue("@CommodityPrice", this.numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@IsDiscount", this.chb_IsDiscount.Checked ? 1 : 0);
                        // 未勾选打折时,原价与打折价格相等
                        cmd.Parameters.AddWithValue("@ReducedPrice", this.chb_IsDiscount.Checked ? (this.numericUpDown2.Value) : (this.numericUpDown1.Value));

                        dbHelper.OpenDB();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("添加成功!");
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
            }
        }

        /// <summary>
        /// 读取商品的方法
        /// </summary>
        private void GetCommit()
        {
            this.cmbLoad();
            try
            {
                string sql = @"SELECT * FROM Commodity WHERE CommodityID=@CommodityID";
                cmd = new SqlCommand(sql, dbHelper.LiteCon);
                cmd.Parameters.AddWithValue("@CommodityID", this.frmStatus);

                dbHelper.OpenDB();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.tbx_CommodityName.Text = reader["CommodityName"].ToString();
                    this.cmb_CommoditySort.SelectedValue = reader["SortId"].ToString();
                    this.numericUpDown1.Value = Convert.ToDecimal(reader["CommodityPrice"]);
                    this.chb_IsDiscount.Checked = Convert.ToBoolean(reader["IsDiscount"]);
                    this.numericUpDown2.Value = Convert.ToDecimal(reader["ReducedPrice"]);
                }
                reader.Close();
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

        /// <summary>
        /// 修改商品的方法
        /// </summary>
        private void UpdataCommit()
        {
            if (CheckNull())
            {
                try
                {
                    // UPDATE 表名称 SET 列名称 = 新值 WHERE 列名称 = 某值
                    string sql = string.Format(@"UPDATE Commodity SET CommodityName=@CommodityName,SortId=@SortId,
                                            CommodityPrice=@CommodityPrice,IsDiscount=@IsDiscount,
                                            ReducedPrice=@ReducedPrice 
                                        WHERE CommodityID=@CommodityID");

                    cmd = new SqlCommand(sql, dbHelper.LiteCon);
                    cmd.Parameters.AddWithValue("@CommodityName", this.tbx_CommodityName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SortId", Convert.ToInt32(this.cmb_CommoditySort.SelectedValue));
                    cmd.Parameters.AddWithValue("@CommodityPrice", this.numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@IsDiscount", this.chb_IsDiscount.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@ReducedPrice", this.chb_IsDiscount.Checked ? (this.numericUpDown2.Value) : (this.numericUpDown1.Value));
                    cmd.Parameters.AddWithValue("@CommodityID", this.frmStatus);

                    dbHelper.OpenDB();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("修改成功!");
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
        }

        /// <summary>
        /// 绑定comobox
        /// </summary>
        private void cmbLoad()
        {
            dbHelper = new DBHelper();
            try
            {
                string sql = "SELECT * From CommoditySort order by SortId;";
                adapter = new SqlDataAdapter(sql, dbHelper.LiteCon);
                adapter.Fill(ds, "CommoditySort");
                // 绑定数据
                this.cmb_CommoditySort.DataSource = ds.Tables["CommoditySort"];
                // 隐藏的列
                this.cmb_CommoditySort.ValueMember = "SortId";
                // 显示的列
                this.cmb_CommoditySort.DisplayMember = "SortName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 商品名称的非空判断
        /// </summary>
        /// <returns></returns>
        private bool CheckNull()
        {
            bool ok = true;
            if (this.tbx_CommodityName.Text == string.Empty)
            {
                MessageBox.Show("商品名称不能为空");
                ok = false;
            }
            return ok;
        }
        #endregion
    }
}
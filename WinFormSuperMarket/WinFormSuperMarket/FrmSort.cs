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
    public partial class FrmSort : Form
    {
        public FrmSort()
        {
            InitializeComponent();
        }

        #region 变量
        public int sortId = 0;
        #endregion

        #region 方法
        /// <summary>
        /// 类别名称非空判断
        /// </summary>
        /// <returns></returns>
        private bool CheckNull()
        {
            bool ok = true;
            if (tbx_SortName.Text == string.Empty)
            {
                ok = false;
                MessageBox.Show("商品类别名称不能为空!");
            }
            return ok;
        }

        /// <summary>
        /// 新增商品类别
        /// </summary>
        private void Insert()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"INSERT INTO CommoditySort VALUES (@SortName)";
                SqlCommand cmd = new SqlCommand(sql, dBHelper.LiteCon);
                cmd.Parameters.AddWithValue("@SortName", this.tbx_SortName.Text.Trim());
                dBHelper.OpenDB();
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
                dBHelper.CloseDB();
            }
        }

        /// <summary>
        /// 填充类别名称
        /// </summary>
        private void GetSortName()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"SELECT * FROM CommoditySort WHERE SortID=@SortID";
                SqlCommand cmd = new SqlCommand(sql, dBHelper.LiteCon);
                cmd.Parameters.AddWithValue("@SortID", this.sortId);

                dBHelper.OpenDB();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.tbx_SortName.Text = reader["SortName"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dBHelper.CloseDB();
            }
        }

        /// <summary>
        /// 修改商品类别
        /// </summary>
        private void Update()
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                string sql = @"UPDATE CommoditySort SET SortName=@SortName WHERE SortID=@SortID";
                SqlCommand cmd = new SqlCommand(sql, dBHelper.LiteCon);
                cmd.Parameters.AddWithValue("@SortID", sortId);
                cmd.Parameters.AddWithValue("@SortName", this.tbx_SortName.Text.Trim());
                dBHelper.OpenDB();
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
                dBHelper.CloseDB();
            }
        }
        #endregion

        #region 事件
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (CheckNull() && this.sortId == 0)
            {
                this.Insert();
            }
            else
            {
                this.Update();
            }
        }

        private void FrmSort_Load(object sender, EventArgs e)
        {
            if (this.sortId != 0)
            {
                this.GetSortName();
                this.btn_Save.Text = "编辑";
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

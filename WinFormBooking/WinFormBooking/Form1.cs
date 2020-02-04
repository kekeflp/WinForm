using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WinFormBooking
{
    public partial class frmBooking : Form
    {
        public frmBooking()
        {
            InitializeComponent();
        }

        DBHelper dbHelper;
        MySqlDataAdapter adapter;
        private void Form1_Load(object sender, EventArgs e)
        {
            CmbLoad();
        }

        #region Comobox数据加载
        /// <summary>
        /// Comobox数据加载
        /// </summary>
        private void CmbLoad()
        {
            string sql = @"select * from cityinfo";
            dbHelper = new DBHelper();

            // 创建连接器,类似上下文功能
            adapter = new MySqlDataAdapter(sql, dbHelper.MysqlCon);

            // 创建数据集(容器)
            DataSet ds = new DataSet();

            // 填充数据集(容器)
            adapter.Fill(ds, "cityinfo");

            // 在DataSet(容器)-DataTable(表)-DataRow(行)的首行插入 "请选择"
            DataRow row = ds.Tables["cityinfo"].NewRow();
            row[0] = -1;
            row[1] = "请选择";
            ds.Tables["cityinfo"].Rows.InsertAt(row, 0);

            /* 创建视图 (为什么要获取视图???)
               DataView类用来表示定制的DataTable的视图。
               DataTable和DataView的关系是遵循著名的设计模式--文档/视图模式，其中DataTable是文档，而Dataview是视图。
               在任何时候，你都可以有多个基于相同数据的不同的视图.
            */
            DataView dv1 = new DataView(ds.Tables["cityinfo"]);
            DataView dv2 = new DataView(ds.Tables["cityinfo"]);

            // combobox绑定数据
            this.cmbLeave.DataSource = dv1;
            this.cmbLeave.DisplayMember = "cityname";
            this.cmbLeave.ValueMember = "id";

            this.cmbDestination.DataSource = dv2;
            this.cmbDestination.DisplayMember = "cityname";
            this.cmbDestination.ValueMember = "id";
        }
        #endregion

        #region DataGridView数据加载
        /// <summary>
        /// DataGridView数据加载
        /// </summary>
        private void DgvLoad()
        {
            string dgvSql = string.Format(@"SELECT 
                                                flightNo,airways,leaveTime,landTime, price
                                            FROM
                                                flightinfo,
                                                airwaysinfo
                                            WHERE
                                                flightinfo.airwaysId = airwaysinfo.id
                                                    AND leaveCity = {0}
                                                    AND destination = {1};", this.cmbLeave.SelectedValue, this.cmbDestination.SelectedValue);

            dbHelper = new DBHelper();

            MySqlDataAdapter adapter = new MySqlDataAdapter(dgvSql, dbHelper.MysqlCon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "flightinfo");
            // 此处无需使用视图
            this.dataGridView1.DataSource = ds.Tables["flightinfo"];
        }
        #endregion

        #region 航班数据查询
        /// <summary>
        /// 航班数据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cmbLeave.Text == "请选择" || this.cmbDestination.Text == "请选择")
            {
                MessageBox.Show("请选择出发地和目的地!");
                // 清空datagridview
                this.dataGridView1.DataSource = null;
                // 跳出事件
                return;
            }
            // 载入数据
            DgvLoad();
            // 查询时清空 textbox
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
            }
        }
        #endregion
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                // 找到当前行的索引
                int i = dataGridView1.CurrentCell.RowIndex;
                // 根据索引和列名取值
                this.tbxFlightNo.Text = dataGridView1.Rows[i].Cells["FlightNo"].Value.ToString();
                this.tbxAirways.Text = dataGridView1.Rows[i].Cells["Airways"].Value.ToString();
                this.tbxLeaveCity.Text = this.cmbLeave.Text;
                this.tbxDestination.Text = this.cmbDestination.Text;
                this.tbxLeaveTime.Text = dataGridView1.Rows[i].Cells["LeaveTime"].Value.ToString();
                this.tbxlandTime.Text = dataGridView1.Rows[i].Cells["landTime"].Value.ToString();
                this.tbxPrice.Text = dataGridView1.Rows[i].Cells["price"].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool ValueTag()
        {
            if (this.tbxFlightNo.Text == string.Empty)
            {
                MessageBox.Show("请选择航班号");
                return false;
            }//此处还需要判断出发日期是否小于出发时间的逻辑
            else if (dateTimePicker1.Value < DateTime.Now )
            {
                MessageBox.Show("请选择正确的出发日期");
                dateTimePicker1.Focus();
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValueTag())
            {
                Random r = new Random();
                int orderId = r.Next(100000, 999999);
                string flightNo = this.tbxFlightNo.Text;
                DateTime leavdDate = this.dateTimePicker1.Value.Date;
                int number = (int)this.numericUpDown1.Value;

                string insertSql = string.Format(@"INSERT INTO orderinfo (orderId,flightNo,leavdDate,number) 
                                                VALUES ({0},'{1}','{2}',{3})", orderId, flightNo, leavdDate, number);
                try
                {
                    // 创建SQL执行对象
                    MySqlCommand command = new MySqlCommand(insertSql, dbHelper.MysqlCon);
                    // 打开数据库
                    dbHelper.OpenDB();
                    // 增删改,后返回受影响的行数
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show($"预定成功。\r\n您的订单号是：{orderId}，航班是：{flightNo}，出发日期是：{leavdDate}，票数是：{number}。");
                    }
                    else
                    {
                        MessageBox.Show("预定失败,请重试!");
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

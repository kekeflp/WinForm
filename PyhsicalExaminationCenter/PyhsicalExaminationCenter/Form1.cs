using PyhsicalExaminationCenter.Models;
using PyhsicalExaminationCenter.Services;
using System;
using System.Windows.Forms;

namespace PyhsicalExaminationCenter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 启动时载入所有的检查项目
            Load += Form1_Load;
        }

        public HealthPackageService HealthPackageService { get; set; } = new HealthPackageService();

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            // 小技巧，使用toarray后可以自动刷新。
            comboBox2.DataSource = HealthPackageService.HealthItems.ToArray();

            // 当选择套餐时
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 当前选中项作为对象
            var package = comboBox1.SelectedItem as HealthPackage;
            label1.Text = package.Name;
            // 格式化为人民币方式显示
            label2.Text = package.SumPrice.ToString("c");

            dataGridView1.DataSource = package.HealthItems.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HealthPackageService.CreatePackage(textBox1.Text);
                // 小技巧，使用toarray后可以自动刷新。
                comboBox1.DataSource = HealthPackageService.HealthPackages.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 向套餐中加项目，并显示到列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var packageId = (int)comboBox1.SelectedValue;
                var itemId = (int)comboBox2.SelectedValue;
                HealthPackageService.CreateItemByPackage(packageId, itemId);

                // 刷新datagridview
                var package = comboBox1.SelectedItem as HealthPackage;
                label1.Text = package.Name;
                label2.Text = package.SumPrice.ToString("c");
                dataGridView1.DataSource = package.HealthItems.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var packageId = (int)comboBox1.SelectedValue;
                // 获取当选选中行的索引
                int temp = dataGridView1.CurrentRow.Index;
                // 获取选中行中id列的值
                var itemId = (int)dataGridView1.Rows[temp].Cells["Id"].Value;

                HealthPackageService.RemoveItemByPackage(packageId, itemId);

                // 刷新datagridview
                var package = comboBox1.SelectedItem as HealthPackage;
                label1.Text = package.Name;
                label2.Text = package.SumPrice.ToString("c");
                dataGridView1.DataSource = package.HealthItems.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

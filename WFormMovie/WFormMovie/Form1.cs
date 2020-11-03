using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFormMovie.Models;
using WFormMovie.Services;

namespace WFormMovie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MovieService MovieService { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            MovieService = new MovieService();

            foreach (var movie in MovieService.Movies)
            {
                // 父节点
                var movieNode = new TreeNode(movie.Title)
                {
                    // 储存节点对象
                    Tag = movie
                };
                treeView1.Nodes.Add(movieNode);

                // 子节点
                foreach (var time in movie.MovieTime)
                {
                    var timeNode = new TreeNode(time.Time)
                    {
                        // 储存节点对象
                        Tag = time
                    };
                    movieNode.Nodes.Add(timeNode);
                }
            }

            // 选择节点是发生的事件处理
            treeView1.AfterSelect += TreeView1_AfterSelect;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                var movie = e.Node.Parent.Tag as Movie;
                pictureBox1.Image = movie.Img;
                label1.Text = movie.Title;
                label2.Text = movie.FilmType;
                label3.Text = movie.Director;
                label4.Text = movie.Star;
                textBox1.Text = movie.Description;
                label5.Text = movie.Price.ToString("C");

                // 当前节点的tag中存有对象
                InitTickets((e.Node.Tag as MovieTime).Tickets);
            }
        }

        private void InitTickets(List<Ticket> tickets)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var ticket in tickets)
            {
                flowLayoutPanel1.Controls.Add(new UCTicket(ticket));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 声明一个所有座位的集合
            List<Ticket> tickets = new List<Ticket>();
            // 找出控件中所有黄色的座位
            foreach (UCTicket item in flowLayoutPanel1.Controls)
            {
                if (item.BackColor == Color.Yellow)
                {
                    tickets.Add(item.TicketPro);
                }
            }
            // 计算选中的座位的总价
            var money = MovieService.BuyTicket(treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Text, tickets.Select(m => m.Seat).ToList());

            // 刷新下票，并且找到选中场次所有的票
            InitTickets((treeView1.SelectedNode.Tag as MovieTime).Tickets);

            MessageBox.Show($"本次总消费：{money.ToString("C")}");
        }
    }
}

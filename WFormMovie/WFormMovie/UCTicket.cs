using System;
using System.Drawing;
using System.Windows.Forms;
using WFormMovie.Models;

namespace WFormMovie
{
    public partial class UCTicket : UserControl
    {
        public UCTicket()
        {
            InitializeComponent();
        }

        public Ticket TicketPro { get; set; }

        public UCTicket(Ticket ticket)
        {
            InitializeComponent();
            TicketPro = ticket;
            label1.Text = ticket.Seat;
            if (ticket.IsSaled)
            {
                this.BackColor = Color.Red;
            }
            else
            {
                // 默认颜色
                BackColor = SystemColors.Control;
            }

            // 锁定时需要有颜色变动显示
            this.Click += UCTicket_Click;
            label1.Click += UCTicket_Click;
        }

        private void UCTicket_Click(object sender, EventArgs e)
        {
            if (TicketPro.IsSaled)
            {
                MessageBox.Show("该票已出售！");
            }
            else
            {
                // 如果是黄色就设置为默认色
                if (BackColor == Color.Yellow)
                {
                    BackColor = SystemColors.Control;
                }
                else
                {
                    BackColor = Color.Yellow;
                }
            }
        }
    }
}

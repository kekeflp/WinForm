using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            treeView1.AfterSelect += TreeView1_AfterSelect;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                var movie = e.Node.Parent.Tag as Models.Movie;
                pictureBox1.Image = movie.Img;
                label1.Text = movie.Title;
                label2.Text = movie.FilmType;
                label3.Text = movie.Director;
                label4.Text = movie.Star;
                label5.Text = movie.Description;
                label6.Text = movie.Price.ToString("C");
            }
        }
    }
}

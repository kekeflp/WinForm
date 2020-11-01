using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace WFormMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        // 电影名称
        public string Title { get; set; }
        // 影片类型
        public string FilmType { get; set; }
        // 导演
        public string Director { get; set; }
        // 主演
        public string Star { get; set; }
        // 描述
        public string Description { get; set; }
        // 售价
        public decimal Price { get; set; }
        // 图片
        public string ImagePath { get; set; }
        public Image Img
        {
            get
            {
                if (File.Exists(ImagePath))
                {
                    return Image.FromFile(ImagePath);
                }
                return null;
            }
        }

        // 一个电影包含多个场次
        public List<MovieTime> MovieTime { get; set; } = new List<MovieTime>();
    }
}

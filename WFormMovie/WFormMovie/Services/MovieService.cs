using System.Collections.Generic;
using System.Xml;
using WFormMovie.Models;
using System.Linq;
using System;

namespace WFormMovie.Services
{
    public class MovieService
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();

        /// <summary>
        /// 初始化数据
        /// </summary>
        public MovieService()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Data\Movies.xml");

            var movieNodes = doc.SelectNodes("Movies/Movie");
            foreach (XmlNode movieNode in movieNodes)
            {
                // 解析电影信息
                Movie movie = new Movie
                {
                    Title = movieNode.Attributes["Title"].Value,
                    FilmType = movieNode.Attributes["FilmType"].Value,
                    Director = movieNode.Attributes["Director"].Value,
                    Star = movieNode.Attributes["Star"].Value,
                    Price = decimal.Parse(movieNode.Attributes["Price"].Value),
                    Description = movieNode.SelectSingleNode("Description").InnerText,
                    ImagePath = movieNode.Attributes["ImagePath"].Value
                };
                Movies.Add(movie);

                // 解析电影场次
                foreach (XmlNode timeNode in movieNode.SelectNodes("MovieTime"))
                {
                    movie.MovieTime.Add(
                        new MovieTime()
                        {
                            Time = timeNode.Attributes["Time"].Value,
                            // 一个场次包含多个坐席
                            Tickets = CreateTicketSeats(10, 13)
                        });
                }
            }
        }

        /// <summary>
        /// 生成座位
        /// </summary>
        /// <param name="row">排</param>
        /// <param name="col">列</param>
        /// <returns></returns>
        public List<Ticket> CreateTicketSeats(int row, int col)
        {
            List<Ticket> tickets = new List<Ticket>();
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    tickets.Add(new Ticket()
                    {
                        Seat = $"{ x + 1 }排-{ y + 1 }列"
                    });
                }
            }
            return tickets;
        }

        /// <summary>
        /// 根据放映时间获取座位信息
        /// </summary>
        /// <param name="movieTitle">电影名称</param>
        /// <param name="movieTime">放映时间</param>
        /// <returns></returns>
        public List<Ticket> GetTicketsByTime(string movieTitle, string movieTime)
        {
            // 首先在电影列表中找到电影对象
            var movie = Movies.First(m => m.Title == movieTitle);
            // 在电影对象中找到放映时间场次
            return movie.MovieTime.First(t => t.Time == movieTime).Tickets;
        }

        /// <summary>
        /// 买票的方法(单张)
        /// </summary>
        /// <param name="movieTitle">电影名称</param>
        /// <param name="movieTime">放映时间</param>
        /// <param name="ticketSeat">座位</param>
        public decimal BuyTicket(string movieTitle, string movieTime, string ticketSeat)
        {
            // 首先在电影列表中找到电影对象
            var movie = Movies.First(m => m.Title == movieTitle);
            var price = movie.Price;
            // 在电影对象中找到放映时间场次的票信息（座位信息）
            var ticket = movie.MovieTime.First(t => t.Time == movieTime).Tickets.First(t => t.Seat == ticketSeat);
            // 判断是否已售出
            if (ticket.IsSaled) throw new Exception("该票已售出");
            ticket.IsSaled = true;
            return price;
        }

        /// <summary>
        /// 买票的方法(多张)
        /// </summary>
        /// <param name="movieTitle">电影名称</param>
        /// <param name="movieTime">放映时间</param>
        /// <param name="ticketSeat">座位集合</param>
        public decimal BuyTicket(string movieTitle, string movieTime, List<string> ticketSeat)
        {
            // 首先在电影列表中找到电影对象
            var movie = Movies.First(m => m.Title == movieTitle);
            var price = movie.Price;
            // 在电影对象中找到放映时间场次的票信息（座位信息）
            var tickets = movie.MovieTime.First(t => t.Time == movieTime).Tickets.Where(t => ticketSeat.Contains(t.Seat));

            decimal sumPrice = 0;
            foreach (var ticket in tickets)
            {
                // 判断是否已售出
                if (ticket.IsSaled) throw new Exception("该票已售出");
                ticket.IsSaled = true;
                sumPrice += price;
            }
            return sumPrice;
        }
    }
}

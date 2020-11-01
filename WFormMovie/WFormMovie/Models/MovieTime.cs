using System;
using System.Collections.Generic;

namespace WFormMovie.Models
{
    public class MovieTime
    {
        // 放映时间
        public string Time { get; set; }
        // 一个放映时间包含多个座位
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}

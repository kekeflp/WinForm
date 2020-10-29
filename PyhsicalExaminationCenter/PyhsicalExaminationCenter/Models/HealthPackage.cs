using System.Collections.Generic;
using System.Linq;

namespace PyhsicalExaminationCenter.Models
{
    public class HealthPackage
    {
        // 套餐ID
        public int Id { get; set; }
        // 套餐名称
        public string Name { get; set; }
        // 一个套餐包含多种检查项
        public List<HealthItem> HealthItems { get; set; } = new List<HealthItem>();
        // 检查项总和
        public decimal SumPrice
        {
            get => HealthItems.Sum(x => x.Price);
        }
    }
}

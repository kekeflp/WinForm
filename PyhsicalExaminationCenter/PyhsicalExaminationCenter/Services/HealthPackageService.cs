using PyhsicalExaminationCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyhsicalExaminationCenter.Services
{
    public class HealthPackageService
    {
        public List<HealthPackage> HealthPackages { get; set; } = new List<HealthPackage>();

        public List<HealthItem> HealthItems { get; set; } = new List<HealthItem>()
        {
            new HealthItem(){ Id=1,  Name="一般检查",           Description="一般检查的描述",       Price=5},
            new HealthItem(){ Id=2,  Name="内科",           Description="内科的描述",             Price=6},
            new HealthItem(){ Id=3,  Name="男外科",           Description="男外科的描述",          Price=7},
            new HealthItem(){ Id=4,  Name="视力色觉",           Description="视力色觉的描述",       Price=8},
            new HealthItem(){ Id=5,  Name="外眼",           Description="外眼的描述",              Price=10},
            new HealthItem(){ Id=6,  Name="血常规",           Description="血常规的描述",           Price=100},
            new HealthItem(){ Id=7,  Name="尿常规",           Description="尿常规的描述",           Price=100},
            new HealthItem(){ Id=8,  Name="腹部彩超",           Description="腹部彩超的描述",        Price=150},
            new HealthItem(){ Id=9,  Name="B超",           Description="B超的描述",                Price=200},
            new HealthItem(){ Id=10, Name="心电图",           Description="心电图的描述",           Price=230}
        };

        /// <summary>
        /// 创建套餐对象
        /// </summary>
        /// <param name="name">套餐名</param>
        public void CreatePackage(string name)
        {
            if (HealthPackages.Any(x => x.Name == name))
                throw new Exception("该套餐已存在，请勿重复添加！");
            HealthPackages.Add(new HealthPackage()
            {
                Id = HealthPackages.Count + 1,
                Name = name
            });
        }

        /// <summary>
        /// 向套餐中添加检查项
        /// </summary>
        /// <param name="packageId">套餐ID</param>
        /// <param name="itemId">检查项ID</param>
        public void CreateItemByPackage(int packageId, int itemId)
        {
            var package = HealthPackages.First(x => x.Id == packageId);
            if (package.HealthItems.Any(x => x.Id == itemId))
                throw new Exception($"该项目已经存在套餐{package.Name}中，请勿重复添加！");
            var item = HealthItems.First(x => x.Id == itemId);
            package.HealthItems.Add(item);
        }

        /// <summary>
        /// 向套餐中移除检查项
        /// </summary>
        /// <param name="packageId">套餐ID</param>
        /// <param name="itemId">检查项ID</param>
        public void RemoveItemByPackage(int packageId, int itemId)
        {
            var package = HealthPackages.First(x => x.Id == packageId);
            if (!package.HealthItems.Any(x => x.Id == itemId))
                throw new Exception($"该项目不存在套餐{package.Name}中，请重新选择！");
            var item = HealthItems.First(x => x.Id == itemId);
            package.HealthItems.Remove(item);
        }
    }
}

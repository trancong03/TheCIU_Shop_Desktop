using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace CustomerSegmentation.Data
{
    public class DataLoader
    {
        public static IEnumerable<CustomerData> LoadDataFromDatabase()
        {
            using (var db = new QuanLyShopDataContext())
            {
                return (from order in db.Orders
                        group order by order.username into customerGroup
                        select new CustomerData
                        {
                            TotalSpend = (float)customerGroup.Sum(o => o.amount),
                            TotalOrders = customerGroup.Count(),
                            DaysSinceLastOrder = customerGroup.Max(o => o.order_date) != null
                                ? (int)(DateTime.Now - customerGroup.Max(o => o.order_date).Value).TotalDays
                                : int.MaxValue // Giá trị thay thế
                        }).ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL;
using MLIntegration.Models;

using DTO;
using MLIntegration.Utilities;

namespace MLIntegration.Data
{
    public class FeatureExtractor
    {
        private readonly QuanLyShopDataContext _dbContext;

        public FeatureExtractor()
        {
            _dbContext = new QuanLyShopDataContext();
        }

        public IEnumerable<CustomerData> GetCustomerFeatures()
        {
            // Truy vấn dữ liệu khách hàng từ DB
            var rawData = (from o in _dbContext.Orders
                           join od in _dbContext.OrderDetails on o.order_id equals od.order_id into orderDetails
                           where o.amount.HasValue && o.username != null
                           group new { o, orderDetails } by o.username into g
                           select new CustomerData
                           {
                               CustomerID = g.Key,
                               TotalSpending = (float)g.Sum(x => x.o.amount.Value),
                               OrderCount = (float)g.Count(),
                               DaysSinceLastOrder = (float)((DateTime.Now - g.Max(x => x.o.order_date) ?? TimeSpan.Zero).TotalDays),
                               TotalQuantity = (float)g.Sum(x => x.orderDetails.Sum(od => od.quantity))
                           }).ToList();

            // Chuẩn hóa dữ liệu trước khi trả về
            var normalizedData = NormalizationHelper.Normalize(rawData);

            return normalizedData;
        }

    }
}


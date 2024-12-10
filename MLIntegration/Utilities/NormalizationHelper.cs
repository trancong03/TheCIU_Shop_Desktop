using MLIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MLIntegration.Utilities
{
    public static class NormalizationHelper
    {
        public static IEnumerable<CustomerData> Normalize(IEnumerable<CustomerData> data)
        {
            // Tính toán min và max cho từng đặc trưng
            float minTotalSpending = data.Min(d => d.TotalSpending);
            float maxTotalSpending = data.Max(d => d.TotalSpending);

            float minOrderCount = data.Min(d => (float)d.OrderCount);
            float maxOrderCount = data.Max(d => (float)d.OrderCount);

            float minDaysSinceLastOrder = data.Min(d => (float)d.DaysSinceLastOrder);
            float maxDaysSinceLastOrder = data.Max(d => (float)d.DaysSinceLastOrder);

            float minTotalQuantity = data.Min(d => (float)d.TotalQuantity);
            float maxTotalQuantity = data.Max(d => (float)d.TotalQuantity);

            // Chuẩn hóa dữ liệu
            return data.Select(d => new CustomerData
            {
                CustomerID = d.CustomerID,
                TotalSpending = NormalizeValue(d.TotalSpending, minTotalSpending, maxTotalSpending),
                OrderCount = NormalizeValue(d.OrderCount, minOrderCount, maxOrderCount),
                DaysSinceLastOrder = NormalizeValue(d.DaysSinceLastOrder, minDaysSinceLastOrder, maxDaysSinceLastOrder),
                TotalQuantity = NormalizeValue(d.TotalQuantity, minTotalQuantity, maxTotalQuantity)
            });
        }

        private static float NormalizeValue(float value, float min, float max)
        {
            return max == min ? 0 : (value - min) / (max - min); // Tránh chia cho 0
        }

        private static float NormalizeValue(int value, float min, float max)
        {
            return max == min ? 0 : (value - min) / (max - min); // Ép kiểu int sang float
        }
    }
}

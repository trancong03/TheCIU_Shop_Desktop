namespace CustomerSegmentation
{
    public class CustomerData
    {
        public float TotalSpend { get; set; }          // Tổng chi tiêu
        public int TotalOrders { get; set; }           // Tổng số đơn hàng
        public int DaysSinceLastOrder { get; set; }    // Số ngày kể từ lần mua cuối
    }

    public class CustomerPrediction
    {
        public uint PredictedCluster { get; set; }     // Cụm dự đoán
    }
}

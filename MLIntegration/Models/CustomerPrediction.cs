using Microsoft.ML.Data;

namespace MLIntegration.Models
{
    public class CustomerPrediction
    {
        public string CustomerID { get; set; }    // ID Khách hàng

        [ColumnName("PredictedLabel")]
        public uint ClusterId { get; set; }       // Gán cụm cho mỗi khách hàng

        [ColumnName("Score")] // Cột chứa các khoảng cách
        public float[] Distances { get; set; }    // Khoảng cách đến các trung tâm cụm
    }
}

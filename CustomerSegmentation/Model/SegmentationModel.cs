using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace CustomerSegmentation.Model
{
    public class SegmentationModel
    {
        private static readonly string ModelPath = Path.Combine(Environment.CurrentDirectory, "customerSegmentationModel.zip");
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public SegmentationModel()
        {
            _mlContext = new MLContext();
        }

        public void Train(IEnumerable<CustomerData> data)
        {
            // 1. Chuyển đổi dữ liệu thành IDataView
            IDataView dataView = _mlContext.Data.LoadFromEnumerable(data);

            // 2. Tiền xử lý dữ liệu (chỉ sử dụng các cột cần thiết)
            var pipeline = _mlContext.Transforms.Concatenate("Features", nameof(CustomerData.TotalSpend), nameof(CustomerData.TotalOrders), nameof(CustomerData.DaysSinceLastOrder))
                                                 .Append(_mlContext.Clustering.Trainers.KMeans(featureColumnName: "Features", numberOfClusters: 3));

            // 3. Huấn luyện mô hình
            _model = pipeline.Fit(dataView);

            // 4. Lưu mô hình ra file
            _mlContext.Model.Save(_model, dataView.Schema, ModelPath);
            Console.WriteLine($"Mô hình đã được lưu tại: {ModelPath}");
        }
    }
}

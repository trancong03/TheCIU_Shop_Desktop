using Microsoft.ML;
using System;
using System.IO;

namespace CustomerSegmentation.Predictor
{
    public class CustomerPredictor
    {
        private static readonly string ModelPath = Path.Combine(Environment.CurrentDirectory, "customerSegmentationModel.zip");
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public CustomerPredictor()
        {
            _mlContext = new MLContext();

            if (!File.Exists(ModelPath))
                throw new FileNotFoundException($"Mô hình không tồn tại tại đường dẫn: {ModelPath}");

            // Tải mô hình từ file
            _model = _mlContext.Model.Load(ModelPath, out _);
        }

        public CustomerPrediction Predict(CustomerData input)
        {
            // 1. Tạo PredictionEngine
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<CustomerData, CustomerPrediction>(_model);

            // 2. Dự đoán
            var prediction = predictionEngine.Predict(input);
            return prediction;
        }
    }
}

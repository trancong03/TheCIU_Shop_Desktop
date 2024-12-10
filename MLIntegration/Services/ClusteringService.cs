using MLIntegration.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MLIntegration.Services
{
    public class ClusteringService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public ClusteringService()
        {
            _mlContext = new MLContext();
        }

        public void Train(IEnumerable<CustomerData> data, int numberOfClusters)
        {
            var trainingData = _mlContext.Data.LoadFromEnumerable(data);

            // Tạo pipeline huấn luyện
            var pipeline = _mlContext.Transforms.Concatenate("Features",
                                nameof(CustomerData.TotalSpending),
                                nameof(CustomerData.OrderCount),
                                nameof(CustomerData.DaysSinceLastOrder),
                                nameof(CustomerData.TotalQuantity))
                          .Append(_mlContext.Clustering.Trainers.KMeans(featureColumnName: "Features", numberOfClusters: numberOfClusters));

            // Huấn luyện mô hình
            _model = pipeline.Fit(trainingData);

            var schema = _mlContext.Model.CreatePredictionEngine<CustomerData, CustomerPrediction>(_model).OutputSchema;

            foreach (var column in schema)
            {
                Console.WriteLine($"Column Name: {column.Name}, Column Type: {column.Type}");
            }

        }

        public IEnumerable<CustomerPrediction> Predict(IEnumerable<CustomerData> data)
        {
            var testData = _mlContext.Data.LoadFromEnumerable(data);
            var predictions = _model.Transform(testData);

            var outputSchema = predictions.Schema;
            if (!outputSchema.GetColumnOrNull("PredictedLabel").HasValue)
            {
                throw new Exception("Cột 'PredictedLabel' không được tìm thấy trong dữ liệu đầu ra.");
            }

            return _mlContext.Data.CreateEnumerable<CustomerPrediction>(predictions, reuseRowObject: false);


        }


        public float[][] GetCentroids()
        {
            if (!(_model is TransformerChain<ClusteringPredictionTransformer<KMeansModelParameters>> modelParameters))
                throw new InvalidOperationException("Không thể chuyển đổi mô hình thành KMeansModelParameters.");

            var kMeansModel = modelParameters.LastTransformer.Model;

            VBuffer<float>[] centroids = default;
            kMeansModel.GetClusterCentroids(ref centroids, out int k);

            return centroids.Select(c => c.DenseValues().ToArray()).ToArray();
        }

    }
}

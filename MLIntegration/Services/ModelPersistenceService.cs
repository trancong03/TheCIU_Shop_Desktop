using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLIntegration.Services
{
    public class ModelPersistenceService
    {
        private readonly MLContext _mlContext;

        public ModelPersistenceService()
        {
            _mlContext = new MLContext();
        }

        public void SaveModel(ITransformer model, string modelPath)
        {
            _mlContext.Model.Save(model, null, modelPath);
        }

        public ITransformer LoadModel(string modelPath)
        {
            return _mlContext.Model.Load(modelPath, out _);
        }
    }
}

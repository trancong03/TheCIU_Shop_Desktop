using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace BLL
{
    public class FeedbackBLL
    {
        private FeedbackDAL feedbackDAL = new FeedbackDAL();
        private FeedbackValidation feedbackValidation = new FeedbackValidation();


        public List<Feedback> GetAllFeedbacks()
        {
            return feedbackDAL.GetAllFeedbacks();
        }

        public Feedback GetFeedbackById(int productId, string username)
        {
            return feedbackDAL.GetFeedbackById(productId, username);
        }

        public void AddFeedback(Feedback feedback)
        {
            if (!feedbackValidation.ValidateFeedbackDescription(feedback.discription))
                throw new Exception("Mô tả phản hồi không hợp lệ.");

            if (!feedbackValidation.ValidateRating(feedback.rating))
                throw new Exception("Đánh giá không hợp lệ.");

            feedbackDAL.InsertFeedback(feedback);
        }

        public void EditFeedback(Feedback feedback)
        {
            if (!feedbackValidation.ValidateFeedbackDescription(feedback.discription))
                throw new Exception("Mô tả phản hồi không hợp lệ.");

            if (!feedbackValidation.ValidateRating(feedback.rating))
                throw new Exception("Đánh giá không hợp lệ.");

            feedbackDAL.UpdateFeedback(feedback);
        }

        public void RemoveFeedback(int productId, string username)
        {
            feedbackDAL.DeleteFeedback(productId, username);
        }
    }

}

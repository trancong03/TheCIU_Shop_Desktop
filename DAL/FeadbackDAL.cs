using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FeedbackDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<Feedback> GetAllFeedbacks()
        {
            return db.Feedbacks.ToList();
        }

        public Feedback GetFeedbackById(int productId, string username)
        {
            return db.Feedbacks.SingleOrDefault(f => f.product_id == productId && f.username == username);
        }

        public void InsertFeedback(Feedback feedback)
        {
            db.Feedbacks.InsertOnSubmit(feedback);
            db.SubmitChanges();
        }

        public void UpdateFeedback(Feedback feedback)
        {
            var existingFeedback = db.Feedbacks.SingleOrDefault(f => f.product_id == feedback.product_id && f.username == feedback.username);
            if (existingFeedback != null)
            {
                existingFeedback.discription = feedback.discription;
                existingFeedback.rating = feedback.rating;
                // Update other fields as necessary
                db.SubmitChanges();
            }
        }

        public void DeleteFeedback(int productId, string username)
        {
            var feedback = db.Feedbacks.SingleOrDefault(f => f.product_id == productId && f.username == username);
            if (feedback != null)
            {
                db.Feedbacks.DeleteOnSubmit(feedback);
                db.SubmitChanges();
            }
        }
    }

}

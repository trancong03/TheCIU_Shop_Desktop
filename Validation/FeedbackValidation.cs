using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class FeedbackValidation
    {
        public bool ValidateFeedbackDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return false;

            if (description.Length > 255)
                return false;

            return true;
        }

        public bool ValidateRating(int? rating)
        {
            if (rating == null || rating < 1 || rating > 5)
                return false;

            return true;
        }
    }

}

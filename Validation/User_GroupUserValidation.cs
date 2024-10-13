using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class UserGroupUserValidation
    {
        public bool ValidateGroupName(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
                return false;

            if (groupName.Length < 3 || groupName.Length > 50)
                return false;

            return true;
        }
    }

}

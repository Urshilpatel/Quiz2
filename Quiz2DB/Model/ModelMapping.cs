using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2DB.Model
{
     public class ModelMapping
    {
        public Quiz2 LoadAddress(Quiz2DB.Quiz2 addr1)
        {
            return new Quiz2
            {
                StudentId = addr1.StudentId,
                FirstName = addr1.FirstName,
                LastName = addr1.LastName,
                Type = addr1.Type,
                ImageUrl = addr1.ImageUrl,
                Address = addr1.Address
            };
        }
    }
}

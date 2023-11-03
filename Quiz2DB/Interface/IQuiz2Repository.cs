using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2DB.Interface
{
   public interface IQuiz2Repository : IDisposable
    {
        IQueryable<Quiz2> GetAddress();
        bool IsAddressExist(string FirstName, string LastName, string Type, string ImageUrl, string Address);
        bool AddAddress(string FirstName, string LastName, string Type, string ImageUrl, string Address);
    }
}

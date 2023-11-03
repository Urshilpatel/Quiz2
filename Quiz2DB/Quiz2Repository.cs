using Quiz2DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2DB
{
    public class Quiz2Repository : IQuiz2Repository
    {
        Quiz2Context _Ctx;

        public Quiz2Repository(Quiz2Context Context)
        {
            _Ctx = Context;
            _Ctx.Context.Configuration.LazyLoadingEnabled = false;
            _Ctx.Context.Configuration.ProxyCreationEnabled = false;
        }

        // Start Method Development
        public IQueryable<Quiz2> GetAddress()
        {
            return _Ctx.Context.Quiz2;
        }

        public bool AddAddress(string FirstName, string LastName, string Type, string ImageUrl, string Address)
        {
            return true;
        }
        // End Method Development

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }

        public bool IsAddressExist(string FirstName, string LastName, string Type, string ImageUrl, string Address)
        {
            throw new NotImplementedException();
        }
    }
}

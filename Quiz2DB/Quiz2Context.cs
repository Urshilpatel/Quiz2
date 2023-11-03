using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2DB
{
     public class Quiz2Context
    {
        Quiz2DbEntities _Ctx;

        public Quiz2Context()
        {
            _Ctx = new Quiz2DbEntities();
        }

        public Quiz2DbEntities Context
        {
            get
            {
                return this._Ctx;
            }
        }

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }
    }
}

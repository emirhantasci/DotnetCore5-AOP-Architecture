using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirApi.Core.DataAccess.EntityFramework;
using EmirApi.DataAccess.Abstract;
using EmirApi.DataAccess.Concrete.EntityFramework.Contexts;
using EmirApi.Entities.Concrete;

namespace EmirApi.DataAccess.Concrete.EntityFramework
{
    public class EfXTestDal : EfEntityRepositoryBase<XTest, DbEmirContext>, IXTestDal
    {

    }
}

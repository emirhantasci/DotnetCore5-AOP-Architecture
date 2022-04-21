using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirApi.Core.DataAccess;
using EmirApi.Entities.Concrete;

namespace EmirApi.DataAccess.Abstract
{
    public interface IXTestDal : IEntityRepository<XTest>
    {
    }
}


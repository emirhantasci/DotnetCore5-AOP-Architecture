using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirApi.Core.Utilities.Results;
using EmirApi.Entities.Concrete;
using EmirApi.Entities.Dtos;

namespace EmirApi.Business.Abstract
{
    public interface ICommonService
    {

        IDataResult<List<XTest>> GetListTest();
    }
}

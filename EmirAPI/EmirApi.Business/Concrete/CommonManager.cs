using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirApi.Business.Abstract;
using EmirApi.Core.Aspects.Autofac.Exception;
using EmirApi.Core.Aspects.Autofac.Logging;
using EmirApi.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using EmirApi.Entities.Concrete;
using EmirApi.Entities.Dtos;
using EmirApi.Entities.Concrete;
using EmirApi.Entities.Dtos;
using EmirApi.DataAccess.Abstract;
using EmirApi.Core.Utilities.Results;
using EmirApi.Business.Constants;

namespace EmirApi.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(FileLogger))]
    public class CommonManager : ICommonService
    {
        IXTestDal _xTestDal;
        public CommonManager(IXTestDal xTestDal)
        {
            _xTestDal = xTestDal;
        }
        public IDataResult<List<XTest>> GetListTest()
        {
            List<XTest> _list = (List<XTest>)_xTestDal.GetList();
            
            if (_list.Count>0)
            {
                return new SuccessDataResult<List<XTest>>(_list);
            }
            return new ErrorDataResult<List<XTest>>(Messages.TestMessges);
        }
    }
}

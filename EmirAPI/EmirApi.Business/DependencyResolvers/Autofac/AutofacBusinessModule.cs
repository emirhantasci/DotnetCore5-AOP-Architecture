using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirApi.Business.Abstract;
using EmirApi.Business.Concrete;
using EmirApi.DataAccess.Abstract;
using EmirApi.DataAccess.Concrete.EntityFramework;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EmirApi.Core.Utilities.Interceptors;

namespace EmirApi.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<CommonManager>().As<ICommonService>();
            builder.RegisterType<EfXTestDal>().As<IXTestDal>();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

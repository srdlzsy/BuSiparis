using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //users
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            //customers
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            //filehelper
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            //sellers
            builder.RegisterType<SellerManager>().As<ISellerService>().SingleInstance();
            builder.RegisterType<EfSellerDal>().As<ISellerDal>().SingleInstance();
            
            //jwt
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //service
            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();
            builder.RegisterType<EfServiceDal>().As<IServiceDal>().SingleInstance();

            //service category
            builder.RegisterType<ServiceCategoryManager>().As<IServiceCategoryService>().SingleInstance();  
            builder.RegisterType<EfServiceCategoryDal>().As<IServiceCategoryDal>().SingleInstance();

            //main service category
            builder.RegisterType<MainServiceCategoryManager>().As<IMainServiceCategoryService>().SingleInstance();
            builder.RegisterType<EfMainServiceCategoryDal>().As<IMainServiceCategoryDal>().SingleInstance();





            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

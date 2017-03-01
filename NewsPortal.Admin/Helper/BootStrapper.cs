using Autofac;
using Autofac.Integration.Mvc;
using NewsPortal.Core.Infrastructure;
using NewsPortal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Admin.Helper
{
    public class BootStrapper
    {
        //runs on boot time

        public static void RunConfig() {
            BuildAutoFac();
        }

        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();
            //Model lerin repositoryleri register edilecek
            builder.RegisterType<ContentRepository>().As<IContentRepository>();
            builder.RegisterType<ImageRepository>().As<IImageRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
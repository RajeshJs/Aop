using AspectCore.Extensions.Autofac;
using Autofac;
using System;

namespace Aop
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service>().As<IService>();

            builder.RegisterType<Context>().PropertiesAutowired().As<IContext>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionStore>().PropertiesAutowired().As<IPermissionStore>().SingleInstance();
            builder.RegisterDynamicProxy();

            var container = builder.Build();
            var service = container.Resolve<IService>();

            Console.WriteLine(service);

            service.Select();
            service.Insert();
            service.Update();
            service.Delete();

            Console.ReadKey();
        }
    }
}

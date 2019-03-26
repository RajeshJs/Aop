using AspectCore.DynamicProxy;
using AspectCore.Injector;
using System;
using System.Threading.Tasks;

namespace Aop
{
    public class PermissionAttribute : AbstractInterceptorAttribute
    {
        [FromContainer]
        public IContext Context { get; set; }

        [FromContainer]
        public IPermissionStore PermissionStore { get; set; }

        private readonly string _module;
        private readonly string _function;

        public PermissionAttribute(string module, string function)
        {
            _module = module;
            _function = function;
        }

        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            Console.WriteLine("Permission Interceptor...");

            if (PermissionStore.HasPermission(Context.GetRole(), _module, _function))
            {
                return context.Invoke(next);
            }

            Console.WriteLine($"Has no permission to call : module --> {_module}, function --> {_function} ");
            return Task.CompletedTask;
        }
    }
}

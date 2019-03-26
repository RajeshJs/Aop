using System.Collections.Generic;
using System.Linq;

namespace Aop
{
    public class PermissionStore : IPermissionStore
    {
        private static Dictionary<string, Dictionary<string, List<string>>> Stores = new Dictionary<string, Dictionary<string, List<string>>>();

        public PermissionStore()
        {
            if (!Stores.Keys.Any())
            {
                var modules = new Dictionary<string, List<string>>();

                var functions = new List<string>
                {
                    nameof(IService.Select),
                    nameof(IService.Insert),
                    nameof(IService.Update)
                };

                modules.Add(nameof(IService), functions);
                Stores.Add("VIP", modules);
            }
        }

        public bool HasPermission(string role, string module, string function)
        {
            return Stores.ContainsKey(role)
                && Stores[role].ContainsKey(module)
                && Stores[role][module].Contains(function);
        }
    }
}

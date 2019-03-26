namespace Aop
{
    public interface IPermissionStore
    {
        bool HasPermission(string role, string module, string function);
    }
}

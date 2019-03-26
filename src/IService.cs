namespace Aop
{
    public interface IService
    {
        [Permission(nameof(IService), nameof(Select))]
        void Select();

        [Permission(nameof(IService), nameof(Insert))]
        void Insert();

        [Permission(nameof(IService), nameof(Update))]
        void Update();

        [Permission(nameof(IService), nameof(Delete))]
        void Delete();
    }
}

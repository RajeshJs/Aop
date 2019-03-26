using System;

namespace Aop
{
    public class Service : IService
    {
        public void Delete()
        {
            Console.WriteLine($"{nameof(Delete)} called");
        }

        public void Insert()
        {
            Console.WriteLine($"{nameof(Insert)} called");
        }

        public void Select()
        {
            Console.WriteLine($"{nameof(Select)} called");
        }

        public void Update()
        {
            Console.WriteLine($"{nameof(Update)} called");
        }
    }
}

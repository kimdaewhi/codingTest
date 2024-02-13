using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class ConcreteProduct_1 : IProduct
    {
        public string Operation()
        {
            return "ConcreteProduct_1의 Operation 메서드 실행";
        }
    }

    public class ConcreteProduct_2 : IProduct
    {
        public string Operation()
        {
            return "ConcreteProduct_2의 Operation 메서드 실행";
        }
    }

    public class ConcreteCreator_1 : Creator
    {
        // // ConcreteProduct_1을 생성하는 팩토리 메서드 구현
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct_1();
        }
    }

    public class ConcreteCreator_2 : Creator
    {
        // ConcreteProduct_2을 생성하는 팩토리 메서드 구현
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct_2();
        }
    }
}

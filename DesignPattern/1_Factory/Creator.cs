using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    // Creator 추상 클래스
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghrithm
{
    public class MyStack<T>
    {
        T[] _elements;
        int pos = 0;

        public MyStack() 
        { 
            _elements = new T[100];
        }

        public MyStack(T[] elements)
        {
            _elements = elements;
        }

        public void Push(T element)
        {
            _elements[++pos] = element;
        }

        public T Pop()
        {
            return _elements[pos--];
        }
    }
}

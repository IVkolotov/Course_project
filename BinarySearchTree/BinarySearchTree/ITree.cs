using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public interface ITree<T> : IEnumerable<T> where T : IComparable
    {
        void Add(T data);
        void Remove(T data);
        bool Contains(T data);
        void AddItems(IEnumerable<T> values);
        int Count { get;}

        void Clear();

    }
}

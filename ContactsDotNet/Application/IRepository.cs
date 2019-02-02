using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IRepository<T>
    {
         T Find(int index);
         void Remove(int index);
         void Remove(T element);
         void Add(T element);
    }
}

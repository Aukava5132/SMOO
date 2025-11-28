using System.Collections.Generic;

namespace Lab3
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items);
    }
}
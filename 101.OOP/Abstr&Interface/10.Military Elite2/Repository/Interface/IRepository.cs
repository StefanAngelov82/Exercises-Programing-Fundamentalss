using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Repository.Interface
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> SoldiersData { get; }

        public void Add(T item);
        public bool Exist(int id);
        public T GetSoldier(int id);
    }
}

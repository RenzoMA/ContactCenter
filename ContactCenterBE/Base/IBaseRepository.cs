using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.Base
{
    public interface IBaseRepository<T> where T : class
    {
        IList<T> GetLista();
        T GetById(int id);
        void Insert(T datos);
        void Update(T datos);
        void Delete(int id);
    }
}

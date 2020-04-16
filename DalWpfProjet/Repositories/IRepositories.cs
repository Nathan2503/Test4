using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Repositories
{
    public interface IRepositories<Tkey,T> where T:class
    {
        List<T> GetAll();
        T GetOne(Tkey id);
        int Create(T parametre);
        void Update(T parametre);
        void Delete(Tkey id);
    }
}

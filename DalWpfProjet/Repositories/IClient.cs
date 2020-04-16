using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Repositories
{
    public interface IClient<Tkey,T>
    {
        T GetOne(Tkey id);
        List<T> GetAll();
        void Delete(Tkey id);
        int Create(T parametre);
    }
}

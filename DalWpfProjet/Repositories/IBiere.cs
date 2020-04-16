using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Repositories
{
    public interface IBiere<Tkey,T>: IRepositories<Tkey,T> where T:class
    {
        void Desactiver(Tkey id);
        void Activer(Tkey id);
    }
}

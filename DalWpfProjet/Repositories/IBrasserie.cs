using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Repositories
{
    public interface IBrasserie<T>where T:class
    {
        T Get();
        void Update(T parametre);
    }
}

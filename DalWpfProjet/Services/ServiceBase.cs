using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Services
{
    public abstract class ServiceBase<T> where T:new ()
    {
        private static T _base;
        public static T GetLoadBalancer()
        {

            if (_base == null)
            {
                if (_base == null)
                {
                    _base = new T();
                }
            }
            return _base;
        }
    }
}

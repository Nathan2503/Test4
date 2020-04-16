using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.TypeBiere
{
    class TypeBiere : BindableBase
    {
        private int _id;
        private string _nom;
        private string _def;
        private MainVM _main;

        public virtual int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public virtual string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
               RaisePropertyChanged();
            }
        }

        public virtual string Def
        {
            get
            {
                return _def;
            }

            set
            {
                _def = value;
                RaisePropertyChanged();
            }
        }

        public  MainVM Main
        {
            get
            {
                return _main;
            }

            set
            {
                _main = value;
                RaisePropertyChanged();
            }
        }
        public TypeBiere()
        {

        }
        public TypeBiere(MainVM vm)
        {
            Main = vm;
        }
    }
}

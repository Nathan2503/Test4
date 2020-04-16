using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Contact
{
    class Contact : BindableBase
    {
        private int _id;
        private string _adRue;
        private string _adNumero;
        private string _adVille;
        private string _adCodePostal;
        private string _tel;
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

        public virtual string AdRue
        {
            get
            {
                return _adRue;
            }

            set
            {
                _adRue = value;
                RaisePropertyChanged();
            }
        }

        public virtual string AdNumero
        {
            get
            {
                return _adNumero;
            }

            set
            {
                _adNumero = value;
                RaisePropertyChanged();
            }
        }

        public  virtual string AdVille
        {
            get
            {
                return _adVille;
            }

            set
            {
                _adVille = value;
                RaisePropertyChanged();
            }
        }

        public virtual string AdCodePostal
        {
            get
            {
                return _adCodePostal;
            }

            set
            {
                _adCodePostal = value;
                RaisePropertyChanged();
            }
        }

        public virtual string Tel
        {
            get
            {
                return _tel;
            }

            set
            {
                _tel = value;
                RaisePropertyChanged();
            }
        }

        public MainVM Main
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
        public Contact(MainVM vm)
        {
            Main = vm;
        }
        public Contact()
        {

        }
    }
}

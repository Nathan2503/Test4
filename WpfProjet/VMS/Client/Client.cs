using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Client
{
    class Client : BindableBase
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _login;
        private DateTime _dateNaissance=DateTime.Now;
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

        public virtual string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
                RaisePropertyChanged();
            }
        }

        public virtual string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
                RaisePropertyChanged();
            }
        }

        public virtual DateTime DateNaissance
        {
            get
            {
                return _dateNaissance;
            }

            set
            {
                _dateNaissance = value;
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
        public Client()
        {

        }
        public Client(MainVM vm)
        {
            Main = vm;
        }
    }
}

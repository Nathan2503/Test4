using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Evenement
{
    class Evenement :BindableBase
    {
        private int _id;
        private string _desc;
        private DateTime _dateDebut;
        private DateTime _dateFin;
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

        public virtual string Desc
        {
            get
            {
                return _desc;
            }

            set
            {
                _desc = value;
                RaisePropertyChanged();
            }
        }

        public virtual DateTime DateDebut
        {
            get
            {
                return _dateDebut;
            }

            set
            {
                _dateDebut = value;
                RaisePropertyChanged();
            }
        }

        public virtual DateTime DateFin
        {
            get
            {
                return _dateFin;
            }

            set
            {
                _dateFin = value;
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
        public Evenement(MainVM vm)
        {
            Main = vm;
        }
    }
}

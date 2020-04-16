using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Message
{
    class Message :BindableBase
    {
        private int _id;
        private string _contenu;
        private DateTime _datDebut;
        private DateTime _dateFin;
        private MainVM _main;
        public Message(MainVM vm)
        {
            Main = vm;
        }

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

        public virtual string Contenu
        {
            get
            {
                return _contenu;
            }

            set
            {
                _contenu = value;
                RaisePropertyChanged();
            }
        }

        public virtual DateTime DatDebut
        {
            get
            {
                return _datDebut;
            }

            set
            {
                _datDebut = value;
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
    }
}

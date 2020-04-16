using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Horraire
{
    class Horraire : BindableBase
    {
        private int _id;
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private int _heureOuverture;
        private int _minOuverture;
        private int _heureFermeture;
        private int _minFermeture;
        private MainVM _main;
        public Horraire(MainVM vm)
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

        public virtual  DateTime DateFin
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

        public virtual  int HeureOuverture
        {
            get
            {
                return _heureOuverture;
            }

            set
            {
                _heureOuverture = value;
                RaisePropertyChanged();
            }
        }

        public virtual int MinOuverture
        {
            get
            {
                return _minOuverture;
            }

            set
            {
                _minOuverture = value;
                RaisePropertyChanged();
            }
        }

        public virtual int HeureFermeture
        {
            get
            {
                return _heureFermeture;
            }

            set
            {
                _heureFermeture = value;
                RaisePropertyChanged();
            }
        }

        public virtual int MinFermeture
        {
            get
            {
                return _minFermeture;
            }

            set
            {
                _minFermeture = value;
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
        public string HeureMinOuverture
        {
            get
            {
                return HeureOuverture.ToString() + ":" + MinOuverture.ToString();
            }
        }
        public string HeureMinFermeture
        {
            get
            {
                return HeureFermeture.ToString() + ":" + MinFermeture.ToString();
            }
        }
        protected int GetHeure(string temps)
        {
            string h;
            int _Heure;
            string test4 = temps.Substring(1);
            string test2 = temps.Substring(2);
            string test3 = temps.Substring(1, 1);
            if(temps!=null && temps.Substring(1,1) != ":")
            {
                h = temps.Substring(0, 2);
                bool test = int.TryParse(h, out _Heure);
            }
            else
            {
                h = temps.Substring(0, 1);
                bool test = int.TryParse(h, out _Heure);
            }
            return _Heure;
        }
        protected int GetMin(string temps)
        {

            string m;
            int _Min;
            if(temps!=null && temps.Length > 4)
            {
                m = temps.Substring(3, 2);
                bool test = int.TryParse(m, out _Min);
            }
            else
            {
                _Min = 0;
            }
            return _Min;
        }
    }
}

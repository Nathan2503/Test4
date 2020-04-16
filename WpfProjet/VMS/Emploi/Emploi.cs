using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Emploi
{
    class Emploi : BindableBase
    {
        private int _id;
        private string _fonction;
        private string _desc;
        private string _diplomeMin;
        private int? _expMin;
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

        public virtual string Fonction
        {
            get
            {
                return _fonction;
            }

            set
            {
                _fonction = value;
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

        public virtual string DiplomeMin
        {
            get
            {
                return _diplomeMin;
            }

            set
            {
                _diplomeMin = value;
                RaisePropertyChanged();
            }
        }

        public virtual int? ExpMin
        {
            get
            {
                return _expMin;
            }

            set
            {
                _expMin = value;
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
        public Emploi(MainVM vm)
        {
            Main = vm;
        }
    }
}

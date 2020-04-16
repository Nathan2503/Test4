using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Evenement
{
    class CreateEvent : Evenement
    {
        private RelayCommand _create;
        public RelayCommand Create
        {
            get
            {
                if (_create == null)
                {
                    _create = new RelayCommand(FaireCreate, CanFaireCreate);
                }
                return _create;
            }
        }

        private bool CanFaireCreate()
        {
            bool test;
            if (DateDebut != new DateTime() && DateFin!=new DateTime() && Desc != null && DateDebut.Year!=2001 && DateFin.Year!=2001)
            {
                if (DateDebut<=DateFin && DateFin>=DateDebut  && Desc.Length > 3)
                {
                    test = true;
                }
                else
                {
                    test = false;
                }
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireCreate()
        {
            Main.Data.AjouterEvent(this.GetEvenementWPF());
            Desc = null;
            DateFin = new DateTime();
            DateDebut = new DateTime();
        }
        public override DateTime DateDebut
        {
            get
            {
                return base.DateDebut;
            }

            set
            {
                base.DateDebut = value;
                //RaisePropertyChanged();
                Create.RaiseCanExecuteChanged();
            }
        }
        public override DateTime DateFin
        {
            get
            {
                return base.DateFin;
            }

            set
            {
                base.DateFin = value;
                //RaisePropertyChanged();
                Create.RaiseCanExecuteChanged();
            }
        }
        public override string Desc
        {
            get
            {
                return base.Desc;
            }

            set
            {
                base.Desc = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public CreateEvent(MainVM vm) : base(vm)
        {

        }
    }
}

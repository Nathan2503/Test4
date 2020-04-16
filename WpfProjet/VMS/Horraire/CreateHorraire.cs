using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Horraire
{
    class CreateHorraire : Horraire
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
            if (DateDebut != new DateTime() && DateFin != new DateTime() && HeureOuverture != 0 && HeureFermeture != 0 && DateDebut.Year!=2001 && DateFin.Year!=2001)
            {
                if (Verif.IsDateDebutValid(DateDebut) && Verif.IsDatefin(DateFin) && DateFin > DateDebut && HeureFermeture > HeureOuverture)
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
            Main.Data.AjouterHorraire(this.GetHorraireWPF());
            DateDebut = new DateTime();
            DateFin = new DateTime();
            HeureFermeture = 0;
            HeureOuverture = 0;
            MinOuverture = 0;
            MinFermeture = 0;
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
                Create.RaiseCanExecuteChanged();
            }
        }
        public override int HeureFermeture
        {
            get
            {
                return base.HeureFermeture;
            }

            set
            {
                base.HeureFermeture = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override int HeureOuverture
        {
            get
            {
                return base.HeureOuverture;
            }

            set
            {
                base.HeureOuverture = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override int MinOuverture
        {
            get
            {
                return base.MinOuverture;
            }

            set
            {
                base.MinOuverture = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override int MinFermeture
        {
            get
            {
                return base.MinFermeture;
            }

            set
            {
                base.MinFermeture = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public CreateHorraire(MainVM vm):base(vm)
        {

        }
    }
}

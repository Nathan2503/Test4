using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Horraire
{
    class EditHorraire : Horraire
    {
        private RelayCommandG<int> _getEdit;
        private RelayCommand _edit;
        public RelayCommand Edit
        {
            get
            {
                if (_edit == null)
                {
                    _edit = new RelayCommand(FaireEdit, CanFaireEdit);
                }
                return _edit;
            }
        }
        public RelayCommandG<int> GetEdit
        {
            get
            {
                if (_getEdit == null)
                {
                    _getEdit = new RelayCommandG<int>(FaireGetEdit);
                }
                return _getEdit;
            }
        }
        private void FaireGetEdit(int obj)
        {

            HorraireWPF wpf = Main.Data.Horraires.Where(p => p.horraireId == obj).FirstOrDefault();
            DateFin = wpf.horraireDateFin;
            DateDebut = wpf.horraireDateDebut;
            HeureFermeture = GetHeure(wpf.heureFermeture);
            MinFermeture = GetMin(wpf.heureFermeture);
            HeureOuverture = GetHeure(wpf.heureOuverture);
            MinOuverture = GetMin(wpf.heureOuverture);
            Id = wpf.horraireId;

        }
        private bool CanFaireEdit()
        {
            bool test;
            if (Id != 0 && DateDebut != new DateTime() && DateFin != new DateTime() && HeureFermeture != 0 && HeureOuverture != 0 && DateDebut.Year!=2001 && DateFin.Year!=2001)
            {
                if (Verif.IsSameDateDebut(DateDebut, Id) && Verif.IsSameDateFin(DateFin, Id))
                {
                    if (HeureFermeture > HeureOuverture)
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
                    if (Verif.IsDateDebutValid(DateDebut) && Verif.IsDatefin(DateFin) && DateFin > DateDebut && HeureFermeture > HeureOuverture)
                    {
                        test = true;
                    }
                    else
                    {
                        test = false;
                    }
                }

            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireEdit()
        {
            Main.Data.EditerHorraire(this.GetHorraireWPF());
            Id = 0;
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
                Edit.RaiseCanExecuteChanged();
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
                Edit.RaiseCanExecuteChanged();
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
                Edit.RaiseCanExecuteChanged();
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
                Edit.RaiseCanExecuteChanged();
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
                Edit.RaiseCanExecuteChanged();
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
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override int Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public EditHorraire(MainVM vm): base(vm)
        {

        }
    }
}

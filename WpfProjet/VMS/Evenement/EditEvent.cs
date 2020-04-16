using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Evenement
{
    class EditEvent : Evenement
    {
        private RelayCommandG<int> _getEdit;
        private RelayCommand _edit;
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

            EvenementWPF wpf = Main.Data.Evenements.Where(p => p.eventId == obj).FirstOrDefault();
            DateDebut = wpf.eventDateDebut;
            DateFin = wpf.eventDateFin;
            Desc = wpf.eventDescription;
            Id = wpf.eventId;
        }
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

        private bool CanFaireEdit()
        {
            bool test;
            if (Id!=0 && DateDebut != new DateTime() && DateFin != new DateTime() && Desc != null && DateDebut.Year != 2001 && DateFin.Year != 2001)
            {
                if (DateDebut <= DateFin && DateFin >= DateDebut && Desc.Length > 3)
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

        private void FaireEdit()
        {
            Main.Data.EditerEvenement(this.GetEvenementWPF());
            Id = 0;
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
        public override string Desc
        {
            get
            {
                return base.Desc;
            }

            set
            {
                base.Desc = value;
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
        public EditEvent(MainVM vm):base(vm)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Message
{
    class EditMessage : Message
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

            MessageWPF wpf = Main.Data.Messages.Where(p => p.messageAlertId == obj).FirstOrDefault();
            Contenu = wpf.messageContenu;
            DatDebut = wpf.messageDateDebut;
            DateFin = wpf.messageDateFin;
            Id = wpf.messageAlertId;
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
            if ( Id!=0 && Contenu != null && Contenu.Length > 2 && DatDebut != new DateTime() && DateFin != new DateTime() && DatDebut.Year!=2001 && DateFin.Year!=2001)
            {
                if (DateFin > DatDebut)
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
            Main.Data.EditerMessage(this.GetMessageWPF());
            Id = 0;
            DatDebut = new DateTime();
            DateFin = new DateTime();
            Contenu = null;
            
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
        public override string Contenu
        {
            get
            {
                return base.Contenu;
            }

            set
            {
                base.Contenu = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override DateTime DatDebut
        {
            get
            {
                return base.DatDebut;
            }

            set
            {
                base.DatDebut = value;
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
        public EditMessage(MainVM vm) : base(vm)
        {

        }
    }
}

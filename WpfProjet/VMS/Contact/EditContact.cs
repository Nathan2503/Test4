using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Contact
{
    class EditContact : Contact
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

        private bool CanFaireEdit()
        {
            bool test;
            if (Id != 0)
            {
                if (AdCodePostal.Length > 1 && AdNumero.Length >= 1 && AdRue.Length > 1 && AdVille.Length > 1 && Tel.Length > 5)
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
            Main.Data.EditerContact(this.GetContactWPF());
            Id = 0;
            Tel = null;
            AdVille = null;
            AdRue = null;
            AdNumero = null;
            AdCodePostal = null;
            
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

            ContactWPF wpf = Main.Data.Contacts.Where(p => p.contactId == obj).FirstOrDefault();
            AdCodePostal = wpf.adCodePostal;
            AdNumero = wpf.adNumero;
            AdRue = wpf.adRue;
            AdVille = wpf.adVille;
            Tel = wpf.telephone;
            Id = wpf.contactId;

        }
        public override string AdCodePostal
        {
            get
            {
                return base.AdCodePostal;
            }

            set
            {
                base.AdCodePostal = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override string AdNumero
        {
            get
            {
                return base.AdNumero;
            }

            set
            {
                base.AdNumero = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override string AdRue
        {
            get
            {
                return base.AdRue;
            }

            set
            {
                base.AdRue = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override string AdVille
        {
            get
            {
                return base.AdVille;
            }

            set
            {
                base.AdVille = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override string Tel
        {
            get
            {
                return base.Tel;
            }

            set
            {
                base.Tel = value;
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
        public EditContact(MainVM vm):base(vm)
        {

        }
    }
}

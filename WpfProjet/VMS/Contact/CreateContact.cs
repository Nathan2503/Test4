using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Contact
{
    class CreateContact :Contact
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
            if (AdCodePostal != null && AdNumero != null && AdRue != null && AdVille != null && Tel != null)
            {
                if (AdCodePostal.Length > 1 && AdNumero.Length>1 && AdRue.Length>1 && AdVille.Length>1 && Tel.Length>1 && Tel.Length < 13)
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
            Main.Data.AjouterContact(this.GetContactWPF());
            Tel = null;
            AdVille = null;
            AdRue = null;
            AdNumero = null;
            AdCodePostal = null;
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
            }
        }

        public CreateContact(MainVM vm) : base(vm)
        {

        }
    }
}

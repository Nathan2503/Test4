using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Client
{
    class CreateClientVM : Client
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
          if (DateNaissance!=new DateTime() && Nom != null && Prenom != null && Login != null)
            {
                if (Nom.Length>1 && Prenom.Length>1 && Verif.IsLoginValid(Login) && Verif.IsMajeur(DateNaissance))
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
        public override DateTime DateNaissance
        {
            get
            {
               
                return base.DateNaissance;
            }

            set
            {
                base.DateNaissance = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override string Login
        {
            get
            {
                return base.Login;
            }

            set
            {
                base.Login = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override string Nom
        {
            get
            {
                return base.Nom;
            }

            set
            {
                base.Nom = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override string Prenom
        {
            get
            {
                return base.Prenom;
            }

            set
            {
                base.Prenom = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        private void FaireCreate()
        {

            Main.Data.AjouterClient(this.GetClientWPF());
            Login = null;
            Nom =null;
            Prenom = null;
            DateNaissance = DateTime.Now;
        }
        public CreateClientVM(MainVM vm):base(vm)
        {

        }
    }
}

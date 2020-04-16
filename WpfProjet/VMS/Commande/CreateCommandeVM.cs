using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Commande
{
    class CreateCommandeVM :Commande
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
            if (Quantite >0 && BiereId > 0 && ClientId > 0)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }
        public override int Quantite
        {
            get
            {
                return base.Quantite;
            }

            set
            {
                base.Quantite = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override int BiereId
        {
            get
            {
                return base.BiereId;
            }

            set
            {
                base.BiereId = value;
                Create.RaiseCanExecuteChanged();
                SelectBiere.RaiseCanExecuteChanged();
                DeselectBiere.RaiseCanExecuteChanged();
            }
        }
        public override int ClientId
        {
            get
            {
                return base.ClientId;
            }

            set
            {
                base.ClientId = value;
                Create.RaiseCanExecuteChanged();
                SelectClient.RaiseCanExecuteChanged();
                DeselectClient.RaiseCanExecuteChanged();
            }
        }
        private void FaireCreate()
        {
            Main.Data.AjouterCommande(this.GetCommandeWPF());
            BiereId = 0;
            ClientId = 0;
            Quantite = 0;
        }
        public CreateCommandeVM(MainVM vm) : base(vm)
        {

        }

    }
}


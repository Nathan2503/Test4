using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Commande
{
    class EditCommandeVM : Commande
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
            if (Id != 0 && BiereId >0)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireEdit()
        {
            Main.Data.EditerCommande(this.GetCommandeWPF());
            Id = 0;
            Quantite = 0;
            BiereId = 0;
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
            CommandeWPF wpf = Main.Data.Commandes.Where(c=>c.commandeId==obj).FirstOrDefault();
            BiereId = 0;
            Id = wpf.commandeId;
            Quantite = wpf.commandeQuantite;
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
                Edit.RaiseCanExecuteChanged();
                SelectBiere.RaiseCanExecuteChanged();
                DeselectBiere.RaiseCanExecuteChanged();
            }
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
                Edit.RaiseCanExecuteChanged();
            }
        }
        public EditCommandeVM(MainVM vm):base(vm)
        {

        }
    }
}

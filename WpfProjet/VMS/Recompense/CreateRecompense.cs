using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Recompense
{
    class CreateRecompense : Recompense
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
            if (BiereId != 0 && Nom != null && Nom.Length > 3)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireCreate()
        {
            Main.Data.AjouterRecompense(this.GetRecompenseWPF());
            Nom = null;
            BiereId = 0;
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
                Select.RaiseCanExecuteChanged();
                Deselect.RaiseCanExecuteChanged();
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
        public CreateRecompense(MainVM vm):base(vm)
        {

        }
    }
}

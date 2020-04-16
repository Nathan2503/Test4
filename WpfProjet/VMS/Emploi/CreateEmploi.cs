using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Emploi
{
    class CreateEmploi : Emploi
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
            if (ExpMin != null && DiplomeMin != null && Fonction != null && Desc != null)
            {
                if (DiplomeMin.Length > 2 && Fonction.Length > 1 && Desc.Length > 2)
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
            Main.Data.AjouterEmploi(this.GetEmploiWPF());
            Desc = null;
            ExpMin = null;
            Fonction = null;
            DiplomeMin = null;
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
                Create.RaiseCanExecuteChanged();
            }
        }
        public override string DiplomeMin
        {
            get
            {
                return base.DiplomeMin;
            }

            set
            {
                base.DiplomeMin = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override int? ExpMin
        {
            get
            {
                return base.ExpMin;
            }

            set
            {
                base.ExpMin = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override string Fonction
        {
            get
            {
                return base.Fonction;
            }

            set
            {
                base.Fonction = value;
                Create.RaiseCanExecuteChanged();

            }
        }
        public CreateEmploi(MainVM vm) : base(vm)
        {

        }
    }
}

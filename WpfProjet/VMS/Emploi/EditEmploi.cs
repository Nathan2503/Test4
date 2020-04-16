using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Emploi
{
    class EditEmploi : Emploi
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

            EmploiWPF wpf = Main.Data.Emplois.Where(p => p.offreEmploiId == obj).FirstOrDefault();
            DiplomeMin = wpf.diplomeMin;
            ExpMin = wpf.experienceMin;
            Fonction = wpf.fonction;
            Desc = wpf.jobDescription;
            Id = wpf.offreEmploiId;
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
            if (Id != 0 && DiplomeMin != null && ExpMin != null && Fonction != null && Desc != null)
            {
                if (DiplomeMin.Length > 2 && Fonction.Length > 2 && Desc.Length > 5)
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
            Main.Data.EditerEmploi(this.GetEmploiWPF());
            Id = 0;
            Desc = null;
            Fonction = null;
            DiplomeMin = null;
            ExpMin = null;
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
        public override string DiplomeMin
        {
            get
            {
                return base.DiplomeMin;
            }

            set
            {
                base.DiplomeMin = value;
                Edit.RaiseCanExecuteChanged();
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
                Edit.RaiseCanExecuteChanged();
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
        public EditEmploi(MainVM vm): base(vm)
        {

        }
    }
}

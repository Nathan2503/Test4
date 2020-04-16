using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Recompense
{
    class EditRecompense :Recompense
    {
        private RelayCommand _edit;
        private RelayCommandG<int> _getEdit;
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

            RecompenseWPF wpf = Main.Data.Recompenses.Where(p => p.recompenseId == obj).FirstOrDefault();
            Nom = wpf.recompenseNom;
            Id = wpf.recompenseId;

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
            if (Id != 0 && BiereId != 0 && Nom != null && Nom.Length > 3)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
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
                Edit.RaiseCanExecuteChanged();
            }
        }
        private void FaireEdit()
        {
            Main.Data.EditerRecompense(this.GetRecompenseWPF());
            Id = 0;
            Nom = null;
            BiereId = 0;
            
        }

        public EditRecompense(MainVM vm):base(vm)
        {

        }
    }
}

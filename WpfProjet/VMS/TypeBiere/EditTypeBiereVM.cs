using DalWpfProjet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.TypeBiere
{
    class EditTypeBiereVM : TypeBiere
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
            if(Id!=0 && Nom!=null && Def != null && Nom.Length>2 && Def.Length>2)
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
            Main.Data.EditerTypebiere(this.GetTypeBiereWPF());
            Id = 0;
            Nom = null;
            Def = null;
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

        private void FaireGetEdit(int id)
        {
            TypeBiereWPF wpf = Main.Data.TypeBieres.Where(p=>p.typeBiereId==id).FirstOrDefault();
            Id = wpf.typeBiereId;
            Nom = wpf.typeBiereNom;
            Def = wpf.typeBiereDefinition;
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
        public override string Def
        {
            get
            {
                return base.Def;
            }

            set
            {
                base.Def = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public EditTypeBiereVM(MainVM vm): base(vm)
        {

        }
    }
}

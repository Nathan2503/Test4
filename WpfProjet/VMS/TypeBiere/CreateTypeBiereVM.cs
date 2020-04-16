using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.TypeBiere
{
    class CreateTypeBiereVM : TypeBiere
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
            if( Nom!=null && Def!=null && Def.Length>2 && Nom.Length > 2)
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
            
            Main.Data.AjouterTypeBiere(this.GetTypeBiereWPF());
            Id = 0;
            Nom = null;
            Def = null;

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
                //RaisePropertyChanged();
                Create.RaiseCanExecuteChanged();
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
               // RaisePropertyChanged();
                Create.RaiseCanExecuteChanged();
            }
        }



        public CreateTypeBiereVM(MainVM vm) : base(vm)
        {

        }
    }
}

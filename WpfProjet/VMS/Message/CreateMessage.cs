using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Message
{
    class CreateMessage : Message
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
            if (Contenu != null && Contenu.Length > 2 && DatDebut != new DateTime() && DateFin != new DateTime() && DateFin.Year!=2001 && DatDebut.Year!=2001)
            {
                if (DateFin > DatDebut)
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
            Main.Data.AjouterMessage(this.GetMessageWPF());
            DatDebut = new DateTime();
            DateFin = new DateTime();
            Contenu = null;
        }
        public override string Contenu
        {
            get
            {
                return base.Contenu;
            }

            set
            {
                base.Contenu = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override DateTime DateFin
        {
            get
            {
                return base.DateFin;
            }

            set
            {
                base.DateFin = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public override DateTime DatDebut
        {
            get
            {
                return base.DatDebut;
            }

            set
            {
                base.DatDebut = value;
                Create.RaiseCanExecuteChanged();
            }
        }
        public CreateMessage(MainVM vm) : base(vm)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Brasserie
{
    class EditBrasserieVM : BindableBase
    {
        private int _brasserieId;
        private string _nomBrasserie;
        private string _mailInfon;
        private string _mailRecrutement;
        private string _brasseriePresentation;
        private MainVM _main;
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
            if (BrasserieId != 0 && NomBrasserie != "" && BrasseriePresentation != "" && MailRecrutement != "" && MailInfon != "")
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

            Main.Data.DalBrasserie.Update(this.GetBrasserieWPF().GetBrasserieDal());
            Init();

        }

        public int BrasserieId
        {
            get
            {
                return _brasserieId;
            }

            set
            {
                _brasserieId = value;
                RaisePropertyChanged();
                Edit.RaiseCanExecuteChanged();
            }
        }

        public string NomBrasserie
        {
            get
            {
                return _nomBrasserie;
            }

            set
            {
                _nomBrasserie = value;
                RaisePropertyChanged();
                Edit.RaiseCanExecuteChanged();
            }
        }

        public string MailInfon
        {
            get
            {
                return _mailInfon;
            }

            set
            {
                _mailInfon = value;
                RaisePropertyChanged();
                Edit.RaiseCanExecuteChanged();
            }
        }

        public string MailRecrutement
        {
            get
            {
                return _mailRecrutement;
            }

            set
            {
                _mailRecrutement = value;
                RaisePropertyChanged();
                Edit.RaiseCanExecuteChanged();
            }
        }

        public string BrasseriePresentation
        {
            get
            {
                return _brasseriePresentation;
            }

            set
            {
                _brasseriePresentation = value;
                RaisePropertyChanged();
                Edit.RaiseCanExecuteChanged();
            }
        }

        public MainVM Main
        {
            get
            {
                return _main;
            }

            set
            {
                _main = value;
                RaisePropertyChanged();
            }
        }

        private void Init()
        {
           
            BrasserieWPF wpf = Main.Data.DalBrasserie.Get().GetBrasserieWPF();
            BrasserieId = wpf.brasserieId;
            MailInfon = wpf.mailInfon;
            MailRecrutement = wpf.mailRecrutement;
            NomBrasserie = wpf.nomBrasserie;
            BrasseriePresentation = wpf.brasseriePresentation;
        }
        public EditBrasserieVM(MainVM vm)
        {
            Main = vm;
            Init();
        }
    }
}

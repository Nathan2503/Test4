using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Biere
{
    class DetailBiereVM : Biere
    {
        private RelayCommand _activer;
        private RelayCommand _desactiver;
        private RelayCommandG<int> _getDetail;
        private string _typeBiereNom;

        public RelayCommandG<int> GetDetail
        {
            get
            {
                if (_getDetail == null)
                {
                    _getDetail = new RelayCommandG<int>(FaireGetDetail);
                }
                return _getDetail;
            }
            
        }

        private void FaireGetDetail(int obj)
        {
            BiereWPF wpf = Main.Data.Bieres.Where(p => p.biereId == obj).FirstOrDefault();
            Description = wpf.biereDescription;
            Nom = wpf.biereNom;
            Robe = wpf.biereRobe;
            Image = wpf.biereImage;
            Pa = wpf.pourcentageAlcool;
            Prix = wpf.bierePrix;
            Id = wpf.biereId;
            IsDispo = wpf.biereIsDispo;
            if (wpf.typeBiereId != null)
            {
                TypeBiereId =(int) wpf.typeBiereId;
                TypeBiereNom = Main.Data.TypeBieres.Where(p=>p.typeBiereId==TypeBiereId).FirstOrDefault().typeBiereNom;
            }
        }

        public RelayCommand Activer
        {
            get
            {
                if (_activer == null)
                {
                    _activer = new RelayCommand(FaireAct, CanFareAct);
                }
                return _activer;
            }
        }

        private bool CanFareAct()
        {
            bool test;
            if (Id!=0 && IsDispo == false )
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireAct()
        {
            Main.Data.ActiverBiere(Id);
            IsDispo = true;
        }

        public RelayCommand Desactiver
        {
            get
            {
                if (_desactiver == null)
                {
                    _desactiver = new RelayCommand(FaireDesac, CanFaireDesac);
                }
                return _desactiver;
            }
        }

        private bool CanFaireDesac()
        {
            bool test;
            if (Id!=0 && IsDispo == true)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireDesac()
        {
            Main.Data.DesactiverBiere(Id);
            IsDispo = false;
        }
        public override bool IsDispo
        {
            get
            {
                return base.IsDispo;
            }

            set
            {
                base.IsDispo = value;
                Activer.RaiseCanExecuteChanged();
                Desactiver.RaiseCanExecuteChanged();
            }
        }
        public override string Image
        {
            get
            {
                return @"Images\" + base.Image;

            }

            set
            {
                base.Image = value;
            }
        }
        public string TypeBiereNom
        {
            get
            {
                return _typeBiereNom;
            }

            set
            {
                _typeBiereNom = value;
                RaisePropertyChanged();
            }
        }
        public DetailBiereVM(MainVM vm):base(vm)
        {

        }
    }
}

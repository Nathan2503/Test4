using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Biere
{
    class Biere : BindableBase
    {
        private int _id;
        private string _nom;
        private decimal _pa;
        private string _image;
        private string _description;
        private string _robe;
        private bool _isDispo;
        private decimal _prix;
        private int _typeBiereId;
        private MainVM _main;
        private RelayCommandG<int> _select;
        private RelayCommand _deselect;
        public RelayCommand Deselect
        {
            get
            {
                if (_deselect == null)
                {
                    _deselect = new RelayCommand(FaireDeselect, CanFaireDeselect);
                }
                return _deselect;
            }
        }

        private bool CanFaireDeselect()
        {
            bool test;
            if (TypeBiereId != 0)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireDeselect()
        {
            TypeBiereId = 0;
        }

        public RelayCommandG<int> SelectT
        {
            get
            {
                if (_select == null)
                {
                    _select = new RelayCommandG<int>(FaireSelect, CanFaireSelect);
                }
                return _select;
            }
        }

        private bool CanFaireSelect()
        {
            bool test;
            if (TypeBiereId == 0)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireSelect(int obj)
        {
            TypeBiereId = obj;
        }

        public virtual int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public  virtual string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
                RaisePropertyChanged();
            }
        }

        public virtual decimal Pa
        {
            get
            {
                return _pa;
            }

            set
            {
                _pa = value;
                RaisePropertyChanged();
            }
        }

        public virtual string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                RaisePropertyChanged();
            }
        }

        public virtual string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }

        public virtual string Robe
        {
            get
            {
                return _robe;
            }

            set
            {
                _robe = value;
                RaisePropertyChanged();
            }
        }

        public virtual bool IsDispo
        {
            get
            {
                return _isDispo;
            }

            set
            {
                _isDispo = value;
                RaisePropertyChanged();
            }
        }

        public virtual decimal Prix
        {
            get
            {
                return _prix;
            }

            set
            {
                _prix = value;
                RaisePropertyChanged();
            }
        }

        public virtual int TypeBiereId
        {
            get
            {
                return _typeBiereId;
            }

            set
            {
                _typeBiereId = value;
                RaisePropertyChanged();
                //SelectT.RaiseCanExecuteChanged();
                //Deselect.RaiseCanExecuteChanged();
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
        public Biere(MainVM vm)
        {
            Main = vm;
        }
        public Biere()
        {

        }
    }
}

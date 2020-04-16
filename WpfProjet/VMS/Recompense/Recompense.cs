using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Recompense
{
    class Recompense :BindableBase
    {
        private int _id;
        private string _nom;
        private int _biereId;
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
            if (BiereId != 0)
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
            BiereId = 0;
        }

        public RelayCommandG<int> Select
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
            if (BiereId == 0)
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
            BiereId = obj;
        }
        public Recompense(MainVM vm)
        {
            Main = vm;
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

        public virtual string Nom
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

        public virtual int BiereId
        {
            get
            {
                return _biereId;
            }

            set
            {
                _biereId = value;
                RaisePropertyChanged();
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
    }
}

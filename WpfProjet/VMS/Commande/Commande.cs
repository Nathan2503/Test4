using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;

namespace WpfProjet.VMS.Commande
{
    class Commande : BindableBase
    {
        private int _id;
        private int _quantite;
        private int _clientId;
        private int _biereId;
        private MainVM _main;
        private RelayCommandG<int> _selectBiere;
        private RelayCommand _deselectBiere;
        private RelayCommandG<int> _selectClient;
        private RelayCommand _deselectClient;
        public RelayCommand DeselectClient
        {
            get
            {
                if (_deselectClient == null)
                {
                    _deselectClient = new RelayCommand(FaireDC, CanFaireDC);
                }
                return _deselectClient;
            }
        }

        private bool CanFaireDC()
        {
            bool test;
            if (ClientId != 0)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireDC()
        {
            ClientId = 0;
        }

        public RelayCommandG<int> SelectClient
        {
            get
            {
                if (_selectClient == null)
                {
                    _selectClient = new RelayCommandG<int>(FaireSC, CanFaireSC);
                }
                return _selectClient;
            }
        }

        private bool CanFaireSC()
        {
            bool test;
            if (ClientId == 0)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireSC(int obj)
        {
            ClientId = obj;
        }

        public RelayCommand DeselectBiere
        {
            get
            {
                if (_deselectBiere == null)
                {
                    _deselectBiere = new RelayCommand(FaireDB, CanFaireDB);
                }
                return _deselectBiere;
            }
        }

        private bool CanFaireDB()
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

        private void FaireDB()
        {
            BiereId = 0;
        }

        public RelayCommandG<int> SelectBiere
        {
            get
            {
                if (_selectBiere == null)
                {
                    _selectBiere = new RelayCommandG<int>(FaireSelectBiere, CanFaireSelectBiere);
                }
                return _selectBiere;
            }
        }

        private bool CanFaireSelectBiere()
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

        private void FaireSelectBiere(int obj)
        {
            BiereId = obj;
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

        public virtual int Quantite
        {
            get
            {
                return _quantite;
            }

            set
            {
                _quantite = value;
                RaisePropertyChanged();
            }
        }

        public virtual int ClientId
        {
            get
            {
                return _clientId;
            }

            set
            {
                _clientId = value;
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
            }
        }
        public Commande(MainVM vm)
        {
            Main = vm;
        }
        public Commande()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Commande
{
    class DetailCommandeVM : Commande
    {
        private string _biereNom;
        private string _login;
        private DateTime _date;
        private RelayCommandG<int> _getDetail;
        private RelayCommandG<int> _delete;
        public RelayCommandG<int> Delete
        {
            get
            {
                if (_delete == null)
                {
                    _delete = new RelayCommandG<int>(FaireDelete);
                }
                return _delete;
            }
        }
        private void FaireDelete(int obj)
        {
            Main.Data.DeleteCommande(obj);
            if (Id == obj)
            {
                Date = new DateTime();
                Id = 0;
                Quantite = 0;
                BiereNom = null;
                Login = null;
            }
        }

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

        public string BiereNom
        {
            get
            {
                return _biereNom;
            }

            set
            {
                _biereNom = value;
                RaisePropertyChanged();
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
                RaisePropertyChanged();
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
                RaisePropertyChanged();
            }
        }


        private void FaireGetDetail(int obj)
        {
            
            CommandeWPF wpf = Main.Data.Commandes.Where(p=>p.commandeId==obj).FirstOrDefault();
            if (wpf.biereId != null)
            {
                BiereNom = Main.Data.Bieres.Where(b=>b.biereId==wpf.biereId).FirstOrDefault().biereNom;
            }
            Quantite = wpf.commandeQuantite;
            Id = wpf.commandeId;
            Date = wpf.commandeDate;
            if (wpf.clientId != null)
            {
                Login = Main.Data.Clients.Where(c=>c.clientId==wpf.clientId).FirstOrDefault().clientLogin;
            }

        }
        public DetailCommandeVM (MainVM vm): base(vm)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Client
{
    class DetailClientVM :Client
    {
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
            Main.Data.DeleteClient(obj);
            if (Id == obj)
            {
                Login = null;
                Nom = null;
                Prenom = null;
                DateNaissance = new DateTime();
                Id = 0;
            }
        }

        public RelayCommandG<int> GetDetail
        {
            get
            {
                if (_getDetail == null)
                {
                    _getDetail = new RelayCommandG<int>(FaireDetail);
                }
                return _getDetail;
            }
        }

        private void FaireDetail(int obj)
        {
            ClientWPF wpf = Main.Data.Clients.Where(p => p.clientId == obj).FirstOrDefault(); ;
            DateNaissance = wpf.clientDateNaissance.Date;
            Login = wpf.clientLogin;
            Nom = wpf.clientNom;
            Prenom = wpf.clientPrenom;
            Id = wpf.clientId;
        }
        public DetailClientVM(MainVM vm): base(vm)
        {

        }
    }
}

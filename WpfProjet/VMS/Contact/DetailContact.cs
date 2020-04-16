using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;

namespace WpfProjet.VMS.Contact
{
    class DetailContact : Contact
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
            Main.Data.DeleteContact(obj);
            if (Id == obj)
            {
                Tel = null;
                AdVille = null;
                AdRue = null;
                AdNumero = null;
                AdCodePostal = null;
                Id = 0;
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

        private void FaireGetDetail(int obj)
        {

            ContactWPF wpf = Main.Data.Contacts.Where(p => p.contactId == obj).FirstOrDefault();
            AdCodePostal = wpf.adCodePostal;
            AdNumero = wpf.adNumero;
            AdRue = wpf.adRue;
            AdVille = wpf.adVille;
            Tel = wpf.telephone;
            Id = wpf.contactId;
        }
        public DetailContact(MainVM vm): base(vm)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;

namespace WpfProjet.VMS.Message
{
    class DetailMessage : Message
    {
        private RelayCommandG<int> _getDetail;
        private RelayCommandG<int> _delete;
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
            MessageWPF wpf = Main.Data.Messages.Where(p => p.messageAlertId == obj).FirstOrDefault();
            Contenu = wpf.messageContenu;
            DatDebut = wpf.messageDateDebut;
            DateFin = wpf.messageDateFin;
            Id = wpf.messageAlertId;
        }
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
            Main.Data.DelelteMessage(obj);
            if (Id == obj)
            {
                DatDebut = new DateTime();
                DateFin = new DateTime();
                Contenu = null;
                Id = 0;
            }
        }
        public DetailMessage(MainVM vm):base(vm)
        {

        }
    }
}

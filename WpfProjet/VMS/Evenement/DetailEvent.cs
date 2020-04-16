using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;

namespace WpfProjet.VMS.Evenement
{
    class DetailEvent : Evenement
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
            Main.Data.DeleteEvent(obj);
            if (Id == obj)
            {
                DateDebut = new DateTime();
                DateFin = new DateTime();
                Desc = null;
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
            EvenementWPF wpf = Main.Data.Evenements.Where(p => p.eventId == obj).FirstOrDefault(); ;
            DateDebut = wpf.eventDateDebut;
            DateFin = wpf.eventDateFin;
            Desc = wpf.eventDescription;
            Id = wpf.eventId;
        }
        public DetailEvent(MainVM vm):base(vm)
        {

        }
    }
}

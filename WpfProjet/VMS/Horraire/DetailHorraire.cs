using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;

namespace WpfProjet.VMS.Horraire
{
    class DetailHorraire : Horraire
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
            Main.Data.DeleteHorraire(obj);
            if (Id == obj)
            {
                DateDebut = new DateTime();
                DateFin = new DateTime();
                HeureFermeture = 0;
                HeureOuverture = 0;
                MinOuverture = 0;
                MinFermeture = 0;
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
            HorraireWPF wpf = Main.Data.Horraires.Where(p => p.horraireId == obj).FirstOrDefault();
            DateFin = wpf.horraireDateFin;
            DateDebut = wpf.horraireDateDebut;
            HeureFermeture = GetHeure(wpf.heureFermeture);
            MinFermeture = GetMin(wpf.heureFermeture);
            HeureOuverture = GetHeure(wpf.heureOuverture);
            MinOuverture = GetMin(wpf.heureOuverture);
            Id = wpf.horraireId;
        }

        public DetailHorraire(MainVM vm) : base(vm)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;

namespace WpfProjet.VMS.Emploi
{
    class DetailEmploi:Emploi
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
            Main.Data.DeleteEmploi(obj);
            if (obj == Id)
            {
                Id = 0;
                Desc = null;
                Fonction = null;
                DiplomeMin = null;
                ExpMin = null;
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

            EmploiWPF wpf = Main.Data.Emplois.Where(p => p.offreEmploiId == obj).FirstOrDefault();
            DiplomeMin = wpf.diplomeMin;
            ExpMin = wpf.experienceMin;
            Desc = wpf.jobDescription;
            Fonction = wpf.fonction;
            Id = wpf.offreEmploiId;
        }

        public DetailEmploi(MainVM vm): base(vm)
        {

        }
    }
}

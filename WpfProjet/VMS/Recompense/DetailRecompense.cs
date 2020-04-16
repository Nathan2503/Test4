using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;

namespace WpfProjet.VMS.Recompense
{
    class DetailRecompense : Recompense
    {
        private RelayCommandG<int> _getDetail;
        private RelayCommandG<int> _delete;
        private string _biereNom;
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
            Main.Data.DeleteRecompense(obj);
            if (Id == obj)
            {
                Nom = null;
                BiereId = 0;
                BiereNom = null;
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

        private void FaireGetDetail(int obj)
        {
            RecompenseWPF wpf = Main.Data.Recompenses.Where(p => p.recompenseId == obj).FirstOrDefault();
            Nom = wpf.recompenseNom;
            Id = wpf.recompenseId;
            if (wpf.biereId != null)
            {
                BiereId =(int) wpf.biereId;
                BiereNom = Main.Data.Bieres.Where(p => p.biereId == wpf.biereId).FirstOrDefault().biereNom;
            }
            else
            {
                BiereNom = null;
            }

        }
        public DetailRecompense(MainVM vm) : base(vm)
        {

        }
    }
}

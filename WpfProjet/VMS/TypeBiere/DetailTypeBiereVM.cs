using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.TypeBiere
{
    class DetailTypeBiereVM : TypeBiere
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
            Main.Data.DeleteTypeBiere(obj);
            if (Id == obj)
            {
                Id = 0;
                Def = null;
                Nom = null;
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
            TypeBiereWPF wpf = Main.Data.TypeBieres.Where(p => p.typeBiereId == obj).FirstOrDefault(); ;
            Id = wpf.typeBiereId;
            Nom = wpf.typeBiereNom;
            Def = wpf.typeBiereDefinition;
        }
        public DetailTypeBiereVM(MainVM vm):base(vm)
        {

        }
       
            
    }
}

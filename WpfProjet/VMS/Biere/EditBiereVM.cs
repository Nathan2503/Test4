using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Biere
{
    class EditBiereVM : Biere
    {
        private string _path;
        private RelayCommandG<int> _getEdit;
        private RelayCommand _edit;
        private RelayCommand _remplacerImage;
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
            string test;
            test = Main.Data.DalBiere.GetOne(obj).biereImage;
            string path = @"C:\Users\Quentin.PC-BUCHE\Downloads\ProjetNet\ApplicationASP\AspProjetSol\AspProjet\Images\" + test;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Main.Data.DeleteBiere(obj);
            if (Id == obj)
            {
                Description = null;
                Image = null;
                Prix = 0;
                Pa = 0;
                Robe = null;
                TypeBiereId = 0;
                Nom = null;
                _path = null;
                Id = 0;
            }
        }

        public RelayCommand RemplacerImage
        {
            get
            {
                if (_remplacerImage == null)
                {
                    _remplacerImage = new RelayCommand(FaireRI);
                }
                return _remplacerImage;
            }
        }

        private void FaireRI()
        {
            //if (File.Exists(PathImage))
            //{
            //    File.Delete(PathImage);
            //}
            OpenFileDialog test = new OpenFileDialog();
            test.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (test.ShowDialog() == true)
            {
                //Image = Guid.NewGuid().ToString() + ".PNG";
                //string path3 = test.FileName;
                _path = test.FileName;
                //File.Copy(path3, @"C:\Users\Quentin.PC-BUCHE\Downloads\ProjetNet\ApplicationASP\AspProjetSol\AspProjet\Images\" + Image);
            }
        }
        public RelayCommand Edit
        {
            get
            {
                if (_edit == null)
                {
                    _edit = new RelayCommand(FaireEdit, CanFaireEdit);
                }
                return _edit;
            }
        }

        private bool CanFaireEdit()
        {
            bool test;
            if (Id != 0 && Nom!=null &&  Nom.Length>2 &&  Description!=null && Robe!=null &&  Description.Length>2 && Robe.Length>2 && TypeBiereId!=0 && Prix>1 && Pa>1)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireEdit()
        {
            if (_path != null)
            {
                if (File.Exists(PathImage))
                {
                    File.Delete(PathImage);
                }
                Image = Guid.NewGuid().ToString() + ".PNG";
                File.Copy(_path, @"C:\Users\Quentin.PC-BUCHE\Downloads\ProjetNet\ApplicationASP\AspProjetSol\AspProjet\Images\" + Image);
            }
            Main.Data.EditerBiere(this.GetBiereWPF());
            Description = null;
            Image = null;
            Prix = 0;
            Pa = 0;
            Robe = null;
            TypeBiereId = 0;
            Nom = null;
            _path = null;
            Id = 0;
        }

        public RelayCommandG<int> GetEdit
        {
            get
            {
                if (_getEdit == null)
                {
                    _getEdit = new RelayCommandG<int>(FaireGetEdit);
                }
                return _getEdit;
            }
        }

        private void FaireGetEdit(int obj)
        {
            BiereWPF wpf = Main.Data.DalBiere.GetOne(obj).GetBiereWPF();
           
            Description = wpf.biereDescription;
            Nom = wpf.biereNom;
            Robe = wpf.biereRobe;
            Image = wpf.biereImage;
            Pa = wpf.pourcentageAlcool;
            Prix = wpf.bierePrix;
            Id = wpf.biereId;
            if (wpf.typeBiereId != null)
            {
                TypeBiereId =(int)wpf.typeBiereId;
            }
            //IsDispo = wpf.biereIsDispo;
        }
        public override int Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override string Description
        {
            get
            {
                return base.Description;
            }

            set
            {
                base.Description = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override string Image
        {
            get
            {
                return base.Image;
            }

            set
            {
                base.Image = value;
            }
        }
        public string PathImage
        {
            get
            {
                return @"C:\Users\Quentin.PC-BUCHE\Downloads\ProjetNet\ApplicationASP\AspProjetSol\AspProjet\Images\" + Image;
            }
        }
        public override string Nom
        {
            get
            {
                return base.Nom;
            }

            set
            {
                base.Nom = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override decimal Pa
        {
            get
            {
                return base.Pa;
            }

            set
            {
                base.Pa = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override decimal Prix
        {
            get
            {
                return base.Prix;
            }

            set
            {
                base.Prix = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override string Robe
        {
            get
            {
                return base.Robe;
            }

            set
            {
                base.Robe = value;
                Edit.RaiseCanExecuteChanged();
            }
        }
        public override int TypeBiereId
        {
            get
            {
                return base.TypeBiereId;
            }

            set
            {
                base.TypeBiereId = value;
                Edit.RaiseCanExecuteChanged();
                SelectT.RaiseCanExecuteChanged();
                Deselect.RaiseCanExecuteChanged();
            }
        }
        public EditBiereVM(MainVM vm): base(vm)
        {

        }
    }
}

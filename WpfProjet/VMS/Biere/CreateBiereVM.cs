using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Tools;

namespace WpfProjet.VMS.Biere
{
    class CreateBiereVM : Biere
    {
        private string _path;
        private RelayCommand _deposerImage;
        private RelayCommand _create;
        public RelayCommand Create
        {
            get
            {
                if (_create == null)
                {
                    _create = new RelayCommand(FaireCreate, CanFaireCreate);
                }
                return _create;
            }
        }

        private bool CanFaireCreate()
        {
            bool test;
            if (Description != null && Image != null && Nom != null && Prix != 0 && Robe != null && Pa != 0 && TypeBiereId != 0)
            {
                if(Description.Length>2 && Nom.Length>2 && Prix>1 && Robe.Length>2 && Pa > 1)
                {
                    test = true;
                }
                else
                {
                    test = false;
                }
            }
            else
            {
                test = false;
            }
            return test;
        }

        private void FaireCreate()
        {
            if (_path != null)
            {
               // Image = Guid.NewGuid().ToString() + ".PNG";
                File.Copy(_path, @"\Images\" + Image);
            }
            Main.Data.AjouterBiere(this.GetBiereWPF());
            Description = null;
            Image = null;
            Prix = 0;
            Pa = 0;
            Robe = null;
            TypeBiereId = 0;
            Nom = null;
            _path = null;
        }

        public RelayCommand DeposerImage
        {
            get
            {
                if (_deposerImage == null)
                {
                    _deposerImage = new RelayCommand(FaireDepotImage);
                }
                return _deposerImage;
            }

        }

        private void FaireDepotImage()
        {
            
            OpenFileDialog test = new OpenFileDialog();
            test.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (test.ShowDialog() == true)
            {
                Image = Guid.NewGuid().ToString() + ".PNG";
                //string path3 = test.FileName;
                _path = test.FileName;
              
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
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
                Create.RaiseCanExecuteChanged();
                SelectT.RaiseCanExecuteChanged();
                Deselect.RaiseCanExecuteChanged();
            }
        }
        public CreateBiereVM(MainVM vm): base(vm)
        {

        }
    }
}

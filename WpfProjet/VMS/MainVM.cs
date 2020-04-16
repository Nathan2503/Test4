using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Context;
using WpfProjet.VMS.Biere;
using WpfProjet.VMS.Brasserie;
using WpfProjet.VMS.Client;
using WpfProjet.VMS.Commande;
using WpfProjet.VMS.Contact;
using WpfProjet.VMS.Emploi;
using WpfProjet.VMS.Evenement;
using WpfProjet.VMS.Horraire;
using WpfProjet.VMS.Message;
using WpfProjet.VMS.Recompense;
using WpfProjet.VMS.TypeBiere;

namespace WpfProjet.VMS
{
    class MainVM : BindableBase
    {
        private ContextData _data;
        private CreateTypeBiereVM _createTB;
        private EditTypeBiereVM _editTB;
        private DetailTypeBiereVM _detailTB;
        private CreateBiereVM _createBiere;
        private EditBiereVM _editBiere;
        private DetailBiereVM _detailBiere;
        private EditBrasserieVM _editBrasserie;
        private CreateClientVM _createClient;
        private DetailClientVM _detailClient;
        private CreateCommandeVM _createCom;
        private EditCommandeVM _editCom;
        private DetailCommandeVM _detailCom;
        private CreateContact _createContact;
        private EditContact _editContact;
        private DetailContact _detailContact;
        private CreateEmploi _createEmploi;
        private EditEmploi _editEmploi;
        private DetailEmploi _detailEmploi;
        private CreateEvent _createEven;
        private EditEvent _editEvent;
        private DetailEvent _detailEvent;
        private CreateHorraire _createHorraire;
        private EditHorraire _editHorraire;
        private DetailHorraire _detailHorraire;
        private CreateMessage _createMessage;
        private EditMessage _editMessage;
        private DetailMessage _detailMessage;
        private CreateRecompense _createRecomp;
        private EditRecompense _editRecomp;
        private DetailRecompense _detailRecomp;

        public ContextData Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
                RaisePropertyChanged();
            }
        }

        public  CreateTypeBiereVM CreateTB
        {
            get
            {
                return _createTB;
            }

            set
            {
                _createTB = value;
                RaisePropertyChanged();
            }
        }

        public EditTypeBiereVM EditTB
        {
            get
            {
                return _editTB;
            }

            set
            {
                _editTB = value;
                RaisePropertyChanged();
            }
        }

        public DetailTypeBiereVM DetailTB
        {
            get
            {
                return _detailTB;
            }

            set
            {
                _detailTB = value;
                RaisePropertyChanged();
            }
        }

        public CreateBiereVM CreateBiere
        {
            get
            {
                return _createBiere;
            }

            set
            {
                _createBiere = value;
                RaisePropertyChanged();
            }
        }

        public EditBiereVM EditBiere
        {
            get
            {
                return _editBiere;
            }

            set
            {
                _editBiere = value;
                RaisePropertyChanged();
            }
        }

        public DetailBiereVM DetailBiere
        {
            get
            {
                return _detailBiere;
            }

            set
            {
                _detailBiere = value;
                RaisePropertyChanged();
            }
        }

        public EditBrasserieVM EditBrasserie
        {
            get
            {
                return _editBrasserie;
            }

            set
            {
                _editBrasserie = value;
                RaisePropertyChanged();
            }
        }

        public CreateClientVM CreateClient
        {
            get
            {
                return _createClient;
            }

            set
            {
                _createClient = value;
                RaisePropertyChanged();
            }
        }

        public DetailClientVM DetailClient
        {
            get
            {
                return _detailClient;
            }

            set
            {
                _detailClient = value;
                RaisePropertyChanged();
            }
        }

        public CreateCommandeVM CreateCom
        {
            get
            {
                return _createCom;
            }

            set
            {
                _createCom = value;
                RaisePropertyChanged();
            }
        }

        public EditCommandeVM EditCom
        {
            get
            {
                return _editCom;
            }

            set
            {
                _editCom = value;
                RaisePropertyChanged();
            }
        }

        public DetailCommandeVM DetailCom
        {
            get
            {
                return _detailCom;
            }

            set
            {
                _detailCom = value;
            }
        }

        public CreateContact CreateContact
        {
            get
            {
                return _createContact;
            }

            set
            {
                _createContact = value;
                RaisePropertyChanged();
            }
        }

        public EditContact EditContact
        {
            get
            {
                return _editContact;
            }

            set
            {
                _editContact = value;
                RaisePropertyChanged();
            }
        }

        public DetailContact DetailContact
        {
            get
            {
                return _detailContact;
            }

            set
            {
                _detailContact = value;
                RaisePropertyChanged();
            }
        }

        public CreateEmploi CreateEmploi
        {
            get
            {
                return _createEmploi;
            }

            set
            {
                _createEmploi = value;
                RaisePropertyChanged();
            }
        }

        public  EditEmploi EditEmploi
        {
            get
            {
                return _editEmploi;
            }

            set
            {
                _editEmploi = value;
                RaisePropertyChanged();
            }
        }

        public DetailEmploi DetailEmploi
        {
            get
            {
                return _detailEmploi;
            }

            set
            {
                _detailEmploi = value;
                RaisePropertyChanged();
            }
        }

        public CreateEvent CreateEven
        {
            get
            {
                return _createEven;
            }

            set
            {
                _createEven = value;
                RaisePropertyChanged();
            }
        }

        public EditEvent EditEvent
        {
            get
            {
                return _editEvent;
            }

            set
            {
                _editEvent = value;
                RaisePropertyChanged();
            }
        }

        public DetailEvent DetailEvent
        {
            get
            {
                return _detailEvent;
            }

            set
            {
                _detailEvent = value;
                RaisePropertyChanged();
            }
        }

        public CreateHorraire CreateHorraire
        {
            get
            {
                return _createHorraire;
            }

            set
            {
                _createHorraire = value;
                RaisePropertyChanged();
            }
        }

        public EditHorraire EditHorraire
        {
            get
            {
                return _editHorraire;
            }

            set
            {
                _editHorraire = value;
                RaisePropertyChanged();
            }
        }

        public DetailHorraire DetailHorraire
        {
            get
            {
                return _detailHorraire;
            }

            set
            {
                _detailHorraire = value;
                RaisePropertyChanged();
            }
        }

        public CreateMessage CreateMessage
        {
            get
            {
                return _createMessage;
            }

            set
            {
                _createMessage = value;
                RaisePropertyChanged();
            }
        }

        public EditMessage EditMessage
        {
            get
            {
                return _editMessage;
            }

            set
            {
                _editMessage = value;
                RaisePropertyChanged();
            }
        }

        public DetailMessage DetailMessage
        {
            get
            {
                return _detailMessage;
            }

            set
            {
                _detailMessage = value;
                RaisePropertyChanged();
            }
        }

        public  CreateRecompense CreateRecomp
        {
            get
            {
                return _createRecomp;
            }

            set
            {
                _createRecomp = value;
                RaisePropertyChanged();
            }
        }

        public EditRecompense EditRecomp
        {
            get
            {
                return _editRecomp;
            }

            set
            {
                _editRecomp = value;
                RaisePropertyChanged();
            }
        }

        public DetailRecompense DetailRecomp
        {
            get
            {
                return _detailRecomp;
            }

            set
            {
                _detailRecomp = value;
                RaisePropertyChanged();
            }
        }

        public MainVM()
        {
            Data = new ContextData();
            CreateTB = new CreateTypeBiereVM(this);
            EditTB = new EditTypeBiereVM(this);
            DetailTB = new DetailTypeBiereVM(this);
            CreateBiere = new CreateBiereVM(this);
            EditBiere = new EditBiereVM(this);
            DetailBiere = new DetailBiereVM(this);
            EditBrasserie = new EditBrasserieVM(this);
            CreateClient = new CreateClientVM(this);
            DetailClient = new DetailClientVM(this);
            CreateCom = new CreateCommandeVM(this);
            EditCom = new EditCommandeVM(this);
            DetailCom = new DetailCommandeVM(this);
            CreateContact = new CreateContact(this);
            EditContact = new EditContact(this);
            DetailContact = new DetailContact(this);
            CreateEmploi = new CreateEmploi(this);
            EditEmploi = new EditEmploi(this);
            DetailEmploi = new DetailEmploi(this);
            CreateEven = new CreateEvent(this);
            EditEvent = new EditEvent(this);
            DetailEvent = new DetailEvent(this);
            CreateHorraire = new CreateHorraire(this);
            EditHorraire = new EditHorraire(this);
            DetailHorraire = new DetailHorraire(this);
            CreateMessage = new CreateMessage(this);
            EditMessage = new EditMessage(this);
            DetailMessage = new DetailMessage(this);
            CreateRecomp = new CreateRecompense(this);
            EditRecomp = new EditRecompense(this);
            DetailRecomp = new DetailRecompense(this);
        }
    }
}

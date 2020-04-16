using DalWpfProjet.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary;
using WpfProjet.Models;
using WpfProjet.Tools;
using WpfProjet.VMS.Biere;
using WpfProjet.VMS.TypeBiere;

namespace WpfProjet.Context
{
    class ContextData : BindableBase
    {
        private ObservableCollection<TypeBiereWPF> _typeBieres = new ObservableCollection<TypeBiereWPF>();
        private ObservableCollection<BiereWPF> _bieres = new ObservableCollection<BiereWPF>();
        private ObservableCollection<ClientWPF> _clients = new ObservableCollection<ClientWPF>();
        private ObservableCollection<CommandeWPF> _commandes = new ObservableCollection<CommandeWPF>();
        private ObservableCollection<ContactWPF> _contacts = new ObservableCollection<ContactWPF>();
        private ObservableCollection<EmploiWPF> _emplois = new ObservableCollection<EmploiWPF>();
        private ObservableCollection<EvenementWPF> _evenements = new ObservableCollection<EvenementWPF>();
        private ObservableCollection<HorraireWPF> _horraires = new ObservableCollection<HorraireWPF>();
        private ObservableCollection<MessageWPF> _messages = new ObservableCollection<MessageWPF>();
        private ObservableCollection<RecompenseWPF> _recompenses = new ObservableCollection<RecompenseWPF>();
        private TypeBiereDalService _dal;
        private BiereDalService _dalBiere;
        private BrasserieDalService _dalBrasserie;
        private ClientDalService _dalClient;
        private CommandeDalService _dalCom;
        private ContactDalService _dalContact;
        private EmploiDalService _dalEmploi;
        private EvenementDalService _dalEvent;
        private HorraireDalService _dalHorraire;
        private MessageDalService _dalMessage;
        private RecompenseDalService _dalRecomp;
        public RecompenseDalService DalRecomp
        {
            get
            {
                if (_dalRecomp == null)
                {
                    _dalRecomp = RecompenseDalService.GetLoadBalancer();
                }
                return _dalRecomp;
            }
        }
        public MessageDalService DalMessage
        {
            get
            {
                if (_dalMessage == null)
                {
                    _dalMessage =  MessageDalService.GetLoadBalancer();
                }
                return _dalMessage;
            }
        }
        public HorraireDalService DalHorraire
        {
            get
            {
                if (_dalHorraire == null)
                {
                    _dalHorraire =  HorraireDalService.GetLoadBalancer();
                }
                return _dalHorraire;
            }
        }
        public EvenementDalService DalEvent
        {
            get
            {
                if (_dalEvent == null)
                {
                    _dalEvent =  EvenementDalService.GetLoadBalancer();
                }
                return _dalEvent;
            }
        }
        public EmploiDalService DalEmploi
        {
            get
            {
                if (_dalEmploi == null)
                {
                    _dalEmploi =  EmploiDalService.GetLoadBalancer();
                }
                return _dalEmploi;
            }
        }
        public ContactDalService DalContact
        {
            get
            {
                if (_dalContact == null)
                {
                    _dalContact =  ContactDalService.GetLoadBalancer();
                }
                return _dalContact;
            }
        }
        public CommandeDalService DalCom
        {
            get
            {
                if (_dalCom == null)
                {
                    _dalCom =  CommandeDalService.GetLoadBalancer();
                }
                return _dalCom;
            }
        }
        public ClientDalService DalClient
        {
            get
            {
                if (_dalClient == null)
                {
                    _dalClient = ClientDalService.GetLoadBalancer();
                }
                return _dalClient;
            }
        }
        public BrasserieDalService DalBrasserie
        {
            get
            {
                if (_dalBrasserie == null)
                {
                    _dalBrasserie =  BrasserieDalService.GetLoadBalancer();
                }
                return _dalBrasserie;
            }
        }
        public BiereDalService DalBiere
        {
            get
            {
                if (_dalBiere == null)
                {
                    _dalBiere =  BiereDalService.GetLoadBalancer();
                }
                return _dalBiere;
            }
        }
        public TypeBiereDalService Dal
        {
            get
            {
                if (_dal == null)
                {
                    _dal = TypeBiereDalService.GetLoadBalancer();
                }
                return _dal;
            }
        }

        public ObservableCollection<TypeBiereWPF> TypeBieres
        {
            get
            {
                return _typeBieres;
            }

            set
            {
                _typeBieres = value;
                RaisePropertyChanged();
                
            }
        }

        public ObservableCollection<BiereWPF> Bieres
        {
            get
            {
                return _bieres;
            }

            set
            {
                _bieres = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ClientWPF> Clients
        {
            get
            {
                return _clients;
            }

            set
            {
                _clients = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<CommandeWPF> Commandes
        {
            get
            {
                return _commandes;
            }

            set
            {
                _commandes = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ContactWPF> Contacts
        {
            get
            {
                return _contacts;
            }

            set
            {
                _contacts = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<EmploiWPF> Emplois
        {
            get
            {
                return _emplois;
            }

            set
            {
                _emplois = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<EvenementWPF> Evenements
        {
            get
            {
                return _evenements;
            }

            set
            {
                _evenements = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<HorraireWPF> Horraires
        {
            get
            {
                return _horraires;
            }

            set
            {
                _horraires = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<MessageWPF> Messages
        {
            get
            {
                return _messages;
            }

            set
            {
                _messages = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RecompenseWPF> Recompenses
        {
            get
            {
                return _recompenses;
            }

            set
            {
                _recompenses = value;
                RaisePropertyChanged();
            }
        }

        public void AjouterTypeBiere(TypeBiereWPF a)
        {
            //TypeBieres.Add(a);
           int n2= Dal.Create(a.GetTypeBiereDal());
           // int n;
            //n=Dal.GetAll().LastOrDefault().typeBiereId;
            a.typeBiereId = n2;
            TypeBieres.Add(a);

        }
        public void AjouterBiere(BiereWPF a)
        {
            a.biereId=DalBiere.Create(a.GetBiereDal());
            //a.biereId = DalBiere.GetAll().LastOrDefault().biereId;
            Bieres.Add(a);
        }
        public void AjouterClient(ClientWPF a)
        {
           a.clientId= DalClient.Create(a.GetClientDal());
            //a.clientId = DalClient.GetAll().LastOrDefault().clientId;
            Clients.Add(a);
        }
        public void AjouterCommande(CommandeWPF a)
        {
           a.commandeId= DalCom.Create(a.GetCommandeDal());
           // a.commandeId = DalCom.GetAll().LastOrDefault().commandeId;
            Commandes.Add(a);
        }
        public void AjouterContact(ContactWPF a)
        {
            a.contactId=DalContact.Create(a.GetContactDal());
            //a.contactId = DalContact.GetAll().LastOrDefault().contactId;
            Contacts.Add(a);
        }
        public void AjouterEmploi(EmploiWPF a)
        {
            a.offreEmploiId=DalEmploi.Create(a.GetEmploiDal());
           // a.offreEmploiId = DalEmploi.GetAll().LastOrDefault().offreEmploiId;
            Emplois.Add(a);
        }
        public void AjouterEvent(EvenementWPF a)
        {
            a.eventId=DalEvent.Create(a.GetEvenementDal());
            //a.eventId = DalEvent.GetAll().LastOrDefault().eventId;
            Evenements.Add(a);
        }
        public void AjouterHorraire(HorraireWPF a)
        {
            a.horraireId=DalHorraire.Create(a.GetHorraireDal());
           // a.horraireId = DalHorraire.GetAll().LastOrDefault().horraireId;
            Horraires.Add(a);
        }
        public void AjouterMessage(MessageWPF a)
        {
            a.messageAlertId=DalMessage.Create(a.GetMessageDal());
           // a.messageAlertId = DalMessage.GetAll().LastOrDefault().messageAlertId;
            Messages.Add(a);
        }
        public void AjouterRecompense(RecompenseWPF a)
        {
            a.recompenseId=DalRecomp.Create(a.GetRecompenseDal());
           // a.recompenseId = DalRecomp.GetAll().LastOrDefault().recompenseId;
            Recompenses.Add(a);
        }
        public void EditerTypebiere(TypeBiereWPF b)
        {
            //int i=TypeBieres.IndexOf(b);
            //TypeBieres[i] = b;
            if (TypeBieres.Count > 0)
            {
                for (int i = 0; i < TypeBieres.Count(); i++)
                {

                   if( TypeBieres[i].typeBiereId == b.typeBiereId)
                    {
                        TypeBieres[i] = b;
                        i = TypeBieres.Count() + 2;
                    }
                }
            }
            Dal.Update(b.GetTypeBiereDal());
        }
        public void EditerBiere(BiereWPF b)
        {
            if (Bieres.Count() > 0)
            {
                for (int i = 0; i < Bieres.Count(); i++)
                {
                    if (Bieres[i].biereId == b.biereId)
                    {
                        BiereWPF wpf = new BiereWPF();
                        wpf.typeBiereId = b.typeBiereId;
                        wpf.pourcentageAlcool = b.pourcentageAlcool;
                        wpf.biereRobe = b.biereRobe;
                        wpf.bierePrix = b.bierePrix;
                        wpf.biereNom = b.biereNom;
                        wpf.biereImage = b.biereImage;
                        wpf.biereDescription = b.biereDescription;
                        wpf.biereId = b.biereId;
                        wpf.biereIsDispo = Bieres[i].biereIsDispo;
                        //Bieres[i].biereDescription = b.biereDescription;
                        //Bieres[i].biereImage = b.biereImage;
                        //Bieres[i].biereNom = b.biereNom;
                        //Bieres[i].bierePrix = b.bierePrix;
                        //Bieres[i].biereRobe = b.biereRobe;
                        //Bieres[i].pourcentageAlcool = b.pourcentageAlcool;
                        //Bieres[i].typeBiereId = b.typeBiereId;
                        Bieres[i] = wpf;
                        i = Bieres.Count() + 2;
                    }
                }
            }
            DalBiere.Update(b.GetBiereDal());
        }
        public void EditerCommande(CommandeWPF b)
        {
            if (Commandes.Count() > 0)
            {
                for (int i = 0; i < Commandes.Count(); i++)
                {
                    if (Commandes[i].commandeId == b.commandeId)
                    {
                        Commandes[i].biereId = b.biereId;
                        Commandes[i].commandeQuantite = b.commandeQuantite;
                        i = Commandes.Count() + 2;
                    }
                }
            }
            DalCom.Update(b.GetCommandeDal());
        }
        public void EditerContact(ContactWPF b)
        {
            if (Contacts.Count() > 0)
            {
                for (int i = 0; i < Contacts.Count(); i++)
                {
                    if (Contacts[i].contactId == b.contactId)
                    {
                        Contacts[i] = b;
                        i = Contacts.Count() + 2;
                    }
                }
            }
            DalContact.Update(b.GetContactDal());
        }
        public void EditerEmploi(EmploiWPF b)
        {
            if (Emplois.Count() > 0)
            {
                for (int i = 0; i < Emplois.Count(); i++)
                {
                    if (Emplois[i].offreEmploiId == b.offreEmploiId)
                    {
                        Emplois[i] = b;
                        i = Emplois.Count() + 2;
                    }
                }
            }
            DalEmploi.Update(b.GetEmploiDal());
        }
        public void EditerEvenement(EvenementWPF b)
        {
            if (Evenements.Count() > 0)
            {
                for (int i = 0; i < Evenements.Count(); i++)
                {
                    if (Evenements[i].eventId == b.eventId)
                    {
                        Evenements[i] = b;
                        i = Evenements.Count() + 2;
                    }
                }
            }
            DalEvent.Update(b.GetEvenementDal());
        }
        public void EditerHorraire(HorraireWPF b)
        {
            if (Horraires.Count() > 0)
            {
                for (int i = 0; i < Horraires.Count(); i++)
                {
                    if (Horraires[i].horraireId == b.horraireId)
                    {
                        Horraires[i] = b;
                        i = Horraires.Count() + 2;
                    }
                }
            }
            DalHorraire.Update(b.GetHorraireDal());
        }
        public void EditerMessage(MessageWPF b)
        {
            if (Messages.Count() > 0)
            {
                for (int i = 0; i < Messages.Count(); i++)
                {
                    if (Messages[i].messageAlertId == b.messageAlertId)
                    {
                        Messages[i] = b;
                        i = Messages.Count() + 2;
                    }
                }
            }
            DalMessage.Update(b.GetMessageDal());
        }
        public void EditerRecompense(RecompenseWPF b)
        {
            if (Recompenses.Count() > 0)
            {
                for (int i = 0; i < Recompenses.Count(); i++)
                {
                    if (Recompenses[i].recompenseId == b.recompenseId)
                    {
                        Recompenses[i] = b;
                        i = Recompenses.Count() + 2;
                    }
                }
            }
            DalRecomp.Update(b.GetRecompenseDal());
        }
        public void DeleteTypeBiere(int i)
        {
            TypeBiereWPF wpf = TypeBieres.Where(p => p.typeBiereId == i).FirstOrDefault();
            TypeBieres.Remove(wpf);
            Dal.Delete(i);
        }
        public void DeleteBiere(int i)
        {
            BiereWPF wpf = Bieres.Where(p => p.biereId == i).FirstOrDefault();
            Bieres.Remove(wpf);
            DalBiere.Delete(i);
        }
        public void DeleteClient(int i)
        {
            ClientWPF wpf = Clients.Where(p => p.clientId == i).FirstOrDefault();
            Clients.Remove(wpf);
            DalClient.Delete(i);
        }
        public void DeleteCommande(int i)
        {
            CommandeWPF wpf = Commandes.Where(p => p.commandeId == i).FirstOrDefault();
            Commandes.Remove(wpf);
            DalCom.Delete(i);

        }
        public void DeleteContact(int i)
        {
            ContactWPF wpf = Contacts.Where(p => p.contactId == i).FirstOrDefault();
            Contacts.Remove(wpf);
            DalContact.Delete(i);
        }
        public void DeleteEmploi(int i)
        {
            EmploiWPF wpf = Emplois.Where(p => p.offreEmploiId == i).FirstOrDefault();
            Emplois.Remove(wpf);
            DalEmploi.Delete(i);
        }
        public void DeleteEvent(int i)
        {
            EvenementWPF wpf = Evenements.Where(p => p.eventId == i).FirstOrDefault();
            Evenements.Remove(wpf);
            DalEvent.Delete(i);
        }
        public void DeleteHorraire(int i)
        {
            HorraireWPF wpf = Horraires.Where(p => p.horraireId == i).FirstOrDefault();
            Horraires.Remove(wpf);
            DalHorraire.Delete(i);
        }
        public void DelelteMessage(int i)
        {
            MessageWPF wpf = Messages.Where(p => p.messageAlertId == i).FirstOrDefault();
            Messages.Remove(wpf);
            DalMessage.Delete(i);
        }
        public void DeleteRecompense(int i)
        {
            RecompenseWPF wpf = Recompenses.Where(p => p.recompenseId == i).FirstOrDefault();
            Recompenses.Remove(wpf);
            DalRecomp.Delete(i);
        }
        public void DesactiverBiere(int id)
        {
            if (Bieres.Count() > 0)
            {
                for (int i = 0; i < Bieres.Count(); i++)
                {
                    if (Bieres[i].biereId == id)
                    {
                        Bieres[i].biereIsDispo = false;
                        i = Bieres.Count() + 2;
                    }
                }
            }
            DalBiere.Desactiver(id);
        }
        public void ActiverBiere(int id)
        {
            if (Bieres.Count() > 0)
            {
                for (int i = 0; i < Bieres.Count(); i++)
                {
                    if (Bieres[i].biereId == id)
                    {
                        Bieres[i].biereIsDispo = true;
                        i = Bieres.Count() + 2;
                    }
                }
            }
            DalBiere.Activer(id);
        }
        private void Init()
        {
            IEnumerable<TypeBiereWPF> typeBieres = Dal.GetAll().Select(p => p.GetTypeBiereWPF());
            foreach (TypeBiereWPF item in typeBieres)
            {
                TypeBieres.Add(item);
            }
            IEnumerable<BiereWPF> bieres = DalBiere.GetAll().Select(p => p.GetBiereWPF());
            foreach (BiereWPF item in bieres)
            {
                Bieres.Add(item);
            }
            IEnumerable<ClientWPF> clients = DalClient.GetAll().Select(p => p.GetClientWPF());
            foreach (ClientWPF item in clients)
            {
                Clients.Add(item);
            }
            IEnumerable<CommandeWPF> commandes = DalCom.GetAll().Select(p => p.GetCommandeWPF());
            foreach (CommandeWPF item in commandes)
            {
                Commandes.Add(item);
            }
            IEnumerable<ContactWPF> contacts = DalContact.GetAll().Select(p => p.GetContactWPF());
            foreach (ContactWPF item in contacts)
            {
                Contacts.Add(item);
            }
            IEnumerable<EmploiWPF> emplois = DalEmploi.GetAll().Select(p => p.GetEmploiWPF());
            foreach (EmploiWPF item in emplois)
            {
                Emplois.Add(item);
            }
            IEnumerable<EvenementWPF> evenements = DalEvent.GetAll().Select(p => p.GetEvenementWPF());
            foreach (EvenementWPF item in evenements)
            {
                Evenements.Add(item);
            }
            IEnumerable<HorraireWPF> horraires = DalHorraire.GetAll().Select(p => p.GetHorraireWPF());
            foreach (HorraireWPF item in horraires)
            {
                Horraires.Add(item);
            }
            IEnumerable<MessageWPF> messages = DalMessage.GetAll().Select(p => p.GetMessageWPF());
            foreach (MessageWPF item in messages)
            {
                Messages.Add(item);
            }
            IEnumerable<RecompenseWPF> recompenses = DalRecomp.GetAll().Select(p => p.GetRecompenseWPF());
            foreach (RecompenseWPF item in recompenses)
            {
                Recompenses.Add(item);
            }


        }
        public ContextData()
        {
            Init();
        }
    }
}

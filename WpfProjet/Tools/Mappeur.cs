using DalWpfProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjet.Models;
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

namespace WpfProjet.Tools
{
    static class Mappeur
    {
        public static BiereWPF GetBiereWPF(this BiereDal dal)
        {
            BiereWPF wpf = new BiereWPF();
            wpf.biereDescription = dal.biereDescription;
            wpf.biereId = dal.biereId;
            wpf.biereImage = dal.biereImage;
            wpf.biereIsDispo = dal.biereIsDispo;
            wpf.biereNom = dal.biereNom;
            wpf.bierePrix = dal.bierePrix;
            wpf.biereRobe = dal.biereRobe;
            wpf.brasserieId = dal.brasserieId;
            wpf.pourcentageAlcool = dal.pourcentageAlcool;
            wpf.typeBiereId = dal.typeBiereId;
            return wpf;
        }
        public static BiereDal GetBiereDal(this BiereWPF wpf)
        {
            BiereDal dal = new BiereDal();
            dal.biereDescription = wpf.biereDescription;
            dal.biereId = wpf.biereId;
            dal.biereImage = wpf.biereImage;
            dal.biereIsDispo = wpf.biereIsDispo;
            dal.biereNom = wpf.biereNom;
            dal.bierePrix = wpf.bierePrix;
            dal.biereRobe = wpf.biereRobe;
            dal.brasserieId = wpf.brasserieId;
            dal.pourcentageAlcool = wpf.pourcentageAlcool;
            dal.typeBiereId = wpf.typeBiereId;
            return dal;
        }
        public static BrasserieWPF GetBrasserieWPF(this BrasserieDal dal)
        {
            BrasserieWPF wpf = new BrasserieWPF();
            wpf.brasserieId = dal.brasserieId;
            wpf.brasseriePresentation = dal.brasseriePresentation;
            wpf.mailInfon = dal.mailInfon;
            wpf.mailRecrutement = dal.mailRecrutement;
            wpf.nomBrasserie = dal.nomBrasserie;
            return wpf;
        }
        public static BrasserieDal GetBrasserieDal(this BrasserieWPF wpf)
        {
            BrasserieDal dal = new BrasserieDal();
            dal.brasserieId = wpf.brasserieId;
            dal.brasseriePresentation = wpf.brasseriePresentation;
            dal.mailInfon = wpf.mailInfon;
            dal.mailRecrutement = wpf.mailRecrutement;
            dal.nomBrasserie = wpf.nomBrasserie;
            return dal;
        }
        public static ClientWPF GetClientWPF(this ClientDal dal)
        {
            ClientWPF wpf = new ClientWPF();
            wpf.clientDateNaissance = dal.clientDateNaissance;
            wpf.clientId = dal.clientId;
            wpf.clientLogin = dal.clientLogin;
            wpf.clientNom = dal.clientNom;
            wpf.clientPrenom = dal.clientPrenom;
            return wpf;
        }
        public static ClientDal GetClientDal(this ClientWPF wpf)
        {
            ClientDal dal = new ClientDal();
            dal.clientDateNaissance = wpf.clientDateNaissance;
            dal.clientId = wpf.clientId;
            dal.clientLogin = wpf.clientLogin;
            dal.clientNom = wpf.clientNom;
            dal.clientPrenom = wpf.clientPrenom;
            dal.clientPwd = wpf.clientPwd;
            return dal;
        }
        public static CommandeWPF GetCommandeWPF(this CommandeDal dal)
        {
            CommandeWPF wpf = new CommandeWPF();
            wpf.biereId = dal.biereId;
            wpf.clientId = dal.clientId;
            wpf.commandeDate = dal.commandeDate;
            wpf.commandeId = dal.commandeId;
            wpf.commandeQuantite = dal.commandeQuantite;
            return wpf;
        }
        public static CommandeDal GetCommandeDal(this CommandeWPF wpf)
        {
            CommandeDal dal = new CommandeDal();
            dal.biereId = wpf.biereId;
            dal.clientId = wpf.clientId;
            dal.commandeDate = wpf.commandeDate;
            dal.commandeId = wpf.commandeId;
            dal.commandeQuantite = wpf.commandeQuantite;
            return dal;
        }
        public static ContactWPF GetContactWPF(this ContactDal dal)
        {
            ContactWPF wpf = new ContactWPF();
            wpf.adCodePostal = dal.adCodePostal;
            wpf.adNumero = dal.adNumero;
            wpf.adRue = dal.adRue;
            wpf.adVille = dal.adVille;
            wpf.brasserieId = dal.brasserieId;
            wpf.contactId = dal.contactId;
            wpf.telephone = dal.telephone;
            return wpf;
        }
        public static ContactDal GetContactDal(this ContactWPF wpf)
        {
            ContactDal dal = new ContactDal();
            dal.adNumero = wpf.adNumero;
            dal.adCodePostal = wpf.adCodePostal;
            dal.adRue = wpf.adRue;
            dal.adVille = wpf.adVille;
            dal.brasserieId = wpf.brasserieId;
            dal.contactId = wpf.contactId;
            dal.telephone = wpf.telephone;
            return dal;
        }
        public static EmploiWPF GetEmploiWPF(this EmploiDal dal)
        {
            EmploiWPF wpf = new EmploiWPF();
            wpf.brasserieId = dal.brasserieId;
            wpf.diplomeMin = dal.diplomeMin;
            wpf.experienceMin = dal.experienceMin;
            wpf.fonction = dal.fonction;
            wpf.jobDescription = dal.jobDescription;
            wpf.offreEmploiId = dal.offreEmploiId;
            return wpf;
        }
        public static EmploiDal GetEmploiDal(this EmploiWPF wpf)
        {
            EmploiDal dal = new EmploiDal();
            dal.brasserieId = wpf.brasserieId;
            dal.diplomeMin = wpf.diplomeMin;
            dal.experienceMin = wpf.experienceMin;
            dal.fonction = wpf.fonction;
            dal.jobDescription = wpf.jobDescription;
            dal.offreEmploiId = wpf.offreEmploiId;
            return dal;
        }
        public static EvenementWPF GetEvenementWPF(this EvenementDal dal)
        {
            EvenementWPF wpf = new EvenementWPF();
            wpf.brasserieId = dal.brasserieId;
            wpf.eventDateDebut = dal.eventDateDebut;
            wpf.eventDateFin = dal.eventDateFin;
            wpf.eventDescription = dal.eventDescription;
            wpf.eventId = dal.eventId;
            return wpf;
        }
        public static EvenementDal GetEvenementDal(this EvenementWPF wpf)
        {
            EvenementDal dal = new EvenementDal();
            dal.brasserieId = wpf.brasserieId;
            dal.eventDateDebut = wpf.eventDateDebut;
            dal.eventDateFin = wpf.eventDateFin;
            dal.eventDescription = wpf.eventDescription;
            dal.eventId = wpf.eventId;
            return dal;
        }
        public static HorraireWPF GetHorraireWPF(this HorraireDal dal)
        {
            HorraireWPF wpf = new HorraireWPF();
            wpf.brasserieId = dal.brasserieId;
            wpf.heureFermeture = dal.heureFermeture;
            wpf.heureOuverture = dal.heureOuverture;
            wpf.horraireDateDebut = dal.horraireDateDebut;
            wpf.horraireDateFin = dal.horraireDateFin;
            wpf.horraireId = dal.horraireId;
            return wpf;
        }
        public static HorraireDal GetHorraireDal(this HorraireWPF wpf)
        {
            HorraireDal dal = new HorraireDal();
            dal.brasserieId = wpf.brasserieId;
            dal.heureFermeture = wpf.heureFermeture;
            dal.heureOuverture = wpf.heureOuverture;
            dal.horraireDateDebut = wpf.horraireDateDebut;
            dal.horraireDateFin = wpf.horraireDateFin;
            dal.horraireId = wpf.horraireId;
            return dal;
        }
        public static MessageWPF GetMessageWPF(this MessageDal dal)
        {
            MessageWPF wpf = new MessageWPF();
            wpf.brasserieId = dal.brasserieId;
            wpf.messageAlertId = dal.messageAlertId;
            wpf.messageContenu = dal.messageContenu;
            wpf.messageDateDebut = dal.messageDateDebut;
            wpf.messageDateFin = dal.messageDateFin;
            return wpf;
        }
        public static MessageDal GetMessageDal(this MessageWPF wpf)
        {
            MessageDal dal = new MessageDal();
            dal.brasserieId = wpf.brasserieId;
            dal.messageAlertId = wpf.messageAlertId;
            dal.messageContenu = wpf.messageContenu;
            dal.messageDateDebut = wpf.messageDateDebut;
            dal.messageDateFin = wpf.messageDateFin;
            return dal;
        }
        public static RecompenseWPF GetRecompenseWPF(this RecompenseDal dal)
        {
            RecompenseWPF wpf = new RecompenseWPF();
            wpf.biereId = dal.biereId;
            wpf.recompenseId = dal.recompenseId;
            wpf.recompenseNom = dal.recompenseNom;
            return wpf;
        }
        public static RecompenseDal GetRecompenseDal(this RecompenseWPF wpf)
        {
            RecompenseDal dal = new RecompenseDal();
            dal.biereId = wpf.biereId;
            dal.recompenseId = wpf.recompenseId;
            dal.recompenseNom = wpf.recompenseNom;
            return dal;
        }
        public static TypeBiereWPF GetTypeBiereWPF(this TypeBiereDal dal)
        {
            TypeBiereWPF wpf = new TypeBiereWPF();
            wpf.typeBiereDefinition = dal.typeBiereDefinition;
            wpf.typeBiereId = dal.typeBiereId;
            wpf.typeBiereNom = dal.typeBiereNom;
            return wpf;
        }
        public static TypeBiereDal GetTypeBiereDal(this TypeBiereWPF wpf)
        {
            TypeBiereDal dal = new TypeBiereDal();
            dal.typeBiereDefinition = wpf.typeBiereDefinition;
            dal.typeBiereId = wpf.typeBiereId;
            dal.typeBiereNom = wpf.typeBiereNom;
            return dal;
        }
        public static TypeBiereWPF GetTypeBiereWPF(this TypeBiere vm)
        {
            TypeBiereWPF wpf = new TypeBiereWPF();
            wpf.typeBiereId = vm.Id;
            wpf.typeBiereDefinition = vm.Def;
            wpf.typeBiereNom = vm.Nom;
            return wpf;
        }
        public static TypeBiere GetTypeBiere(this TypeBiereWPF wpf)
        {
            TypeBiere type = new TypeBiere();
            type.Def = wpf.typeBiereDefinition;
            type.Nom = wpf.typeBiereNom;
            type.Id = wpf.typeBiereId;
            return type;
        }
        public static BiereWPF GetBiereWPF(this Biere vm)
        {
            BiereWPF wpf = new BiereWPF();
            wpf.biereId = vm.Id;
            wpf.biereIsDispo = vm.IsDispo;
            wpf.biereDescription = vm.Description;
            wpf.biereImage = vm.Image;
            wpf.biereNom = vm.Nom;
            wpf.bierePrix = vm.Prix;
            wpf.biereRobe = vm.Robe;
            wpf.pourcentageAlcool = vm.Pa;
            wpf.typeBiereId = vm.TypeBiereId;
            return wpf;
        }
        public static Biere GetBiere(this BiereWPF wpf)
        {
            Biere b = new Biere();
            b.Description = wpf.biereDescription;
            b.Id = wpf.biereId;
            b.Image = wpf.biereImage;
            b.IsDispo = wpf.biereIsDispo;
            b.Nom = wpf.biereNom;
            b.Prix = wpf.bierePrix;
            b.Pa = wpf.pourcentageAlcool;
            b.Robe = wpf.biereRobe;
            if (wpf.typeBiereId != null)
            {
                b.TypeBiereId = (int)wpf.typeBiereId;
            }
            return b;
        }
        public static BrasserieWPF GetBrasserieWPF(this EditBrasserieVM vm)
        {
            BrasserieWPF wpf = new BrasserieWPF();
            wpf.brasserieId = vm.BrasserieId;
            wpf.brasseriePresentation = vm.BrasseriePresentation;
            wpf.mailInfon = vm.MailInfon;
            wpf.mailRecrutement = vm.MailRecrutement;
            wpf.nomBrasserie = vm.NomBrasserie;
            return wpf;
        }
        public static ClientWPF GetClientWPF(this Client vm)
        {
            ClientWPF wpf = new ClientWPF();
            wpf.clientDateNaissance = vm.DateNaissance;
            wpf.clientId = vm.Id;
            wpf.clientLogin = vm.Login;
            wpf.clientNom = vm.Nom;
            wpf.clientPrenom = vm.Prenom;
            wpf.clientPwd = vm.Prenom + vm.Nom;
            return wpf;

        }
        public static CommandeWPF GetCommandeWPF(this Commande vm)
        {
            CommandeWPF wpf = new CommandeWPF();
            wpf.biereId = vm.BiereId;
            wpf.clientId = vm.ClientId;
            wpf.commandeDate = DateTime.Now;
            wpf.commandeId = vm.Id;
            wpf.commandeQuantite = vm.Quantite;
            return wpf;
        }
        public static ContactWPF GetContactWPF(this Contact vm)
        {
            ContactWPF wpf = new ContactWPF();
            wpf.adCodePostal = vm.AdCodePostal;
            wpf.adNumero = vm.AdNumero;
            wpf.adRue = vm.AdRue;
            wpf.adVille = vm.AdVille;
            wpf.telephone = vm.Tel;
            wpf.contactId = vm.Id;
            return wpf;
        }
        public static EmploiWPF GetEmploiWPF(this Emploi vm)
        {
            EmploiWPF wpf = new EmploiWPF();
            wpf.diplomeMin = vm.DiplomeMin;
            if (vm.ExpMin != null)
            {
                wpf.experienceMin = (int)vm.ExpMin;
            }
            wpf.fonction = vm.Fonction;
            wpf.jobDescription = vm.Desc;
            wpf.offreEmploiId = vm.Id;
            return wpf;
        }
        public static EvenementWPF GetEvenementWPF(this Evenement vm)
        {
            EvenementWPF wpf = new EvenementWPF();
            wpf.eventId = vm.Id;
            wpf.eventDescription = vm.Desc;
            wpf.eventDateDebut = vm.DateDebut;
            wpf.eventDateFin = vm.DateFin;
            return wpf;
        }
        public static HorraireWPF GetHorraireWPF(this Horraire vm)
        {
            HorraireWPF wpf = new HorraireWPF();
            wpf.horraireId = vm.Id;
            wpf.horraireDateFin = vm.DateFin;
            wpf.horraireDateDebut = vm.DateDebut;
            wpf.heureFermeture = vm.HeureMinFermeture;
            wpf.heureOuverture = vm.HeureMinOuverture;
            return wpf;
        }
        public static MessageWPF GetMessageWPF(this Message vm)
        {
            MessageWPF wpf = new MessageWPF();
            wpf.messageAlertId = vm.Id;
            wpf.messageContenu = vm.Contenu;
            wpf.messageDateDebut = vm.DatDebut;
            wpf.messageDateFin = vm.DateFin;
            return wpf;
        }
        public static RecompenseWPF GetRecompenseWPF(this Recompense vm)
        {
            RecompenseWPF wpf = new RecompenseWPF();
            wpf.recompenseId = vm.Id;
            wpf.recompenseNom = vm.Nom;
            wpf.biereId = vm.BiereId;
            return wpf;
        }
      
    }
}

using DalWpfProjet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WpfProjet.Models;

namespace WpfProjet.Tools
{
    public  static class Verif
    {
        private static string _regexMail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public static bool IsEmail(string value)
        {
            if (value != null)
            {
                string mail = value.ToString();
                return Regex.IsMatch(mail, _regexMail);
            }
            else
            {
                return false;
            }
        }
        public static bool IsLoginLibre(string value)
        {
            List<string> _listeLogin = new List<string>();
            ClientDalService clientApi = new ClientDalService();
            _listeLogin = clientApi.GetAll().Select(p => p.clientLogin).ToList();
            bool test = true;
            if (value != null)
            {
                string login = value.ToString();
                if (_listeLogin.Count() > 0)
                {
                    for (int i = 0; i < _listeLogin.Count(); i++)
                    {
                        if (_listeLogin[i].ToLower() == login.ToLower())
                        {
                            test = false;
                            i = _listeLogin.Count() + 1;
                        }
                    }
                }
                else
                {
                    test = true;
                }

            }
            else
            {
                test = false;
            }
            return test;
        }
        public static bool IsMajeur(DateTime value)
        {
            bool age = false;
            if (value != null)
            {
                DateTime test = (DateTime)value;
                if (DateTime.Now.Year - test.Year >= 18)
                {
                    age = true;
                }
            }
            return age;
        }
        public static bool IsLoginValid(string value)
        {
            if (value != null)
            {
                if (IsEmail(value) && IsLoginLibre(value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public static bool IsDateDebutValid(DateTime value)
        {
            bool test=true;
            HorraireDalService dal = new HorraireDalService();
            List<HorraireWPF> lh = dal.GetAll().Select(p => p.GetHorraireWPF()).ToList();
            if (value != null && value!=new DateTime())
            {
                if (lh.Count() > 0)
                {
                    for (int i = 0; i < lh.Count(); i++)
                    {
                        if(value>=lh[i].horraireDateDebut && value < lh[i].horraireDateFin)
                        {
                            test = false;
                            i = lh.Count() + 2;
                        }
                    }
                }
            }
            else
            {
                test = false;
            }
            return test;
        }
        public static bool IsDatefin(DateTime value)
        {
            bool test=true;
            if (value != null && value!=new DateTime())
            {
                HorraireDalService dal = new HorraireDalService();
                List<HorraireWPF> lh = dal.GetAll().Select(p => p.GetHorraireWPF()).ToList();
                if (lh.Count() > 0)
                {
                    for (int i = 0; i < lh.Count(); i++)
                    {
                        if(value>lh[i].horraireDateDebut && value <= lh[i].horraireDateFin)
                        {
                            test = false;
                            i = lh.Count() + 2;
                        }
                    }
                }
            }
            else
            {
                test = false;
            }
            return test;
        }
        public static bool IsSameDateDebut(DateTime valueDebut, int id)
        {
            bool test = false; 
            if(valueDebut!=null && valueDebut!=new DateTime())
            {
                HorraireDalService dal = new HorraireDalService();
                DateTime dateDebut = dal.GetOne(id).horraireDateDebut;
                DateTime dateFin = dal.GetOne(id).horraireDateFin;
                if (dateDebut == valueDebut)
                {
                    test = true;
                }
            }
            return test;
        }
        public static bool IsSameDateFin(DateTime valueFin, int id) 
        {
            bool test = false;
            if (valueFin != null && valueFin != new DateTime())
            {
                HorraireDalService dal = new HorraireDalService();
                DateTime dateDebut = dal.GetOne(id).horraireDateDebut;
                DateTime dateFin = dal.GetOne(id).horraireDateFin;
                if (dateFin == valueFin)
                {
                    test = true;
                }
            }
            return test;
        }
    }
}

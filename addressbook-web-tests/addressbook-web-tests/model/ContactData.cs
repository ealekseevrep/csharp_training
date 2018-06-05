﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContacts;

        public ContactData(string firstname)
        {
                Firstname = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + " lastname=" + Lastname;
        }

        //public int CompareTo(ContactData other)
        //{
        //    ContactData obj = (ContactData)other;


        //    if (Object.ReferenceEquals(other.Firstname, null) || Object.ReferenceEquals(other.Lastname, null))
        //    {
        //        return 1;
        //    }

        //    int lastname = Lastname.CompareTo(other.Lastname);
        //    int firstname = Firstname.CompareTo(other.Firstname);
        //    return lastname + firstname;
        //}
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other.Firstname, null))
            {
                return 1;
            }

            return Firstname.CompareTo(other.Firstname);
        }

        public string Firstname { get; set; }

        public string MiddleName { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }
        
        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();

                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n"; 
            //return Regex.Replace(phone, "[ -()]-", "") + "\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }

                if (Email2 == "" && Email3 == "")
                {
                    return Email;
                }

                if (Email2 == "")
                {   
                    return PrepareMail(Email) + PrepareMail(Email3);
                }

                if (Email3 == "")
                {
                    return PrepareMail(Email) + Email2;
                }

                else
                {
                    return PrepareMail(Email) + PrepareMail(Email2) + Email3;
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string PrepareMail(string mail)
        {
            if (mail == null || mail == "")
            {
                return "";
            }
            return mail + "\r\n";
        }

        public string AllContacts
        {
            get
            {
                if (allContacts != null)
                {
                    return allContacts;
                }
                else
                {
                    return Firstname + " " + MiddleName + " " + Lastname + "\r\n" + Address + "\r\n" + "\r\nH: " + HomePhone + "\r\nM: " +
                        MobilePhone + "\r\nW: " + WorkPhone + "\r\n\r\n" + Email + "\r\n" + Email2 + "\r\n" + Email3;
                }
            }
            set
            {
                allContacts = value;
            }
        }
    }
}
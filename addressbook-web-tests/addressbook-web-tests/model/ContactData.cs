using System;
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
            return "firstName=" + Firstname + " \nlastName=" + Lastname;
        }

        public int CompareTo(ContactData other)
        {


            if (Object.ReferenceEquals(other.Firstname, null))
            {
                return 1;
            }

            if (Object.ReferenceEquals(other.Lastname, null))
            {
                return 1;
            }

            if (Object.ReferenceEquals(other.Lastname, Lastname))
            {
                return Firstname.CompareTo(other.Firstname);
            }

            else
            {
                return Lastname.CompareTo(other.Lastname);
            }

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
                    return PrepareFio(Firstname + MiddleName + Lastname) + "\r\n" + PrepareContacts(Address) + PrepareContacts(HomePhone) 
                        + PrepareContacts(MobilePhone) + PrepareContacts(WorkPhone) + "\r\n\r\n" + PrepareMail(Email) + PrepareMail(Email2) + Email3;
                }
            }
            set
            {
                allContacts = value;
            }
        }

        private string PrepareFio(string contact)
        {
            if (contact == null || contact == "")
            {
                return "";
            }

            if (MiddleName == "" && Lastname == "")
            {
                return Firstname;
            }

            if (MiddleName != "" && Lastname == "")
            {
                    return Firstname + " " + Lastname;
            }

            if (MiddleName == "" && Lastname != "")
            {
                return Firstname + " " + Lastname;
            }

            if (Firstname == "" && MiddleName != "")
            {
                if (Lastname != "")
                {
                    return MiddleName + " " + Lastname;
                }
                else
                {
                    return MiddleName;
                }
            }

            else
            {
                return Firstname + " " + MiddleName + " " + Lastname;
            }
        }

        private string PrepareContacts(string contact)
        {
            if (contact == null || contact == "")
            {
                return "";
            }

            if (contact == HomePhone)
            {
                return "\r\nH: " + HomePhone;
            }

            if (contact == MobilePhone)
            {
                return "\r\nM: " + MobilePhone;
            }

            if (contact == WorkPhone)
            {
                return "\r\nW: " + WorkPhone;
            }

            else
            {
                return contact + "\r\n";
            }
        }
    }
}
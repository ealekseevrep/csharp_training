using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        //public static IEnumerable<ContactData> RandomContactDataProvider()
        //{
        //    List<ContactData> contacts = new List<ContactData>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        contacts.Add(new ContactData(GenerateRandomString(10))
        //        {
        //            MiddleName = GenerateRandomString(10),
        //            Lastname = GenerateRandomString(10)
        //        });
        //    }
        //    return contacts;
        //}

        //[Test, TestCaseSource("RandomContactDataProvider")]
        [Test]
        //public void ContactCreationTest(ContactData contact)
        public void ContactCreationTest()
        {
            ContactData newcontact = new ContactData("Name");
            newcontact.Lastname = ("Fam");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(newcontact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(newcontact);
            newContacts.Sort();
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.Lastname = ("");

            app.Contact.Create(contact);
        }
    }
}

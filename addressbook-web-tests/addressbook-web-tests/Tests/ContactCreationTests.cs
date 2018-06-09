using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Threading;
using NUnit.Framework;
using System.IO;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10))
                {
                    MiddleName = GenerateRandomString(10),
                    Lastname = GenerateRandomString(10)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> groups = new List<ContactData>();
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
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

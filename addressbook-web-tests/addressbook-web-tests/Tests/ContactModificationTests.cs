using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Sergey");
            newContactData.Lastname = "Sergeev";

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.CheckContact();
            app.Contact.Modify(0, newContactData);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

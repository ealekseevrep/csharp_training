using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemove = oldContacts[0];

            app.Contact.CheckContact();
            app.Contact.Remove(toBeRemove);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}                                                        
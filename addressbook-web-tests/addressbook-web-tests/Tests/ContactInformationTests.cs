using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            // verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestDetailContactInformation()
        {
            ContactData fromDetails = new ContactData(null);
            fromDetails = app.Contact.GetContactInformationFromDetails(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            // verification
            Assert.AreEqual(fromDetails.AllContacts, fromForm.AllContacts);
        }
    }
}

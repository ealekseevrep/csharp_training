using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Contact.GoToAddContactPage();
            ContactData contact = new ContactData("Ivan", "Ivanov");
            app.Contact.FillAddContactForm(contact);
            app.Contact.SubmitContactCreation();
        }
    }
}

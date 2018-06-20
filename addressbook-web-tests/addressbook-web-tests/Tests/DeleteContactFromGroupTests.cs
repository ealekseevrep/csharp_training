using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestDeleteContactFromGroupTests()
        {
            GroupData group = GroupData.GetGroups()[0];
            List<ContactData> oldContactInGroupList = group.GetContacts();
            ContactData contact = group.GetContacts().First();

            app.Contact.DeleteContactFromGroup(contact, group);

            //actions
            List<ContactData> newContactInGroupList = group.GetContacts();
            oldContactInGroupList.Remove(contact);
            newContactInGroupList.Sort();
            oldContactInGroupList.Sort();

            Assert.AreEqual(oldContactInGroupList, newContactInGroupList);
        }
    }
}

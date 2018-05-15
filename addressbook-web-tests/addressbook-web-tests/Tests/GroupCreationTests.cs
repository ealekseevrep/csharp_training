using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {     
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(new GroupData("aaa","sss","ddd"))
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            app.Auth.Logout();
        }
    }
}
                                                                                                                               
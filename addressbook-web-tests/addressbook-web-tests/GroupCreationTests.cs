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
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(new GroupData("aaa","sss","ddd"));
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
                                                                                                                               
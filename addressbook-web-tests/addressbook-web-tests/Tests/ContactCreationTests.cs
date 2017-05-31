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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Contacts.InitContactCreation();
            app.Contacts.FillContactForm(new ContactData("zzz","xxx"));
            app.Contacts.SubmitContactCreation();
            app.Contacts.ReturnToHomePage();
        }  
    }
}

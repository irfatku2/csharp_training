using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationReverse()
        {
            string fromForm = app.Contacts.GetContactInformationFromEditFormReverse(0);
            string fromTable = app.Contacts.GetContactInformationFromTableReverse(0);

            Assert.AreEqual(fromTable, fromForm);
        }
    }
}

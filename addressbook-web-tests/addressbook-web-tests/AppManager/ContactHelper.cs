﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int v,ContactData newContact)
        {
            SelectContact(v);
            InitContactModification();
            FillContactForm(newContact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            SelectContact(v);
            RemoveContact();
            SubmitRemoveContact();
            return this;
        }

        public ContactHelper ContactExist()
        {
            if (driver.FindElement(By.Id("search_count")).Text == "0")
            {
                Create(new ContactData("qwe", "qwe"));
            }
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            //driver.FindElement(By.Name("middlename")).Clear();
            //driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            //driver.FindElement(By.Name("nickname")).Clear();
            //driver.FindElement(By.Name("nickname")).SendKeys("2");
            //driver.FindElement(By.Name("title")).Clear();
            //driver.FindElement(By.Name("title")).SendKeys("3");
            //driver.FindElement(By.Name("company")).Clear();
            //driver.FindElement(By.Name("company")).SendKeys("4");
            //driver.FindElement(By.Name("address")).Clear();
            //driver.FindElement(By.Name("address")).SendKeys("5");
            //driver.FindElement(By.Name("home")).Clear();
            //driver.FindElement(By.Name("home")).SendKeys("6");
            //driver.FindElement(By.Name("mobile")).Clear();
            //driver.FindElement(By.Name("mobile")).SendKeys("7");
            //driver.FindElement(By.Name("work")).Clear();
            //driver.FindElement(By.Name("work")).SendKeys("8");
            //driver.FindElement(By.Name("fax")).Clear();
            //driver.FindElement(By.Name("fax")).SendKeys("9");
            //driver.FindElement(By.Name("email")).Clear();
            //driver.FindElement(By.Name("email")).SendKeys("10");
            //driver.FindElement(By.Name("email2")).Clear();
            //driver.FindElement(By.Name("email2")).SendKeys("11");
            //driver.FindElement(By.Name("email3")).Clear();
            //driver.FindElement(By.Name("email3")).SendKeys("12");
            //driver.FindElement(By.Name("homepage")).Clear();
            //driver.FindElement(By.Name("homepage")).SendKeys("13");
            //driver.FindElement(By.Name("address2")).Clear();
            //driver.FindElement(By.Name("address2")).SendKeys("14");
            //driver.FindElement(By.Name("phone2")).Clear();
            //driver.FindElement(By.Name("phone2")).SendKeys("15");
            //driver.FindElement(By.Name("notes")).Clear();
            //driver.FindElement(By.Name("notes")).SendKeys("16");
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index+1 + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click(); 
            return this;
        }

        public ContactHelper SubmitRemoveContact()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> contactElements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement contactElement in contactElements)
            {
                string fn = contactElement.FindElements(By.TagName("td"))[2].Text;
                string ln = contactElement.FindElements(By.TagName("td"))[1].Text;
                contacts.Add(new ContactData(fn, ln));
            }
            return contacts;
        }
    }
}

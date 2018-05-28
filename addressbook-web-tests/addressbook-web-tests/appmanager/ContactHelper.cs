﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
            GoToAddContactPage();
            FillAddContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            manager.Navigator.GoToHomePage();

            //Получаем список всех строк таблицы контактов
            IWebElement table = driver.FindElement(By.ClassName("sortcompletecallback-applyZebra"));
            List<ContactData> contacts = new List<ContactData>();
            List<IWebElement> Rows = new List<IWebElement>(table.FindElements(By.XPath("//tr[@name='entry']")));
            List<List<IWebElement>> table_element = new List<List<IWebElement>>();

            //Цикл по найденным строкам, берем текст из ячеек
            for (int k = 0; k < Rows.Count; k++)
            {
                table_element.Add(new List<IWebElement>(Rows[0].FindElements(By.XPath("//tr[@name='entry']/ td[text()]"))));
            }

            //Добавляем текст в коллекцию
            for (int k = 0; k < Rows.Count * 2; k++)
            {
                    k++;
                    ContactData contact = new ContactData(table_element[0][k].Text);
                    k--;
                    contact.Lastname = table_element[0][k].Text;
                    k++;
                    contacts.Add(contact);
            }
            return contacts;
        }


        public ContactHelper Modify(int p, ContactData newContactData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            InitContactModification(p);
            FillAddContactForm(newContactData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            RemoveContact();
            AcceptAlert();
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillAddContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper GoToAddContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper CheckContact()
        {
            ContactData contact = new ContactData("Petr");
            contact.Lastname = ("Petrov");
            var contactEdit = By.XPath("//img[@alt='Edit']");

            if (!IsElementPresent(contactEdit))
            {
                Create(contact);
                manager.Navigator.GoToHomePage();
            }
            return this;
        }
    }
}

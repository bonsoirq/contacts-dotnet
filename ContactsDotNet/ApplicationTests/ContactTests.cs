using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests
{
    [TestClass()]
    public class ContactTests
    {
        [TestMethod()]
        public void ToCsvTest()
        {
            var contact = new Contact();
            contact.Index = 123;
            contact.Name = "Name";
            contact.Position = "Position";
            contact.PhoneNumber = "PhoneNumber";
            contact.Email = "Email";
            contact.Website = "Website";
            contact.Address = "Address";
            contact.Notes = "Notes";

            var expected = "123,Name,Position,PhoneNumber,Email,Website,Address,Notes";

            Assert.AreEqual(expected, contact.ToCsv());
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            var contact = new Contact();
            contact.Index = 123;
            contact.Name = "Name";
            contact.PhoneNumber = "PhoneNumber";
            contact.Email = "Email";

            var expected = new string[] { "123", "Name", "PhoneNumber", "Email" };

            CollectionAssert.AreEqual(expected, contact.ToArray());
        }

        [TestMethod()]
        public void ParseTest()
        {
            var csv = "123,Name,Position,PhoneNumber,Email,Website,Address,Notes";

            var contact = new Contact();
            contact.Index = 123;
            contact.Name = "Name";
            contact.Position = "Position";
            contact.PhoneNumber = "PhoneNumber";
            contact.Email = "Email";
            contact.Website = "Website";
            contact.Address = "Address";
            contact.Notes = "Notes";

            Assert.AreEqual(contact.Index, Contact.Parse(csv).Index);
            Assert.AreEqual(contact.Name, Contact.Parse(csv).Name);
            Assert.AreEqual(contact.Position, Contact.Parse(csv).Position);
            Assert.AreEqual(contact.PhoneNumber, Contact.Parse(csv).PhoneNumber);
            Assert.AreEqual(contact.Email, Contact.Parse(csv).Email);
            Assert.AreEqual(contact.Website, Contact.Parse(csv).Website);
            Assert.AreEqual(contact.Address, Contact.Parse(csv).Address);
            Assert.AreEqual(contact.Notes, Contact.Parse(csv).Notes);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ParseThrowTest()
        {
            var csv = "";
            Contact.Parse(csv);
        }
    }
}
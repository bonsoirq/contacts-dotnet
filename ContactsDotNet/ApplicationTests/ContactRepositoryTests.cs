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
    public class ContactRepositoryTests
    {
        [TestMethod()]
        public void FindTest()
        {
            var contactRepository = new ContactRepository();

            Contact[] contacts = new Contact[5];
            for (var i = 0; i < contacts.Length; i++)
            {
                contacts[i] = new Contact();
                contacts[i].Index = i + 1;
                contactRepository.Add(contacts[i]);
            }

            var expected = contacts[2];
            var actual = contactRepository.Find(3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveIndexTest()
        {
            var contactRepository = new ContactRepository();

            Contact[] contacts = new Contact[5];
            for (var i = 0; i < contacts.Length; i++)
            {
                contacts[i] = new Contact();
                contacts[i].Index = i + 1;
                contactRepository.Add(contacts[i]);
            }

            contactRepository.Remove(3);
            var value = contactRepository.Find(3);

            Assert.IsNull(value);
        }

        [TestMethod()]
        public void RemoveContactTest()
        {
            var contactRepository = new ContactRepository();

            Contact[] contacts = new Contact[5];
            for (var i = 0; i < contacts.Length; i++)
            {
                contacts[i] = new Contact();
                contacts[i].Index = i + 1;
                contactRepository.Add(contacts[i]);
            }

            contactRepository.Remove(contacts[2]);
            var value = contactRepository.Find(3);

            Assert.IsNull(value);
        }

        [TestMethod()]
        public void AddTest()
        {
            var contactRepository = new ContactRepository();

            Contact[] contacts = new Contact[2];
            for (var i = 0; i < contacts.Length; i++)
            {
                contacts[i] = new Contact();
                contacts[i].Index = i + 1;
                contactRepository.Add(contacts[i]);
            }

            Assert.AreEqual(contacts[0], contactRepository.Find(1));
            Assert.AreEqual(1, contactRepository.Find(1).Index);
            Assert.AreEqual(contacts[1], contactRepository.Find(2));
            Assert.AreEqual(2, contactRepository.Find(2).Index);
        }
    }
}
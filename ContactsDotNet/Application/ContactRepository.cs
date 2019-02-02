using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ContactRepository : IRepository<Contact>, IEnumerable<Contact>
    {
        private List<Contact> _contacts = new List<Contact>();

        public Contact Find(int index) => _contacts.Find(x => x.Index == index);

        public void Remove(int index) => _contacts.RemoveAll(x => x.Index == index);

        public void Remove(Contact contact) => _contacts.RemoveAll(x => x == contact);

        public void Add(Contact contact)
        {
            contact.Index = _contacts.Count == 0 ? 1 : _contacts.Max(x => x.Index) + 1;
            _contacts.Add(contact);
        }

        public IEnumerator<Contact> GetEnumerator()
        {
            return _contacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _contacts.GetEnumerator();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Contact
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }

        public string ToCsv()
        {
            return $"{Index},{Name},{Position},{PhoneNumber},{Email},{Website},{Address},{Notes}";
        }

        public static Contact Parse(string csv)
        {
            var contact = new Contact();
            string[] properties = csv.Split(',');
            try
            {
                var index = int.Parse(properties[0]);
                contact.Index = index;
                contact.Name = properties[1];
                contact.Position = properties[2];
                contact.PhoneNumber = properties[3];
                contact.Email = properties[4];
                contact.Website = properties[5];
                contact.Address = properties[6];
                contact.Notes = properties[7];
            }
            catch (Exception)
            {
                throw new FormatException("Provide valid Contact CSV format");
            }
            return contact;
        }
    }
}

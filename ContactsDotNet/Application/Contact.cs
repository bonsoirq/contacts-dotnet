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
    }
}

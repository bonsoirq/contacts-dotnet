﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Application
    {
        public IRepository<Contact> Repository = new ContactRepository();
    }
}

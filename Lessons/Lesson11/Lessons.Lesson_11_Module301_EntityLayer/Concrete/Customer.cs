﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_11_Module301_EntityLayer.Concrete
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public bool Status { get; set; }
        public List<Order> Orders { get; set; }
    }
}
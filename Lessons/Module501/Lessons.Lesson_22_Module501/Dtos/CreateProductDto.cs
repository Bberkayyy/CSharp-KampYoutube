﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_22_Module501.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
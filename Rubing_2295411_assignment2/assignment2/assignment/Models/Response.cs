﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace assignment.Models
{
    internal class Response
    {
        public int statusCode { get; set; }
        public string messageCode { get; set; }
        public Farmer farmer { get; set; }
        public List<Farmer> farmers { get; set; }
    }
}

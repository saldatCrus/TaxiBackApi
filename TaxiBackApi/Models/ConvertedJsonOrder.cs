﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBackApi.Models
{
    public class ConvertedJsonOrder
    {
        public Product product { get; set; }

        public Root root { get; set; }
    }
}


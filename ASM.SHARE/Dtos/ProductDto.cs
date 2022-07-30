﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }


        public int Quantity { get; set; }


        public float Price { get; set; }

        public string Desc { get; set; }

        public string ImageUrl { get; set; }


        public string Address { get; set; }

        public string QrCodeUrl { get; set; }

        // khóa ngoại
        public int CategoryId { get; set; }
    }
}
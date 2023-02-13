﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Interview.Web.Models
{
    public class Product
    {
        [Key]
        public int InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ProductImageUris { get; set; }

        public string ValidSkus { get; set; }

        public DateTime CreatedTimestamp { get; set; }
    }
}

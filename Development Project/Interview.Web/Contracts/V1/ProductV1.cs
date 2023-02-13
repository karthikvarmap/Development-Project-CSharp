using Interview.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Interview.Web.Contracts.V1
{
    public class ProductV1
    {
        public int? InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductImageUris { get; set; }
        public string ValidSkus { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public int CategoryInstanceId { get; set; }
        public IEnumerable<ProductAttributes> ProductAttributes { get; set; }
    }
}

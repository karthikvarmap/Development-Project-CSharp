using System.ComponentModel.DataAnnotations;

namespace Interview.Web.Models
{
    public class ProductAttributes
    {
        [Key]
        public int InstanceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

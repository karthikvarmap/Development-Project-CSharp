using System.ComponentModel.DataAnnotations;

namespace Interview.Web.Models
{
    public class ProductCategories
    {
        [Key]
        public int InstanceId { get; set; }
        public int CategoryInstanceId { get; set; }
    }
}

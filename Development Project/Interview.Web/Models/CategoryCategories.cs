using System.ComponentModel.DataAnnotations;

namespace Interview.Web.Models
{
    public class CategoryCategories
    {
        [Key]
        public int InstanceId { get; set; }
        public int CategoryInstanceId { get; set; }
    }
}

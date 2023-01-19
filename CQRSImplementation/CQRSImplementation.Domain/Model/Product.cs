using CQRSImplementation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace CQRSImplementation.Domain.Model
{
    public class Product : BaseEntity
    {

        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public Double Price { get; set; }
        public int Id { get; set; }
    }
}

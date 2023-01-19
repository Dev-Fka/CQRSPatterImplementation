using CQRSImplementation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace CQRSImplementation.Domain.Model
{
    public class Company : BaseEntity
    {

        [Required]
        public string CompanyName { get; set; }

        public bool IsApprovedCompany { get; set; }
        [Required]
        public DateTime BeginOrderTime { get; set; }
        [Required]
        public DateTime EndOrderTime { get; set; }
        public int Id { get; set; }
    }
}

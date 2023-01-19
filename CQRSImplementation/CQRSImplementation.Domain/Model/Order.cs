using CQRSImplementation.Domain.Common;

namespace CQRSImplementation.Domain.Model
{
    public class Order : BaseEntity
    {

        public Product? Product { get; set; }
        public Company? Company { get; set; }
        public string OrderedName { get; set; } = null!;
        public DateTime OrderedDate { get; set; }
        public int Id { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? OrderSum { get; set; }

        public int? UserId { get; set; }
    }
}
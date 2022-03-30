using System.ComponentModel.DataAnnotations;

namespace Test.Infraestructure.Entities
{
    public class Product : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
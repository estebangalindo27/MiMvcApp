using System.ComponentModel.DataAnnotations;

namespace MiMvcApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
    }
}

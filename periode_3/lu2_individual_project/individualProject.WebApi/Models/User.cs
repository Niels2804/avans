using System.ComponentModel.DataAnnotations;

namespace individualProject.WebApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
        
        [Required]
        public Guid password { get; set; }
    }
}

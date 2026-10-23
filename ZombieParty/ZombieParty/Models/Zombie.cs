using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZombieParty.Models
{
    public class Zombie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string ShortDesc { get; set; }

        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        public int ZombieTypeId { get; set; }

        [ValidateNever]
        public virtual ZombieType ZombieType { get; set; }

        [Range(1, 10, ErrorMessage = "{0} required a value between {1} and {2}.")]
        public int Point { get; set; }

        public int Force { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? Image { get; set; }
    }
}

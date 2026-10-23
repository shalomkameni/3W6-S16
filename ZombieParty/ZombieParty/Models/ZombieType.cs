using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class ZombieType
    {
        public int Id { get; set; }
        [DisplayName("Type Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the {0}.")]
        public string TypeName { get; set; }
        [Range(2, 5, ErrorMessage = "{0} required a value between {1} and {2}.")]
        public int Point { get; set; }
        //OBLIGATOIRE Pour la relation 1 à plusieurs avec ZombieType
        public virtual IList<Zombie> Zombies { get; set; } = new List<Zombie>();
    }
}

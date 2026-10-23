using ZombieParty.Models;

namespace ZombieParty.ViewModels
{
    public class ZombieTypeVM
    {
        public string ZombieType { get; set; }
        public List<Zombie> Zombies { get; set; } = new List<Zombie>();
    }
}

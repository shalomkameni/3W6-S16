using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZombieParty.Models;
using ZombieParty.Utility;
using ZombieParty.Models.Data;

namespace ZombieParty.Controllers
{
    public class WeaponController : Controller
    {
        private ZombiePartyDbContext context;

        public WeaponController(ZombiePartyDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Weapon.ToListAsync());
        }

        //GET UPSERT
        public async Task<IActionResult> Upsert(int weaponId = 0)
        {
            if (weaponId == 0)
                return View(new Weapon());
            else
                return View(await this.context.Weapon.FindAsync(weaponId));
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                if (weapon.Id == 0)
                {
                    TempData[AppConstants.Success] = "Weapon added!";
                    this.context.Weapon.Add(weapon);
                }
                else
                {
                    TempData[AppConstants.Success] = $"Weapon {weapon.Name} edited!";
                    this.context.Update(weapon);
                }
                await this.context.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }
            TempData[AppConstants.Error] = "An error occured while saving your weapon";

            return this.View(weapon);
        }
    }
}

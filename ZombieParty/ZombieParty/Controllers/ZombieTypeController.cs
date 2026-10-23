using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        private ZombiePartyDbContext context;

        public ZombieTypeController(ZombiePartyDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            this.ViewBag.MaListe = await this.context.ZombieType.ToListAsync();

            return View();
        }

        //GET UPSERT
        public async Task<IActionResult> Upsert(int zombieTypeId = 0)
        {
            if (zombieTypeId == 0)
                return View(new ZombieType());
            else
                return View(await this.context.ZombieType.FindAsync(zombieTypeId));
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ZombieType zombieType)
        {
            ModelState.Remove(nameof(zombieType.Zombies));

            if (ModelState.IsValid)
            {
                if (zombieType.Id == 0)
                    this.context.ZombieType.Add(zombieType);
                else
                    this.context.Update(zombieType);

                await this.context.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }

            return this.View(zombieType);
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = this.context.ZombieType.Where(x => x.Id == id).Select(x => new ZombieTypeVM()
            {
                ZombieType = x.TypeName,
                Zombies = x.Zombies.ToList()
            }).FirstOrDefaultAsync();

            if (viewModel == null) return this.RedirectToAction(nameof(Index));

            return View(viewModel);
        }
    }
}

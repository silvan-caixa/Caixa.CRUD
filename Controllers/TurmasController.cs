using Caixa;
using Caixai.Web2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Caixai.Web2.Controllers
{
    public class TurmasController : Controller
    {
        private readonly CaixaDbContext dbContext;
        public TurmasController(CaixaDbContext dbContext) => this.dbContext = dbContext;
        public IActionResult Index()
        {
            return View(dbContext.Turmas);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(Guid? id)
        {
            if(!id.HasValue) { return NotFound(); }

            var turma = dbContext.Turmas.Find(id);
            if(turma == null) {  return NotFound(); }

            return View(turma);
        }
        public IActionResult Delete(Guid? id)
        {
            if (!id.HasValue) { return NotFound(); }

            var turma = dbContext.Turmas.Find(id);
            if (turma == null) { return NotFound(); }



            return View(turma);
        }
        [HttpPost]
        public IActionResult Create(Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return View(turma);
            }
            dbContext.Turmas.Add(turma);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Turma turma)
        {
            dbContext.Turmas.Update(turma);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteConfirm(Guid? id)
        {
            if (!id.HasValue) { return NotFound(); }

            var turma = dbContext.Turmas.Find(id);
            if (turma == null) { return NotFound(); }

            dbContext.Turmas.Remove(turma);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

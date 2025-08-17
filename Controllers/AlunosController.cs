using Caixa;
using Caixai.Web2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Caixai.Web2.Controllers
{
    public class AlunosController : Controller
    {
        private CaixaDbContext dbContext;

        public AlunosController(CaixaDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        // GET: AlunosController
        public ActionResult Index()
        {
            return View(dbContext.Alunos);
        }
        

        // GET: AlunosController/Create
        public ActionResult Create()
        {
            ViewBag.Turmas = GetTurmas();
            return View();
        }
        private IEnumerable<SelectListItem> GetTurmas()
        {
            var turmas = dbContext.Turmas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome }).ToList();
            turmas.Insert(0, new SelectListItem { Value = "", Text = "Selecione uma turma" });

            return turmas;
        }

        // POST: AlunosController/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno)        
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.Turmas = GetTurmas();
                return View(aluno);
            } 

            dbContext.Alunos.Add(aluno);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: AlunosController/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue) { return NotFound(); }

            var aluno = dbContext.Alunos.Find(id);
            if (aluno == null) { return NotFound(); }

            return View(aluno);
        }

        // POST: AlunosController/Edit/5
        [HttpPost]
        public ActionResult Edit(Aluno aluno)
        {
            dbContext.Alunos.Update(aluno);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
                        
        }

        // GET: AlunosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlunosController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

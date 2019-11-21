using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.Infraestrutura;
using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly GerenciadorContext _context;

        public TarefaController(GerenciadorContext context)
        {
            _context = context;
        }

        // GET: Tarefa
        public async Task<IActionResult> Index()
        {
            var gerenciadorContext = _context.Tarefas.Include(t => t.Usuario);
            return View(await gerenciadorContext.ToListAsync());
        }

        // GET: Tarefa/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefa/Create
        public IActionResult Create()
        {
            ViewData["CodigoUsuario"] = new SelectList(_context.Usuarios, "Codigo", "Email");
            return View();
        }

        // POST: Tarefa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,Data,Concluida,CodigoUsuario,Codigo")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.Codigo = Guid.NewGuid();
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoUsuario"] = new SelectList(_context.Usuarios, "Codigo", "Email", tarefa.CodigoUsuario);
            return View(tarefa);
        }

        // GET: Tarefa/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            ViewData["CodigoUsuario"] = new SelectList(_context.Usuarios, "Codigo", "Email", tarefa.CodigoUsuario);
            return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Descricao,Data,Concluida,CodigoUsuario,Codigo")] Tarefa tarefa)
        {
            if (id != tarefa.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaExists(tarefa.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoUsuario"] = new SelectList(_context.Usuarios, "Codigo", "Email", tarefa.CodigoUsuario);
            return View(tarefa);
        }

        // GET: Tarefa/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefaExists(Guid id)
        {
            return _context.Tarefas.Any(e => e.Codigo == id);
        }
    }
}

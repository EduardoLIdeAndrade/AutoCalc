using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoCalc.Models;

namespace AutoCalc.Controllers
{
    public class AbastecimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbastecimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Abastecimentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Abastecimentos.Include(a => a.Veiculo);
            return View(await applicationDbContext
                        //Exibir apenas conteúdo do usuário logado.
                        .AsNoTracking()
                        .Where(x => x.Usuario == User.Identity.Name)
                        //Exibir apenas conteúdo do usuário logado.
                        .ToListAsync());
        }

        // GET: Abastecimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Abastecimentos == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimentos
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abastecimento == null)
            {
                return NotFound();
            }
            //Apenas Itens do Usuário
            if (abastecimento.Usuario != User.Identity.Name)
            {
                return NotFound();
            }
            //Apenas Itens do Usuário

            return View(abastecimento);
        }

        // GET: Abastecimentos/Create
        public IActionResult Create()
        {
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AnoDoVeiculo");
            return View();
        }

        // POST: Abastecimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,NomeDoPosto,ValorPorLitro,ValorTotal,TotaldeLitrosAbastecido,KilometragemTotal,TipoDeCombustivel,Observações,Usuario,VeiculoId")] Abastecimento abastecimento)
        {
            if (ModelState.IsValid)
            {
                //Apenas Itens do Usuário
                abastecimento.Usuario = User.Identity.Name;
                //Apenas Itens do Usuário
                _context.Add(abastecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AnoDoVeiculo", abastecimento.VeiculoId);
            return View(abastecimento);
        }

        // GET: Abastecimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Abastecimentos == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimentos.FindAsync(id);
            if (abastecimento == null)
            {
                return NotFound();
            }
            //Apenas Itens do Usuário
            if (abastecimento.Usuario != User.Identity.Name)
            {
                return NotFound();
            }
            //Apenas Itens do Usuário
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AnoDoVeiculo", abastecimento.VeiculoId);
            return View(abastecimento);
        }

        // POST: Abastecimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Data,NomeDoPosto,ValorPorLitro,ValorTotal,TotaldeLitrosAbastecido,KilometragemTotal,TipoDeCombustivel,Observações,Usuario,VeiculoId")] Abastecimento abastecimento)
        {
            if (id != abastecimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abastecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbastecimentoExists(abastecimento.Id))
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
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AnoDoVeiculo", abastecimento.VeiculoId);
            return View(abastecimento);
        }

        // GET: Abastecimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Abastecimentos == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimentos
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abastecimento == null)
            {
                return NotFound();
            }
            //Apenas Itens do Usuário
            if (abastecimento.Usuario != User.Identity.Name)
            {
                return NotFound();
            }
            //Apenas Itens do Usuário

            return View(abastecimento);
        }

        // POST: Abastecimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Abastecimentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Abastecimentos'  is null.");
            }
            var abastecimento = await _context.Abastecimentos.FindAsync(id);
            if (abastecimento != null)
            {
                _context.Abastecimentos.Remove(abastecimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbastecimentoExists(int? id)
        {
          return (_context.Abastecimentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

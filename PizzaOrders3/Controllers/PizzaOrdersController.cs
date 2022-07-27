using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaOrders3.Data;
using PizzaOrders3.Models;
using PizzaOrders3.ViewModels;

namespace PizzaOrders3.Controllers
{
	public class PizzaOrdersController : Controller
	{
		private readonly PizzaOrdersContext _context;

		public PizzaOrdersController(PizzaOrdersContext context)
		{
			_context = context;
		}

		// GET: PizzaOrders
		public async Task<IActionResult> Index()
		{
			return View(await _context.PizzaOrders.OrderBy(c => c.CasVyzvednuti).ToListAsync());
		}

		/// <summary>
		/// Returns pizza orders with detail
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pizzaOrder = await _context.PizzaOrders
				.FirstOrDefaultAsync(m => m.Id == id);
			if (pizzaOrder == null)
			{
				return NotFound();
			}

			return View(pizzaOrder);
		}

		/// <summary>
		/// Inicial Create method to Create reservation
		/// </summary>
		/// <returns></returns>
		public IActionResult Create()
		{
			PizzaOrderViewModel viewModel = new PizzaOrderViewModel();
			viewModel.Reservations = _context.Reservations.Where(c => true).Include("Orders").ToList();

			return View(viewModel);
		}

		/// <summary>
		/// Saves rezervation to database
		/// </summary>
		/// <param name="pizzaOrder"></param>
		/// <returns></returns>
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		
		public async Task<IActionResult> Create(PizzaOrderViewModel pizzaOrder)
		{
			if (ModelState.IsValid)
			{
				int reservationTimeIdToReserve = pizzaOrder.Order.ReservationId;

				bool reservationAlreadyExists = _context.PizzaOrders.Any(c => c.ReservationId == reservationTimeIdToReserve);
				//Pokud Rezervaci už někdo stihl vytvořit, vrať se
				if (reservationAlreadyExists)
					return BadRequest("Bohužel tě někdo předběhl! Prosím vrať se a zadej vyber jiný čas objendávky");

				pizzaOrder.Order.CasVyzvednuti = _context
					.Reservations
					.FirstOrDefault(c => c.Id == reservationTimeIdToReserve)
					.Time;

				_context.Add(pizzaOrder.Order);
				_context.SaveChanges();

				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(pizzaOrder);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pizzaOrder = await _context.PizzaOrders.FindAsync(id);
			if (pizzaOrder == null)
			{
				return NotFound();
			}
			return View(pizzaOrder);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Room,Name,CasVyzvednuti,IncludeHam,IncludeBacon,IncludeMushrooms,IncludeOlives,IncludeCorn,IncludeCibule,IncludePepper,IncludeHermelin,IncludeNiva,IncludeEidam,Note")] PizzaOrder pizzaOrder)
		{
			if (id != pizzaOrder.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(pizzaOrder);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PizzaOrderExists(pizzaOrder.Id))
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
			return View(pizzaOrder);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pizzaOrder = await _context.PizzaOrders
				.FirstOrDefaultAsync(m => m.Id == id);
			if (pizzaOrder == null)
			{
				return NotFound();
			}

			return View(pizzaOrder);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var pizzaOrder = await _context.PizzaOrders.FindAsync(id);
			_context.PizzaOrders.Remove(pizzaOrder);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PizzaOrderExists(int id)
		{
			return _context.PizzaOrders.Any(e => e.Id == id);
		}
	}
}

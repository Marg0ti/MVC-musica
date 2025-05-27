using MusicAut_HernandezMargot.Data;
using MusicAut_HernandezMargot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Controllers
{
	[Authorize(Roles ="Administrator, Platinum")]
	public class AdminMargotController : Controller
	{
		private readonly Margot_ChinookContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public AdminMargotController(Margot_ChinookContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}
 

		public async Task<IActionResult> ListaUsuariosRegistrados()
		{
			var users = await _userManager.Users.ToListAsync();
			return View(users);
		}

		public async Task<IActionResult> ListaCustomers()
		{
			
			var customers =  _context.Customers.OrderByDescending(x => x.CustomerId).Take(15); ;

			return View(await customers.ToListAsync());
		}




        [Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteCustomer(int? Id)
        {
            if (Id == null)
            {
                return NotFound("Cliente no encontrado");
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == Id);
            if (customer == null)
			{
                return NotFound("Cliente no encontrado");
            }
                return RedirectToAction("Temporal", "Home");
        }

		[HttpPost, ActionName("DeleteCustomer")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomer(int? Id, Customer customer)
		{
            if (Id == null)
            {
                return NotFound("Cliente no encontrado");
            }

            var customerToDelete = await _context.Customers
                .Include(c => c.Invoices)
                .FirstOrDefaultAsync(c => c.CustomerId == Id);
            if (customerToDelete == null)
            {
                return NotFound("Cliente no encontrado");
			}

			//Eliminarlo de la base de datos
			//Primero las facturas
			_context.Invoices.RemoveRange(customerToDelete.Invoices);
			//cliente
			_context.Customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ListaCustomers));
        }




        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound("Cliente no encontrado.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Customers.Any(c => c.CustomerId == id))
                    {
                        return NotFound("Cliente no encontrado.");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListaCustomers));
            }
            return View(customer);

        }




        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditUser(string? Id)
		{
			
			if (string.IsNullOrEmpty(Id))
			{
				return NotFound("Usuario no encontrado.");
			}
			var user = await _userManager.FindByIdAsync(Id);

			return View(user);
        }
		[HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditUser(string Id, IdentityUser user)
		{
            var userToUpdate = await _userManager.FindByIdAsync(user.Id);
			if (userToUpdate == null)
			{
				return NotFound("Usuario no encontrado.");
            }
			userToUpdate.Email = user.Email;
            userToUpdate.UserName = user.UserName;
			var result = await _userManager.UpdateAsync(userToUpdate);
			if (result.Succeeded)
			{
                return RedirectToAction(nameof(ListaUsuariosRegistrados));
            }
                return View(Id);
		}


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteUser(string Id)
		{
			if (string.IsNullOrEmpty(Id))
			{
				return NotFound("Usuario no encontrado.");
			}
			var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
			{
                return NotFound("Usuario no encontrado.");
            }
			ViewData["Id"] = user.Id;
            return View(user);
		}

		[HttpPost, ActionName("DeleteUser")]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string Id, IdentityUser user)
		{
			var userToDelete = await _userManager.FindByIdAsync(Id);
			if (userToDelete == null)
			{
                return NotFound("Usuario no encontrado");
            }

			var result = await _userManager.DeleteAsync(userToDelete);
			if (result.Succeeded)
			{
				return RedirectToAction(nameof(ListaUsuariosRegistrados));
			}

			// Manejar errores de eliminación
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}

			return View( user); // Mostrar la vista con los errores
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using System.Threading.Tasks;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminReservationController : Controller
    {
        private readonly RestaurantContext _context;

        public AdminReservationController(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await _context.Reservations
                .OrderByDescending(r => r.ReservationDate)
                .ToListAsync();
            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            try
            {
                var reservation = await _context.Reservations.FindAsync(id);
                if (reservation == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy đặt bàn" });
                }

                if (Enum.TryParse<ReservationStatus>(status, out var newStatus))
                {
                    reservation.Status = newStatus;
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Trạng thái không hợp lệ" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.CreatedDate = DateTime.UtcNow;
                reservation.Status = ReservationStatus.Pending;
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }
    }
}

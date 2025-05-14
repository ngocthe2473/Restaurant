using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ResrevationController : Controller
    {
        private readonly RestaurantContext restaurantContext;
        public ResrevationController(RestaurantContext context)
        {
            restaurantContext = context;
        }
        [HttpPost]
        [Route("/SaveReservation")]
        public IActionResult SaveReservation([FromBody] Reservation reservation)
        {
            var existingReservation = restaurantContext.Reservations.Find(reservation.ReservationId);
            if (existingReservation == null || existingReservation.Status != ReservationStatus.Available)
            {
                return BadRequest("Bàn không khả dụng.");
            }
            existingReservation.FullName = reservation.FullName;
            existingReservation.Phone = reservation.Phone;
            existingReservation.Email = reservation.Email;
            existingReservation.SpecialRequest = reservation.SpecialRequest;
            existingReservation.ReservationDate = DateTime.Now;
            existingReservation.Status = ReservationStatus.Pending;
            existingReservation.NumberOfGuests = reservation.NumberOfGuests;

            restaurantContext.SaveChanges();

            return Ok("Đặt bàn thành công!");
        }
    }
}

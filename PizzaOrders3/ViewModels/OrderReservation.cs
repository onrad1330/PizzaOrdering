using PizzaOrders3.Models;

namespace PizzaOrders3.ViewModels
{
	public class OrderReservation
	{
		public int OrderID { get; set; }
		public Reservation Reservation { get; set; }
	}
}

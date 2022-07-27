using PizzaOrders3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrders3.ViewModels
{
	public class PizzaOrderViewModel
	{
		public PizzaOrderViewModel()
		{
			this.Order = new PizzaOrder();
			this.Reservations = new List<Reservation> ();
		}
		public PizzaOrder Order { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}

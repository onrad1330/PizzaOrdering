using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaOrders3.Models
{
    public class Reservation
    {
        public Reservation()
        {
            this.Orders = new List<PizzaOrder>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Time { get; set; }
        public List<PizzaOrder> Orders { get; set; }

    }
}

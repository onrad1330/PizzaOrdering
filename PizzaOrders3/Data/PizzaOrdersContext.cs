using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaOrders3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaOrders3.Data
{
	public class PizzaOrdersContext : IdentityDbContext
	{
		public PizzaOrdersContext(DbContextOptions<PizzaOrdersContext> options)
			: base(options)
		{ }
		public DbSet<PizzaOrders3.Models.PizzaOrder> PizzaOrders { get; set; }
		public DbSet<PizzaOrders3.Models.Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<PizzaOrder>()
				.HasOne(e => e.Reservation)
				.WithMany(e=> e.Orders);


    //        modelBuilder.Entity<ReservationTime>()
				//.HasOne(e => e.PizzaOrders)
				//.WithMany()
				//.OnDelete(DeleteBehavior.Restrict);


		}

	}
}


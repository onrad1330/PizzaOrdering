using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrders3.Models
{
	public class PizzaOrder
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
		[ForeignKey("Rezervace")]
		public int ReservationId { get; set; }
		public Reservation Reservation { get; set; }

		[Display(Name = "Číslo pokoje")]
		public string Room { get; set; }
		[Display(Name = "Jméno")]
		public string Name	{ get; set; }

		[Display(Name = "Čas vyzvednutí")]
		[DisplayFormat(DataFormatString = "{0:t}")]
		public DateTime CasVyzvednuti { get; set; }

		[Display(Name ="Šunka")]
		public bool IncludeHam { get; set; }

		[Display(Name = "Slanina")]
		public bool IncludeBacon { get; set; }

		[Display(Name = "Houby")]
		public bool IncludeMushrooms { get; set; }

		[Display(Name = "Olivy")]
		public bool IncludeOlives { get; set; }

		[Display(Name = "Kukuřice")]
		public bool IncludeCorn { get; set; }

		[Display(Name = "Cibule")]
		public bool IncludeCibule { get; set; }

		[Display(Name = "Paprika")]
		public bool IncludePepper { get; set; }

		[Display(Name = "Hermelín")]
		public bool IncludeHermelin { get; set; }

		[Display(Name = "Niva")]
		public bool IncludeNiva { get; set; }
		[Display(Name = "Eidam")]
		public bool IncludeEidam { get; set; }
		[Display(Name = "Poznámka")]

		public string Note { get; set; }

	}
}

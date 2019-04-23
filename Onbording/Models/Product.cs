using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Onbording.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public double Price { get; set; }

		public ICollection<sales> Sales { set; get; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDj_Receipt_Scanner
{
	internal class Product
	{
		public string Name { get; set; }
		public bool Domestic { get; set; }
		public decimal Price { get; set; }
		public decimal? Weight { get; set; }
		public string Description { get; set; }


		public Product()
		{
			Name = string.Empty;
			Description = string.Empty;
		}
	}
}

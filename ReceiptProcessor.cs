using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDj_Receipt_Scanner
{
	internal class ReceiptProcessor
	{
		public List<Product> DomesticProducts { get; } = new List<Product>();
		public List<Product> ImportedProducts { get; } = new List<Product>();

		public void ProcessReceipt(List<Product> products)
		{
			foreach (var product in products)
			{
				if (product.Domestic)
					DomesticProducts.Add(product);
				else
					ImportedProducts.Add(product);
			}
		}
		public void GenerateReports()
		{
			DomesticProducts.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal));
			ImportedProducts.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal));

			PrintProductGroup("\n . Domestic", DomesticProducts);
			PrintProductGroup(" . Imported", ImportedProducts ) ;
		
			decimal totalDomesticCost = DomesticProducts.Sum(p => p.Price);
			decimal totalImportedCost = ImportedProducts.Sum(p => p.Price);

			Console.Write("\n Domestic cost: ");
			Console.WriteLine($"${totalDomesticCost:F2}");
			Console.Write(" Imported cost: ");
			Console.WriteLine($"${totalImportedCost:F2}");

			int totalDomesticProducts = DomesticProducts.Count;
			int totalImportedProducts = ImportedProducts.Count;

			Console.Write(" Domestic count: ");
			Console.WriteLine(totalDomesticProducts);
			Console.Write(" Imported count: ");
			Console.WriteLine(totalImportedProducts);
		}

		private void PrintProductGroup(string title, List<Product> products) 
		{
			Console.WriteLine(title);
			foreach (var product in products) 
			{
				Console.WriteLine($" ... {product.Name}");
				Console.WriteLine($"     Price: ${product.Price:F2}");
				Console.WriteLine($"     {TruncateDescription(product.Description)}");
				Console.WriteLine($"     Weight: {(product.Weight.HasValue ? product.Weight.ToString() : "N/A")}");
			}
		}

		private string TruncateDescription(string description)
		{
			if (string.IsNullOrEmpty(description) || description.Length <= 10)
			{
				return description;
			}
			return description.Substring(0, 10) + "...";
		}


	}
}

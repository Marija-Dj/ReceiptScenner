using Newtonsoft.Json;
using System.Net;



namespace MDj_Receipt_Scanner
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string apiUrl = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

			using (WebClient client = new WebClient())
			{
				try
				{
					string jsonResponse = client.DownloadString(apiUrl);
					List<Product> receiptData = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);

					ReceiptProcessor processor = new ReceiptProcessor();
					processor.ProcessReceipt(receiptData);
					processor.GenerateReports();
				}
				catch (Exception)
				{
					Console.WriteLine("Failed to connect to API");
				}
			}
		}
	}
}
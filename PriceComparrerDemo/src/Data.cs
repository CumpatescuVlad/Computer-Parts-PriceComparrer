using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparrerWinforms.src
{
	public static class Data
	{
		private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = PriceComparrer; User ID = Vlad;Password = Apicultor__69;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public static string ConnectionString { get => _connectionString; }

		public static string ReadExistingComponentData(string tableName,string likeKeyword,string webSiteName) => $"Select ComponentTitle from {tableName} where WebSiteName='{webSiteName}' and ComponentTitle Like '{likeKeyword}%' ";

	}
}

using System;
using Microsoft.Data.SqlClient;

namespace Task9._1
{
	public static class DbConnection
	{
		public static SqlConnection GetConnection()
		{
            const string connectionString = @"Server=localhost,1433;Database=UserDb;User Id=sa;Password=4Wk3953j3JP;TrustServerCertificate=True";
			return new SqlConnection(connectionString);
        }		
    }
}


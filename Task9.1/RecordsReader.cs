using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Task9._1
{
    public class RecordsReader
    {
        public RecordsReader()
        {
            var connection = DbConnection.GetConnection();

            var adapter = new SqlDataAdapter("SELECT [User].Id, Email, FirstName, LastName, [Status], STRING_AGG([Role].[Name],', ') as Roles FROM [User] " +
                "INNER JOIN [UserRole] ON ([User].Id = [UserRole].UserId) " +
                "INNER JOIN [Role] ON ([Role].Id = [UserRole].RoleId) " +
                "GROUP BY [User].Id, [User].Email, [User].FirstName, [User].LastName, [User].[Status]" +
                "HAVING [Status]=1;", connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            new JsonGenerator(dataTable);
        }
    }
}


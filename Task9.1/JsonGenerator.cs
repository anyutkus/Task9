using System;
using System.Data;
using System.Text.Json;

namespace Task9._1
{
    public class JsonGenerator
    {
        public JsonGenerator(DataTable dataTable)
        {
            ArgumentNullException.ThrowIfNull(dataTable, nameof(dataTable));

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var users = new UserData[dataTable.Rows.Count];
            var i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                users[i] = (UserData)row;
                i++;
            }
            var json = JsonSerializer.Serialize(users, options);

            new JsonCreator(json);
        }
    }
}


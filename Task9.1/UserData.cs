using System.Data;
namespace Task9._1
{
    public struct UserData
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public string[] Roles { get; set; }

        public static explicit operator UserData(DataRow row)
        {
            var roles = ((string)row[5]).Split(", ");

            return new UserData
            {
                Id = (Guid)row[0],
                Email = (string)row[1],
                FirstName = (string)row[2],
                LastName = (string)row[3],
                Status = (bool)row[4],
                Roles = roles,
            };
        }
    }
}


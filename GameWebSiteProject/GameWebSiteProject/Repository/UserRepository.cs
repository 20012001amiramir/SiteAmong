using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GameWebSiteProject.Models;
using Microsoft.Extensions.Configuration;

namespace GameWebSiteProject.Repository
{
    public class UserRepository:AdoRepository<User>, IRepository<User>
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public void Insert(User user)
        {
            using (var command = new SqlCommand("INSERT INTO User(Id, Username, Password, Email, Sex, Age, Gender, Avatar, About) VALUES(@id, @username, @password, @email, @sex, @age, @gender, @avatar, @about)"))
            {
                command.Parameters.Add(new SqlParameter("id", user.Id));
                command.Parameters.Add(new SqlParameter("username", user.Username));
                command.Parameters.Add(new SqlParameter("password", user.Password));
                command.Parameters.Add(new SqlParameter("email", user.Email));
                command.Parameters.Add(new SqlParameter("sex", user.Sex));
                command.Parameters.Add(new SqlParameter("age", user.Age));
                command.Parameters.Add(new SqlParameter("gender", user.Gender));
                command.Parameters.Add(new SqlParameter("avatar", user.Avatar));
                command.Parameters.Add(new SqlParameter("about", user.About));
                ExecuteNonQuery(command);
            }
        }
        public void Delete(params string [] identfrs)
        {
            using (var command = new SqlCommand("DELETE FROM User WHERE Username = @username"))
            {
                command.Parameters.Add(new SqlParameter("username", identfrs[0]));
                ExecuteNonQuery(command);
            }
        }
        public void Update(User user)
        {
            using (var command = new SqlCommand("UPDATE User SET Sex = @sex, Age = @age, Gender = @gender," +
                " Avatar = @avatar, About = @about WHERE Id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", user.Id));
                command.Parameters.Add(new SqlParameter("sex", user.Sex));
                command.Parameters.Add(new SqlParameter("age", user.Age));
                command.Parameters.Add(new SqlParameter("gender", user.Gender));
                command.Parameters.Add(new SqlParameter("avatar", user.Avatar));
                command.Parameters.Add(new SqlParameter("about", user.About));
                ExecuteNonQuery(command);
            }
        }
        public IEnumerable<User> GetAll()
        {
            using (var command = new SqlCommand("SELECT * FROM User"))
            {
                return GetRecords(command);
            }
        }
        public User GetByIdentfrs(params string[] identfrs)
        {
            using (var command = new SqlCommand("SELECT * FROM User WHERE Username = @username"))
            {
                command.Parameters.Add(new SqlParameter("username", identfrs[0]));
                return GetRecord(command);
            }
        }
        public override User PopulateRecord(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetGuid(0),
                Username = reader.GetString(1),
                Password = reader.GetString(2),
                Email = reader.GetString(3),
                Sex = reader.GetString(4),
                Age = reader.GetByte(5),
                Gender = reader.GetString(6),
                Avatar = reader.GetString(7),
                About = reader.GetString(8)
            };
        }       
    }
}

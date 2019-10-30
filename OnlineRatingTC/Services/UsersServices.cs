using OnlineRatingTC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineRatingTC.Services
{
    public class UsersServices
    {
        private readonly ApplicationDbContext db;

        public UsersServices(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IEnumerable<User> GetListOfUsers()
        {
            return db.ReviewUsers.ToList();
        }

        public User GetUser(int id)
        {
            return db.ReviewUsers.Find(id);
        }

        public User GetUserByEmail(string mail)
        {
            return db.ReviewUsers.FirstOrDefault(x=>x.Email == mail);
        }

        public void CreateUser(User user)
        {
            db.ReviewUsers.Add(user);
            db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
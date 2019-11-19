using TermPaper.Models;
using System;
using System.Linq;
using System.Text;

namespace TermPaper.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var Users = new User[]
            {
            new User("Carson","Alexander@gmail.com","Password")
            };
            foreach (User s in Users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            
            
        }
    }
}
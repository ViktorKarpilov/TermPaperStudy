using TermPaper.Models;
using Microsoft.EntityFrameworkCore;

namespace TermPaper
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<CommentModel> Comments { get; set; }
    public DbSet<User> Users { get; set; }
  }
}
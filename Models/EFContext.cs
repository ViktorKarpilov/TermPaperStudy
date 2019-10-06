using Microsoft.EntityFrameworkCore;

namespace TermPaper
{
    public class EFContext:DbContext
    {
        //public DbSet<CommentModel> Comments {get;set;}
        //public DbSet<ImageCommentsModel> ImageComments {get;set;}

        //public DbSet<PhotoModel> PhotoPages {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=TermPaperDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
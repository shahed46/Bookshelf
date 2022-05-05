using BookList.Models;
using Microsoft.EntityFrameworkCore;

namespace BookList.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Bookname> Bookes { get; set; }
    }
}

namespace TestSQL
{
    using global::TestSQL.Models;
    using Microsoft.EntityFrameworkCore;

    namespace TestSQL.Data
    {
        public class Context : DbContext
        {
            public Context(DbContextOptions<Context> options) : base(options) { }
            public DbSet<Cortex> Cortex { get; set; }
        }
    }
}
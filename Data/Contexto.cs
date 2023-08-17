using Microsoft.EntityFrameworkCore;
using SuperCarros.Models;

namespace SuperCarros.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Carro> Carros { get; set; }
    }
}

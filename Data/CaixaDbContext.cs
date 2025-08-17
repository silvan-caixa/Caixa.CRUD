using Caixai.Web2.Data;
using Microsoft.EntityFrameworkCore;

namespace Caixa
{
   
    public class CaixaDbContext : DbContext
    {
        public CaixaDbContext(DbContextOptions<CaixaDbContext> options) : base(options)
        {
            
        }
        public DbSet<Turma> Turmas => Set<Turma>();
        public DbSet<Aluno> Alunos => Set<Aluno>();
      
    }
}


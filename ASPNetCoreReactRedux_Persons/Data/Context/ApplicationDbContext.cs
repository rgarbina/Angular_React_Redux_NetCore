using ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig;
using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Pessoa;persist security info=True;Integrated Security=SSPI;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => typeof(IEntityConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

        #region DbSet
        public virtual DbSet<CategoriaContato> CategoriaContatos { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Contato> Contatos { get; set; }
        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Idioma> Idiomas { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Relacionamento> Relacionamentos { get; set; }
        public virtual DbSet<TipoContato> TipoContatos { get; set; }
        public virtual DbSet<TipoEndereco> TipoEnderecos { get; set; }
        public virtual DbSet<TipoRelacionamento> TipoRelacionamentos { get; set; }

        #endregion

    }
}

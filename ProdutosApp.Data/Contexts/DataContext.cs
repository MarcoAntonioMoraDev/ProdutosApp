using Microsoft.EntityFrameworkCore;
using ProdutosApp.Data.Mappings;
using ProdutosApp.Data.Migrations;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Contexts
{
    //Regra 1: Esta classe deverá HERDAR DbContext
    public class DataContext : DbContext
    {
        //Regra 2: Implementar o método OnConfiguring
        //Neste método vamos mapear a connectionstring do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProdutosApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseSqlServer(@"Data Source=SQL5111.site4now.net;Initial Catalog=db_a9f1ba_bdprodutosapp;User Id=db_a9f1ba_bdprodutosapp_admin;Password=coti1234");
            optionsBuilder.UseSqlServer(@"Data Source = SQL5111.site4now.net; Initial Catalog = db_a9f1bc_dbprodutosapp; User Id = db_a9f1bc_dbprodutosapp_admin; Password = dbprodutosapp1974=");
            


        }

        //Regra 3: Implementar o método OnModelCreating
        //Neste método vamos adicionar cada classe mapeada (ORM) no projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        //Regra 4: Declarar uma propriedade DbSet para cada classe de entidade
        //O DbSet permitirá que façamos operações de CRUD com cada entidade
        public DbSet<Produto> Produtos { get; set; }
    }
}

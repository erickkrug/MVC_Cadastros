using MVCErick.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MVCErick.Data
{
    
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<EmpresaModels> Empresas { get; set; }
        public DbSet<UsuarioModels> Usuarios { get; set; }
    }
    
}
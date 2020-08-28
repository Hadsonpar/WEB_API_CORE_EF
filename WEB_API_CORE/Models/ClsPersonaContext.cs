using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; //Agrega la referencia de EntityFrameworkCore

namespace WEB_API_CORE.Models
{
    public class ClsPersonaContext :DbContext//Agrega el contexto para la base de datos
    {
        public ClsPersonaContext(DbContextOptions<ClsPersonaContext> options)
           : base(options)
        {
        }

        public DbSet<ClsPersona> ClsPersonas { get; set; }
    }
}

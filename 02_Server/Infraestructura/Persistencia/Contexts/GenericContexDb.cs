
using Dominio.Entities;
using Dominio.Entities.Seguridad;
using Dominio.Entities.Seguridadmetricas;
using Dominio.Entities.Vistas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Persistencia.Contexts
{
    public class GenericContexDb : DbContext
    {
        public GenericContexDb(DbContextOptions options) : base(options)
        {

        }

        //TODO: Agregar aqui DbSets de las entidades de dominio correspondiente al contexto de conexcion general.

        #region DbSets
        public DbSet<GenPersona> GenPersona { get; set; }
        public DbSet<Maquinaria> Maquinaria { get; set; }
        public DbSet<GenClasificador> GenClasificador { get; set; }
        public DbSet<GenClasificadortipo> GenClasificadorTipo { get; set; }
        public DbSet<MaqMaquinaElemento> MaqMaquinaElemento { get; set; }  
        public DbSet<MaqElemento> MaqElemento { get; set; } 
        public DbSet<MaqCaractInfra> MaqCaractInfra { get; set; }
        public DbSet<MaqCaractMaquinaria> MaqCaractMaquinaria { get; set; } 
        public DbSet<MaqCaractVehiculo> MaqCaractVehiculo { get; set; }
        public DbSet<MaqImpactoRcm> MaqImpactoRcm { get; set; }    
        public DbSet<ConfigImpacto> ConfigImpacto { get; set; }
        public DbSet<MaqvImpactoRcm> MaqvImpactoRcm { get; set; }  
        public DbSet<MaqMaquinaRepuesto> MaqMaquinaRepuesto { get; set; }  
        public DbSet<MaqRepuesto> MaqRepuesto { get; set; }  
        public DbSet<MaqMaquinaConsumible> MaqMaquinaConsumible { get; set; }  
        public DbSet<MaqConsumible> MaqConsumible { get; set; }  

       #endregion

    }
}

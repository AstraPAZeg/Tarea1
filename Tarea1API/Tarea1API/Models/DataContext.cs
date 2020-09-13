using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tarea1API.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }
        public System.Data.Entity.DbSet<Tarea1API.Models.aguilar> Students { get; set; }
    }
}
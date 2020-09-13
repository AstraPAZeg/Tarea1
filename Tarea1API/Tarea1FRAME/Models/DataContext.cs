using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tarea1FRAME.Models
{
    public class DataContext:DbContext
    {
        public DataContext(): base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Tarea1FRAME.Models.aguilar> aguilars { get; set; }
    }
}
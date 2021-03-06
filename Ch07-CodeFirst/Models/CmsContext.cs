using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ch07_CodeFirst.Models
{
    public class CmsContext : DbContext
    {
        public CmsContext() : base("CmsDbConnection") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
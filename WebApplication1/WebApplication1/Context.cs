using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Context:DbContext
    {
        public DbSet<Proizvod> proizvodi { set; get; }

        public Context():base("MyDbConnection")
        {

        }
    }
}
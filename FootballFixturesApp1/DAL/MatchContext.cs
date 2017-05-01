using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballFixturesApp1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FootballFixturesApp1.DAL
{
    public class MatchContext : DbContext
    {

        public MatchContext() : base("MatchContext")
        {
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
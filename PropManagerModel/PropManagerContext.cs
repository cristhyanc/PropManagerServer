﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PropManagerModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropManagerModel
{
    public class PropManagerContext: DbContext
    {
        public DbSet<Property> Properties { get; set; } = null!;
        public DbSet<Loan> Loans { get; set; } = null!;

        protected readonly IConfiguration Configuration;

        public PropManagerContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().ToTable("Properties");
            modelBuilder.Entity<Loan>().ToTable("Loans");
        }
    }
}

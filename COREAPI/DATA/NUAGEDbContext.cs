﻿using COREAPI.DATA.Domain;
using COREAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.DATA
{
    public class NUAGEDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {

        public NUAGEDbContext(DbContextOptions<NUAGEDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>()
           .ToTable("Contacts");
            modelBuilder.Entity<Product>()
           .ToTable("Product");
            modelBuilder.Entity<Employee>()
          .ToTable("Employee");
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}

﻿using CRUDByBlazorTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDByBlazorTemplate.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null;

    }
}
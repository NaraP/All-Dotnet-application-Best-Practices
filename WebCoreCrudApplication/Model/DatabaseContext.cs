﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreCrudApplication.Model
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Employees> Employee { get; set; }
    }
}

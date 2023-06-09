﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FormApplication.Models;
using System.Threading;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;

namespace FormApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserName>
    {
        public DbSet<Kategori>Kategoriler { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

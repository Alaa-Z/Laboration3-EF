using System;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using testEntity.Models;

namespace testEntity.Data
{
	public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }


        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cd> Cds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCd> UserCds { get; set; }
       
    }

}


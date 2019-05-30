using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JoinUpp.Models.DataModels
{
    public class DbJoinUppContext : DbContext
    {
        public DbJoinUppContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<DbUser> user_usr { get; set; }
        public DbSet<ProfileModel>profile_prf { get; set; }
    }

}

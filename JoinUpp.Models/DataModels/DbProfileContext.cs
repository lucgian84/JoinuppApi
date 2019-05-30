using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JoinUpp.Models.DataModels
{
    public class DbProfileContext : DbContext
    {
        public DbProfileContext(DbContextOptions<DbProfileContext> options)
            : base(options)
        {
        }
        public DbSet<ProfileModel> profile_prf { get; set; }
    }
}

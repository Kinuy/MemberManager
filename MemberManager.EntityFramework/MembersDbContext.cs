using MemberManager.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.EntityFramework;

public class MembersDbContext : DbContext
{
    public MembersDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<MemberDto> Members { get; set; }
}

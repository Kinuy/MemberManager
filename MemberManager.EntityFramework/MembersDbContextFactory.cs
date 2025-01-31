using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.EntityFramework;

public class MembersDbContextFactory
{
    private readonly DbContextOptions _options;

    public MembersDbContextFactory(DbContextOptions options)
    {
        _options = options;
    }

    public MembersDbContext Create()
    {
        return new MembersDbContext(_options);
    }
}

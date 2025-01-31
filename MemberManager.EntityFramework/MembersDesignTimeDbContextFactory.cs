using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.EntityFramework;


// This is used only for db migrations, meaning if you dont change your model use use it just once!
// Do not check in in source control beacause this file includes db connection string
// comand in shell for migration: dotnet-ef migrations add Initial
public class MembersDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MembersDbContext>
{


    public MembersDbContext CreateDbContext(string[] args = null)
    {
        return new MembersDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=Members.db").Options);
    }
}

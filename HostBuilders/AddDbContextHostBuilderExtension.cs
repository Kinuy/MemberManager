using MemberManager.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.HostBuilders;

public static class AddDbContextHostBuilderExtension
{
    public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) =>
                         {
                             string connectionString = context.Configuration.GetConnectionString("sqlite");

                             services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                             services.AddSingleton<MembersDbContextFactory>();

                         });
        return hostBuilder;
    }

}

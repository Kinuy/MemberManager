using MemberManager.Domain.Commands;
using MemberManager.Domain.Queries;
using MemberManager.EntityFramework;
using MemberManager.EntityFramework.Commands;
using MemberManager.EntityFramework.Queries;
using MemberManager.Stores;
using MemberManager.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MemberManager
{
    public partial class App : Application
    {

        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    string connectionString = "Data Source=Members.db";

                    services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                    services.AddSingleton<MembersDbContextFactory>();

                    services.AddSingleton<IGetAllMembersQuery, GetAllMembersQuery>();
                    services.AddSingleton<ICreateMemberCommand, CreateMemberCommand>();
                    services.AddSingleton<IUpdateMemberCommand, UpdateMemberCommand>();
                    services.AddSingleton<IDeleteMemberCommand, DeleteMemberCommand>();

                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<MemberStore>();
                    services.AddSingleton<SelectedMemberStore>();

                    services.AddTransient<MemberManagerViewModel>(CreateMemberManagerViewModel);
                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    }) ;
                })
                .Build();
        }



        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MembersDbContextFactory membersDbContextFactory = _host.Services.GetRequiredService<MembersDbContextFactory>();
            using (MembersDbContext context = membersDbContextFactory.Create())
            {
                context.Database.Migrate();
            }


            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }

        private MemberManagerViewModel CreateMemberManagerViewModel(IServiceProvider services)
        {
            return MemberManagerViewModel.LoadViewModel(
                services.GetRequiredService<MemberStore>(),
                services.GetRequiredService<SelectedMemberStore>(),
                services.GetRequiredService<ModalNavigationStore>()
                ) ;
        }
    }

}

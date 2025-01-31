using MemberManager.Domain.Commands;
using MemberManager.Domain.Queries;
using MemberManager.EntityFramework;
using MemberManager.EntityFramework.Commands;
using MemberManager.EntityFramework.Queries;
using MemberManager.Stores;
using MemberManager.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MemberManager
{
    public partial class App : Application
    {
        private readonly MembersDbContextFactory _membersDbContextFactory;
        private readonly SelectedMemberStore _selectedMemberStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly MemberStore _memberStore;
        private readonly ICreateMemberCommand _createMemberCommand;
        private readonly IUpdateMemberCommand _updateMemberCommand;
        private readonly IDeleteMemberCommand _deleteMemberCommand;
        private readonly IGetAllMembersQuery _getAllMembersQuery;

        private readonly IHost _host;
        public App()
        {
            //_host = Host.CreateDefaultBuilder()
            //    .ConfigureServices((context, services)=>
            //    {
            //        services
            //    })
            //    .Build();

            string connectionString = "Data Source=Members.db";

            _membersDbContextFactory = new MembersDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                
            _getAllMembersQuery = new GetAllMembersQuery(_membersDbContextFactory);
            _createMemberCommand = new CreateMemberCommand(_membersDbContextFactory);
            _updateMemberCommand = new UpdateMemberCommand(_membersDbContextFactory);
            _deleteMemberCommand = new DeleteMemberCommand(_membersDbContextFactory);
            _memberStore = new MemberStore(_createMemberCommand, 
                _updateMemberCommand, 
                _deleteMemberCommand, 
                _getAllMembersQuery);
            _modalNavigationStore = new ModalNavigationStore();
            _selectedMemberStore = new SelectedMemberStore(_memberStore);
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //_host.Start();

            using (MembersDbContext context = _membersDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

                MemberManagerViewModel memberManagerViewModel = MemberManagerViewModel.LoadViewModel(_memberStore, _selectedMemberStore, _modalNavigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, memberManagerViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        //protected override void OnExit(ExitEventArgs e)
        //{
        //    _host.StopAsync();
        //    _host.Dispose();
        //    base.OnExit(e);
        //}
    }

}

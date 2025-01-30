using MemberManager.Stores;
using MemberManager.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MemberManager
{
    public partial class App : Application
    {
        private readonly SelectedMemberStore _selectedMemberStore;

        public App()
        {
            _selectedMemberStore = new SelectedMemberStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MemberManagerViewModel(_selectedMemberStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}

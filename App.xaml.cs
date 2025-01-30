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
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly MemberStore _memberStore;


        public App()
        {
            _memberStore = new MemberStore();
            _modalNavigationStore = new ModalNavigationStore();
            _selectedMemberStore = new SelectedMemberStore(_memberStore);
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MemberManagerViewModel memberManagerViewModel = new MemberManagerViewModel(_memberStore,_selectedMemberStore, _modalNavigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, memberManagerViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}

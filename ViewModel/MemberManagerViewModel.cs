using MemberManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.ViewModel;

public class MemberManagerViewModel : ViewModelBase
{
    public MemberListingViewModel MemberListingViewModel { get;}

    public MemberDetailsViewModel MemberDetailsViewModel { get;}
    public ICommand AddMemberCommand { get; }

    public MemberManagerViewModel(SelectedMemberStore _selectedMemberStore)
    {
        MemberDetailsViewModel = new MemberDetailsViewModel(_selectedMemberStore);
        MemberListingViewModel = new MemberListingViewModel(_selectedMemberStore);
    }
}

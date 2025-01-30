using MemberManager.Commands;
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

    public MemberManagerViewModel(MemberStore memberStore,SelectedMemberStore selectedMemberStore, ModalNavigationStore modalNavigationStore)
    {
        MemberDetailsViewModel = new MemberDetailsViewModel(selectedMemberStore);
        MemberListingViewModel = new MemberListingViewModel(memberStore,selectedMemberStore, modalNavigationStore);

        AddMemberCommand = new OpenAddMemberCommand(memberStore, modalNavigationStore);
    }
}

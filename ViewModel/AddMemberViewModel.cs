using MemberManager.Commands;
using MemberManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.ViewModel;

public class AddMemberViewModel : ViewModelBase
{
    public MemberDetailsFormViewModel MemberDetailsFormViewModel { get;}

    public AddMemberViewModel(MemberStore memberStore, ModalNavigationStore modalNavigationStore) 
    {
        ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
        ICommand submitCommand = new AddMemberCommand(this, memberStore,modalNavigationStore);
        MemberDetailsFormViewModel = new MemberDetailsFormViewModel(submitCommand,cancelCommand);
    }
}

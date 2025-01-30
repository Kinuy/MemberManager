using MemberManager.Stores;
using MemberManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.Commands;

public class OpenAddMemberCommand : CommandBase
{
    private readonly MemberStore _memberStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public OpenAddMemberCommand(MemberStore memberStore, ModalNavigationStore modalNavigationStore)
    {
        _memberStore = memberStore;
        _modalNavigationStore = modalNavigationStore;
    }

    public override void Execute(object? parameter)
    {
        AddMemberViewModel addMemberViewModel = new AddMemberViewModel(_memberStore,_modalNavigationStore);
        _modalNavigationStore.CurrentViewModel = addMemberViewModel;
    }
}

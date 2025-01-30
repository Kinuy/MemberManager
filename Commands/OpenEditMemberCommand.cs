using MemberManager.Model;
using MemberManager.Stores;
using MemberManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Commands;

public class OpenEditMemberCommand : CommandBase
{
    private readonly ModalNavigationStore _modalNavigationStore;
    private readonly MemberListingItemViewModel _memberListingItemViewModel;
    private readonly MemberStore _memberStore;

    public OpenEditMemberCommand(MemberListingItemViewModel memberListingItemViewModel, MemberStore memberStore, ModalNavigationStore modalNavigationStore)
    {
        _memberListingItemViewModel = memberListingItemViewModel;
        _memberStore = memberStore;
        _modalNavigationStore = modalNavigationStore;
    }

    public override void Execute(object? parameter)
    {
        Member member = _memberListingItemViewModel.Member;

        EditMemberViewModel editMemberViewModel = new EditMemberViewModel(member,_memberStore,_modalNavigationStore);
        _modalNavigationStore.CurrentViewModel = editMemberViewModel;
    }
}

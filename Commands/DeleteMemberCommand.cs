using MemberManager.Domain.Models;
using MemberManager.Stores;
using MemberManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Commands;

public class DeleteMemberCommand : AsyncCommandBase
{
    private readonly MemberListingItemViewModel _memberListingItemViewModel;
    private readonly MemberStore _memberStore;

    public DeleteMemberCommand(MemberListingItemViewModel memberListingItemViewModel, MemberStore memberStore)
    {
        _memberListingItemViewModel = memberListingItemViewModel;
        _memberStore = memberStore;
    }



    public override async Task ExecuteAsync(object? parameter)
    {
        _memberListingItemViewModel.ErrorMessage = null;
        _memberListingItemViewModel.IsDeleting = true;


        Member member = _memberListingItemViewModel.Member;

        try
        {
            await _memberStore.Delete(member.Id);

        }
        catch (Exception)
        {
            _memberListingItemViewModel.ErrorMessage = "Failed to delete member. Please try again later.";
        }
        finally
        {
            _memberListingItemViewModel.IsDeleting=false;
        }
    }
}

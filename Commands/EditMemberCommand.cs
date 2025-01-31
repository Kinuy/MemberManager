using MemberManager.Domain.Models;
using MemberManager.Stores;
using MemberManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Commands;

public class EditMemberCommand : AsyncCommandBase
{
    private readonly EditMemberViewModel _editMemberViewModel;
    private readonly MemberStore _memberStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public EditMemberCommand(EditMemberViewModel editMemberViewModel, MemberStore memberStore, ModalNavigationStore modalNavigationStore)
    {
        _editMemberViewModel = editMemberViewModel;
        _memberStore = memberStore;
        _modalNavigationStore = modalNavigationStore;
    }
    public override async Task ExecuteAsync(object? parameter)
    {

        MemberDetailsFormViewModel formViewModel = _editMemberViewModel.MemberDetailsFormViewModel;

        formViewModel.ErrorMessage = null;
        formViewModel.IsSubmitting = true;

        Member member = new Member(
            _editMemberViewModel.MemberId,
            formViewModel.Username,
            formViewModel.Age);

        try
        {
            await _memberStore.Update(member);

            _modalNavigationStore.Close();
        }
        catch (Exception)
        {
            formViewModel.ErrorMessage = "Failed to update member. Please try again later.";
        }
        finally
        {
            formViewModel.IsSubmitting = false;
        }
    }
}

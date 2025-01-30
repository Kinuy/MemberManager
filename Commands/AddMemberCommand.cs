using MemberManager.Model;
using MemberManager.Stores;
using MemberManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Commands;

public class AddMemberCommand : AsyncCommandBase
{
    private readonly AddMemberViewModel _addMemberViewModel;
    private readonly MemberStore _memberStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public AddMemberCommand(AddMemberViewModel addMemberViewModel, MemberStore memberStore, ModalNavigationStore modalNavigationStore)
    {
       _addMemberViewModel = addMemberViewModel;
        _memberStore = memberStore;
        _modalNavigationStore = modalNavigationStore;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        //ToDo: Add Member to DB

        MemberDetailsFormViewModel formViewModel =  _addMemberViewModel.MemberDetailsFormViewModel;

        Member member = new Member(
            Guid.NewGuid(),
            formViewModel.Username,
            formViewModel.Age);

        try
        {
            await _memberStore.Add(member);

            _modalNavigationStore.Close();
        }
        catch(Exception )
        {
            throw;
        }



    }
}

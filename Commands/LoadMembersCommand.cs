using MemberManager.Stores;
using MemberManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Commands;

public class LoadMembersCommand : AsyncCommandBase
{
    private readonly MemberManagerViewModel _memberManagerViewModel;
    private readonly MemberStore _memberStore;

    public LoadMembersCommand(MemberManagerViewModel memberManagerViewModel, MemberStore memberStore)
    {
        _memberManagerViewModel = memberManagerViewModel;
        _memberStore = memberStore;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        _memberManagerViewModel.ErrorMessage = null;
        _memberManagerViewModel.IsLoading = true;

        try
        {
            await _memberStore.Load();

        }
        catch (Exception)
        {
            _memberManagerViewModel.ErrorMessage = "Failed to load members. Please restart the application.";
        }
        finally
        {
            _memberManagerViewModel.IsLoading = false;
        }
    }
}

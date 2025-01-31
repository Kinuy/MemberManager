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

    private bool _isLoading;
    public bool IsLoading
    {
        get
        {
            return _isLoading;
        }
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }

    private string _errorMessage;
    public string ErrorMessage
    {
        get
        {
            return _errorMessage;
        }
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(HasErrorMessage));
        }
    }

    public bool HasErrorMessage=>!string.IsNullOrEmpty(ErrorMessage);

    public ICommand AddMemberCommand { get; }

    public ICommand LoadMembersCommand { get; }


    public MemberManagerViewModel(MemberStore memberStore,SelectedMemberStore selectedMemberStore, ModalNavigationStore modalNavigationStore)
    {
        MemberDetailsViewModel = new MemberDetailsViewModel(selectedMemberStore);
        MemberListingViewModel = new MemberListingViewModel(memberStore,selectedMemberStore, modalNavigationStore);

        LoadMembersCommand = new LoadMembersCommand(this,memberStore);
        AddMemberCommand = new OpenAddMemberCommand(memberStore, modalNavigationStore);
    }

    public static MemberManagerViewModel LoadViewModel(MemberStore memberStore, SelectedMemberStore selectedMemberStore, ModalNavigationStore modalNavigationStore)
    {
        MemberManagerViewModel viewModel = new MemberManagerViewModel(memberStore, selectedMemberStore, modalNavigationStore);

        viewModel.LoadMembersCommand.Execute(null);

        return viewModel;
    }
}

using MemberManager.Commands;
using MemberManager.Domain.Models;
using MemberManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.ViewModel;

public class MemberListingItemViewModel : ViewModelBase
{
    public Member Member { get; private set; }

    public string Username => Member.Username;

    private bool _isDeleting;
    public bool IsDeleting
    {
        get
        {
            return _isDeleting;
        }
        set
        {
            _isDeleting = value;
            OnPropertyChanged(nameof(IsDeleting));
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

    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);


    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }


    public MemberListingItemViewModel(Member member, Stores.MemberStore memberStore, ModalNavigationStore modalNavigationStore)
    {
        Member = member;

        EditCommand = new OpenEditMemberCommand(this, memberStore, modalNavigationStore);

        DeleteCommand = new DeleteMemberCommand(this, memberStore);

}

    public void Update(Member member)
    {
        Member = member;
        OnPropertyChanged(nameof(Username));
    }
}

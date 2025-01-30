using MemberManager.Commands;
using MemberManager.Model;
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


    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }


    public MemberListingItemViewModel(Member member, Stores.MemberStore memberStore, ModalNavigationStore modalNavigationStore)
    {
        Member = member;

        EditCommand = new OpenEditMemberCommand(this, memberStore, modalNavigationStore);

}

    public void Update(Member member)
    {
        Member = member;
        OnPropertyChanged(nameof(Username));
    }
}

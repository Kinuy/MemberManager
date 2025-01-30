using MemberManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.ViewModel;

public class MemberListingItemViewModel : ViewModelBase
{
    public Member Member { get; }

    public string Username => Member.Username;

    public ICommand EditCommand { get; }

    public ICommand DeleteCommand { get; }


    public MemberListingItemViewModel(Member member)
    {
        Member = member;
    }
}

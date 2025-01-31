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

public class EditMemberViewModel : ViewModelBase
{

    public Guid MemberId { get; }
    public MemberDetailsFormViewModel MemberDetailsFormViewModel { get; }

    public EditMemberViewModel(Member member, MemberStore memberStore, ModalNavigationStore modalNavigationStore)
    {

        MemberId = member.Id;
        ICommand submitCommand = new EditMemberCommand(this,memberStore,modalNavigationStore);
        ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
        MemberDetailsFormViewModel = new MemberDetailsFormViewModel(submitCommand, cancelCommand)
        {
            Username = member.Username,
            Age = member.Age
        };
    }
}

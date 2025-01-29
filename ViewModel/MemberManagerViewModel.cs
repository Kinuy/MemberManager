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
    public ICommand AddMemberCommand { get; }

    public MemberManagerViewModel()
    {
        MemberDetailsViewModel = new MemberDetailsViewModel();
        MemberListingViewModel = new MemberListingViewModel();
    }
}

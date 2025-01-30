using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.ViewModel;

public class AddMemberViewModel : ViewModelBase
{
    public MemberDetailsFormViewModel MemberDetailsFormViewModel { get;}

    public AddMemberViewModel() 
    {
        MemberDetailsFormViewModel = new MemberDetailsFormViewModel();
    }
}

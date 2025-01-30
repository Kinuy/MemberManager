using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.ViewModel;

public class EditMemberViewModel
{
    public MemberDetailsFormViewModel MemberDetailsFormViewModel { get; }

    public EditMemberViewModel()
    {
        MemberDetailsFormViewModel = new MemberDetailsFormViewModel();
    }
}

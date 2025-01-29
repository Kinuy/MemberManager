using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.ViewModel;

public class MemberDetailsViewModel : ViewModelBase
{
    public string Username { get; }
    public string Age { get; }

    public MemberDetailsViewModel() 
    {
        Username = "Tobi";
        Age = "39";
    }
}

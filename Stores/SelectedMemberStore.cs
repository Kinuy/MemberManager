using MemberManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Stores;

public class SelectedMemberStore
{
    private Member _selectedMember;

    public Member SelectedMember
    {
        get
        {
            return _selectedMember;
        }
        set
        {
            _selectedMember = value;
            SelectedMemberChanged?.Invoke();
        }
    }

    public event Action SelectedMemberChanged;
}

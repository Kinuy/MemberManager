using MemberManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Stores;

public class SelectedMemberStore
{
    private readonly MemberStore _memberStore;

    public SelectedMemberStore(MemberStore memberStore)
    {
        _memberStore = memberStore;

        _memberStore.MemberUpdated += MemberStore_MemberUpdated;
    }

    private void MemberStore_MemberUpdated(Member member)
    {
        if(member.Id == SelectedMember?.Id)
        {
            SelectedMember = member;
        }
    }

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

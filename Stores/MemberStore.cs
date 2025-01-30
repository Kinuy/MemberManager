using MemberManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Stores;

public class MemberStore
{
    public event Action<Member> MemberAdded;
    public event Action<Member> MemberUpdated;

    public async Task Add(Member member)
    {
        MemberAdded?.Invoke(member);
    }

    public async Task Update(Member member)
    {
        MemberUpdated?.Invoke(member);
    }
}

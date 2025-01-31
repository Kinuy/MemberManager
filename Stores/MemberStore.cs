using MemberManager.Domain.Commands;
using MemberManager.Domain.Models;
using MemberManager.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Stores;

public class MemberStore
{
    private readonly ICreateMemberCommand _createMemberCommand;
    private readonly IUpdateMemberCommand _updateMemberCommand;
    private readonly IDeleteMemberCommand _deleteMemberCommand;
    private readonly IGetAllMembersQuery _getAllMembersQuery;
    private readonly List<Member> _members;

    public IEnumerable<Member> Members => _members;

    public event Action MembersLoaded;
    public event Action<Member> MemberAdded;
    public event Action<Member> MemberUpdated;
    public event Action<Guid> MemberDeleted;



    public MemberStore(ICreateMemberCommand createMemberCommand,
    IUpdateMemberCommand updateMemberCommand,
    IDeleteMemberCommand deleteMemberCommand,
    IGetAllMembersQuery getAllMembersQuery)
    {
        _createMemberCommand = createMemberCommand;
        _updateMemberCommand = updateMemberCommand;
        _deleteMemberCommand = deleteMemberCommand;
        _getAllMembersQuery = getAllMembersQuery;
        _members = new List<Member>();
    }

    public async Task Add(Member member)
    {
        await _createMemberCommand.Excecute(member);

        _members.Add(member);

        MemberAdded?.Invoke(member);
    }

    public async Task Update(Member member)
    {
        await _updateMemberCommand.Excecute(member);

        int currentIndex = _members.FindIndex(x => x.Id == member.Id);

        if(currentIndex != -1) //found 
        {
            _members[currentIndex] = member;
        }
        else
        {
            _members.Add(member);
        }

        MemberUpdated?.Invoke(member);
    }

    public async Task Load()
    {
        IEnumerable<Member> member = await _getAllMembersQuery.Excecute();
        _members.Clear();
        _members.AddRange(member);
        MembersLoaded?.Invoke();
    }

    public async Task Delete(Guid id)
    {
        await _deleteMemberCommand.Excecute(id);

        _members.RemoveAll(x => x.Id == id);

        MemberDeleted?.Invoke(id);
    }

}

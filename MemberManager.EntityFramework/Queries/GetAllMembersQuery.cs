using MemberManager.Domain.Models;
using MemberManager.Domain.Queries;
using MemberManager.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.EntityFramework.Queries;

public class GetAllMembersQuery : IGetAllMembersQuery
{
    private readonly MembersDbContextFactory _contextFactory;

    public GetAllMembersQuery(MembersDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Member>> Excecute()
    {
        using (MembersDbContext context  =  _contextFactory.Create())
        {

            IEnumerable<MemberDto> memberDtos = await context.Members.ToListAsync();

            return memberDtos.Select(y => new Member(y.Id, y.Username, y.Age));
        }
    }
}

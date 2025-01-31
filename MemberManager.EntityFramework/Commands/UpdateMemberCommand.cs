using MemberManager.Domain.Commands;
using MemberManager.Domain.Models;
using MemberManager.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.EntityFramework.Commands;

public class UpdateMemberCommand :IUpdateMemberCommand
{
    private readonly MembersDbContextFactory _contextFactory;

    public UpdateMemberCommand(MembersDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Excecute(Member member)
    {
        using (MembersDbContext context = _contextFactory.Create())
        {
            MemberDto memberDto = new MemberDto()
            {
                Id = member.Id,
                Username = member.Username,
                Age = member.Age
            };

            context.Members.Update(memberDto);
            await context.SaveChangesAsync();
        }
    }
}

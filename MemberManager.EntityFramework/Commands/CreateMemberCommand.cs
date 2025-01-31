using MemberManager.Domain.Commands;
using MemberManager.Domain.Models;
using MemberManager.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.EntityFramework.Commands;

public class CreateMemberCommand :ICreateMemberCommand
{
    private readonly MembersDbContextFactory _contextFactory;

    public CreateMemberCommand(MembersDbContextFactory contextFactory)
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

            context.Members.Add(memberDto);
            await context.SaveChangesAsync();
        }
    }
}

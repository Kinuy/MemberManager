using MemberManager.Domain.Commands;
using MemberManager.Domain.Models;
using MemberManager.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.EntityFramework.Commands;

public class DeleteMemberCommand : IDeleteMemberCommand
{
    private readonly MembersDbContextFactory _contextFactory;

    public DeleteMemberCommand(MembersDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Excecute(Guid id)
    {

        using (MembersDbContext context = _contextFactory.Create())
        {

            MemberDto memberDto = new MemberDto()
            {
                Id = id,
            };

            context.Members.Remove(memberDto);
            await context.SaveChangesAsync();
        }
    }
}

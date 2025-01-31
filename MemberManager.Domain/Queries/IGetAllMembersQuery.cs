using MemberManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Domain.Queries;

public interface IGetAllMembersQuery
{
    Task<IEnumerable<Member>> Excecute();
}

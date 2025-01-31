using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.EntityFramework.DTOs;

public class MemberDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }

    public string Age { get; set; }
}

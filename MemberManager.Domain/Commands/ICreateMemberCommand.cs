﻿using MemberManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Domain.Commands;

public interface ICreateMemberCommand
{
    Task Excecute(Member member);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Domain.Models;

public class Member
{
    public Member(Guid id, string username, string age)
    {
        Id = id;
        Username = username;
        Age = age;
    }

    public Guid Id { get;}
    public string Username { get;}

    public string Age { get;}


}

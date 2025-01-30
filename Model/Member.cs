using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Model;

public class Member
{
    public Guid Id { get; }
    public string Username {  get;}
    public string Age { get;}

    public Member(Guid id,string username, string age)
    {
        Id = id;
        Username = username;
        Age = age;
    }
}

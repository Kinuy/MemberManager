using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Model;

public class Member
{
    public string Username {  get;}
    public string Age { get;}

    public Member(string username, string age)
    {
        Username = username;
        Age = age;
    }
}

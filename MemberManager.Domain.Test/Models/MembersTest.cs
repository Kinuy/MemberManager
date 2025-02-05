using MemberManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Domain.Test.Models;

[TestFixture]
public class MembersTest
{
    [Test]
    public void ToString_ReturnsNameAgeString()
    {
        // arrange
        Guid id = Guid.NewGuid();
        Member member = new Member(id, "Hans", "15");

        // act
        string memberString = member.ToString();

        // assert
        Assert.That(memberString, Is.EqualTo("Hans_15"));
    }
}

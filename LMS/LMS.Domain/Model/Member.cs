using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace LMS.Domain.Model
{
    public class Member : IdentityUser
    {
        public DateOnly MembershipDate { get; set; }
        public int Status { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}

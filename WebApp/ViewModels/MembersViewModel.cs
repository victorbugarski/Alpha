using Domain.Models;

namespace WebApp.ViewModels
{
    public class MembersViewModel
    {
        public IEnumerable<Member> Members { get; set; } = [];
        public AddMemberForm AddForm { get; set; } = new();
        public EditMemberForm EditForm { get; set; } = new();

    }
}

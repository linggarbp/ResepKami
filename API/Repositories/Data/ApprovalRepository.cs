using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class ApprovalRepository : GeneralRepository<Approval, int, MyContext>, IApprovalRepository
    {
        public ApprovalRepository(MyContext context) : base(context)
        {
        }
    }
}

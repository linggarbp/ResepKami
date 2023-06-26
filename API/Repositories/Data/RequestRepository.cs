using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class RequestRepository : GeneralRepository<Request, int, MyContext>, IRequestRepository
    {
        public RequestRepository(MyContext context) : base(context)
        {
        }
    }
}

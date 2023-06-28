using Client.Models;
using Client.Repositories.Interface;

namespace Client.Repositories.Data
{
    public class RequestRepository : GeneralRepository<Request, int>, IRequestRepository
    {
        public RequestRepository(string request = "Request/") : base(request)
        {
            
        }
    }
}

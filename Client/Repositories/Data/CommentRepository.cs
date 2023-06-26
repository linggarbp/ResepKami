using Client.Models;
using Client.Repositories.Interface;

namespace Client.Repositories.Data
{
    public class CommentRepository : GeneralRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(string request = "Comment/") : base(request)
        {
            
        }
    }
}

using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class CommentRepository : GeneralRepository<Comment, string, MyContext>, ICommentRepository
{
    public CommentRepository(MyContext context) : base(context)
    {
    }
}

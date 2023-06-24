﻿using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : GeneralController<ICommentRepository, Comment, string>
    {
        public CommentController(ICommentRepository repository) : base(repository)
        {
        }
    }
}

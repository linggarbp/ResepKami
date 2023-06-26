﻿using API.Base;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class RequestController : GeneralController<IRequestRepository, Request, int>
    {
        public RequestController(IRequestRepository repository) : base(repository)
        {
        }
    }
}

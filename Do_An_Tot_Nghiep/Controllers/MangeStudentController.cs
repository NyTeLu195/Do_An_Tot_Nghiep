using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EduManage.Application.Models;
using EduManage.Application;

namespace Do_An_Tot_Nghiep.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MangeClassController : Controller
    {
        private readonly IMediator _mediator;
        public MangeClassController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AutoGenarateClassroom(AutoGenarateClassroomCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}

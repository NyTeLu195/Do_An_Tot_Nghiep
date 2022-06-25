using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.Application.Models;
using EduManage.Domain;
using EduManage.Domain.Entities;
using EduManage.Application.Enum;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using EduManage.Core.Application.Configuration.Commands;
using System.Threading;

namespace EduManage.Application
{
    public class AutoGenarateClassroomCommandHandler : ICommandHandler<AutoGenarateClassroomCommand, ResponseModel>
    {

        public Task<ResponseModel> Handle(AutoGenarateClassroomCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

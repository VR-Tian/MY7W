﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MY7W.Datafactory;
using MY7W.Domain.Model;
using MY7W.ModelDto.Dto;
using AutoMapper.QueryableExtensions;

namespace MY7W.EntityFrameworkRespository
{
    public class SysRoleRespository : RespositoryBase<MY7W.Domain.RBACModel.SysRole>, MY7W.Respositories.ISysRoleRespository
    {
        public SysRoleRespository(DatafactoryMamager datafactory) : base(datafactory)
        {

        }
    }
}

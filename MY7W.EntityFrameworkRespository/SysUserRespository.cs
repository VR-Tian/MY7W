using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MY7W.Datafactory;
using MY7W.Domain.Model;
using MY7W.ModelDto.UseInfoDto;
using AutoMapper.QueryableExtensions;

namespace MY7W.EntityFrameworkRespository
{
    public class SysUserRespository : RespositoryBase<MY7W.Domain.RBACModel.SysUser>, MY7W.Respositories.ISysUserRespository
    {
        public SysUserRespository(DatafactoryMamager datafactory) : base(datafactory)
        {

        }
    }
}

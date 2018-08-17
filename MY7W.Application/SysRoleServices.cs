using AutoMapper;
using AutoMapper.QueryableExtensions;
using MY7W.Domain.Model;
using MY7W.Domain.RBACModel;
using MY7W.ModelDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class SysRoleServices
    {
        protected MY7W.Respositories.ISysRoleRespository Respository { get; set; }
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }

        public SysRoleServices()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            Respository = new MY7W.EntityFrameworkRespository.SysRoleRespository(DatafactoryMamager);
        }

        public List<SysRoleDto> GetRole()
        {
            return Respository.Query(t => t.State != true).ProjectTo<SysRoleDto>().ToList();
        }

        public bool InertModel(SysRoleDto model)
        {
            model.CreateTime = DateTime.Now;
            model.Id = Guid.NewGuid();
            var temp = Mapper.Map<SysRoleDto, SysRole>(model);
            return Respository.Insert(temp) > 0 ? true : false;
        }
    }
        
}

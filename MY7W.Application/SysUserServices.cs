using MY7W.EntityFrameworkRespository;
using MY7W.ModelDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class SysUserServices
    {
        protected MY7W.Respositories.ISysUserRespository SysUserRespository { get; set; }
        protected MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }

        public SysUserServices()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            SysUserRespository = new SysUserRespository(DatafactoryMamager);
        }

        public List<SysAccessDto> GetRoleOfUser(string id)
        {
            SysAccessDto RoleAccess1 = new SysAccessDto() { URL = "Home/Index", State = false };
            SysAccessDto RoleAccess2 = new SysAccessDto() { URL = "Home/Create", State = false };
            //SysAccessDto RoleAccess3 = new SysAccessDto() { URL = "Home/Details", State = false };
            SysAccessDto RoleAccess4 = new SysAccessDto() { URL = "Home/Edit", State = false };
            return new List<SysAccessDto>() { RoleAccess1, RoleAccess2, RoleAccess4 };
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class SysUserRoleMappingServices
    {
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }

        private MY7W.Respositories.ISysUserRoleMappingRespository Respository { get; set; }
        public SysUserRoleMappingServices()
        {
            DatafactoryMamager= new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            Respository = new MY7W.EntityFrameworkRespository.SysUserRoleMappingRespository(DatafactoryMamager);
        }


    }
}

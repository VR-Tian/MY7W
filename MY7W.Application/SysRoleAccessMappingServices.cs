using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class SysRoleAccessMappingServices
    {
        protected MY7W.Respositories.ISysRoleAccessMappingRespository Respository { get; set; }
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }

        public SysRoleAccessMappingServices()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            Respository = new MY7W.EntityFrameworkRespository.SysRoleAccessMappingRespository(DatafactoryMamager);
        }
    }
}

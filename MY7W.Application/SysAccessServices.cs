using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class SysAccessServices
    {
        protected MY7W.Respositories.ISysAccessRespository Respository { get; set; }
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }

        public SysAccessServices()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            Respository = new MY7W.EntityFrameworkRespository.SysAccessRespositor(DatafactoryMamager);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.RepositoryFactory
{
    public class RepositoryFactory
    {
        public enum RepositoryType
        {
            UserInfoRepository,
            OrderInfoRepository,
        }

        public static object Create(MY7W.Datafactory.DatafactoryMamager mamager, RepositoryType repositoryType)
        {
            switch (repositoryType)
            {
                case RepositoryType.UserInfoRepository:
                    return new MY7W.EntityFrameworkRespository.UserInfoRespository(mamager);
                case RepositoryType.OrderInfoRepository:
                    return new MY7W.EntityFrameworkRespository.OrderInfoRespository(mamager);
                default:
                    return null;
            }
        }
    }
}

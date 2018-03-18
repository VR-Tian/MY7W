using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Datafactory
{
    public static class DatafactoryMamager
    {
       public static object GetRespository(string name)
        {
            switch (name)
            {
                case "sql":
                    return new MY7W.ADONETRespository.UserInfoRespository();
                case "EF":
                    return new MY7W.EntityFrameworkRespository.UserInfoRespository();
                default:
                    return null;
            }
            
        }
    }
}

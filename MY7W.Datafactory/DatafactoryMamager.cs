using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Datafactory
{
    public class DatafactoryMamager
    {
        public enum ContextType
        {
            MY8BEFDB,
            MY7WEFDB,
        }
        public DatafactoryMamager(ContextType contextType)
        {
            if (contextType == ContextType.MY7WEFDB)
            {
                dbContext = new MY7W.EntityFramework.MY7WModel();
            }
        }

        public DbContext dbContext { get; private set; }

        //private DbContext
        public object GetRespository(string name)
        {
            //switch (name)
            //{
            //    case "sql":
            //        return new MY7W.ADONETRespository.UserInfoRespository();
            //    case "EF":
            //        return new MY7W.EntityFrameworkRespository.UserInfoRespository();
            //    default:
            //        return null;
            //}
            return null;
        }


    }
}

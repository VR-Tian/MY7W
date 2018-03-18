using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.ADONETRespository
{
    public class UserInfoRespository : MY7W.Respositories.IUserInfoRespository
    {
        private MY7W.ADONET.SQLHelper service;
        public UserInfoRespository()
        {
            service = new ADONET.SQLHelper("");
        }
        public bool ExecuteInsetModel(MY7W.Domain.WebModel.UserInfo model)
        {
            throw new NotImplementedException();
        }

        public List<MY7W.Domain.WebModel.UserInfo> ExecuteQuertAll()
        {
            var dataset = service.ExecuteQueryAll("", System.Data.CommandType.Text);
            return null;

        }

        public bool ExecuteUpdateModel(MY7W.Domain.WebModel.UserInfo model)
        {
            throw new NotImplementedException();
        }
    }
}

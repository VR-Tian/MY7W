using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application.ModelProfile
{
    public class ProfileManager : Profile
    {
        public ProfileManager()
        {
            base.CreateMap<MY7W.Domain.WebModel.UserInfo, MY7W.Domain.ModelMap.UserInfoDto>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification));

        }
    }
}

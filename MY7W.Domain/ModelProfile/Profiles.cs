using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.ModelProfile
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            base.CreateMap<MY7W.Domain.Model.UserInfo, MY7W.Domain.ModelMap.UserInfoDto>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification));

        }
    }
}

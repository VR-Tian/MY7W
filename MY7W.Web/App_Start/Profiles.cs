using AutoMapper;
using MY7W.ModelDto.UseInfoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Web
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            base.CreateMap<MY7W.Domain.Model.UserInfo, MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification));

            base.CreateMap<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto, MY7W.Domain.Model.UserInfo>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification));

            base.CreateMap<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto, MY7W.Web.Models.UserInfoViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification));

            base.CreateMap<MY7W.Web.Models.UserInfoViewModel, MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification));

        }
    }
}

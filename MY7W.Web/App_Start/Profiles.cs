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
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OrderInfo, opt => opt.MapFrom(src => src.OrderInfo));

            base.CreateMap<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto, MY7W.Domain.Model.UserInfo>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OrderInfo, opt => opt.MapFrom(src => src.OrderInfo));

            base.CreateMap<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto, MY7W.Web.Models.UserInfoViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            base.CreateMap<MY7W.Web.Models.UserInfoViewModel, MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            base.CreateMap<MY7W.Domain.Model.OrderInfo, MY7W.ModelDto.UseInfoDto.OrderInfo_Application_Dto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime))
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => src.IsDelete))
            .ForMember(dest => dest.UserInfo, opt => opt.MapFrom(src => src.UserInfo))
            .ForMember(dest => dest.UserInfoId, opt => opt.MapFrom(src => src.UserInfoId));

            base.CreateMap<MY7W.Domain.Model.UserInfo, MY7W.ModelDto.UseInfoDto.OrderInfo_Application_Dto.OrderInfo_User_Alliaction_Dto>();

            base.CreateMap<MY7W.ModelDto.UseInfoDto.OrderInfo_Application_Dto,MY7W.Domain.Model.OrderInfo>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime))
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => src.IsDelete))
            .ForMember(dest => dest.UserInfo, opt => opt.MapFrom(src => src.UserInfo))
            .ForMember(dest => dest.UserInfoId, opt => opt.MapFrom(src => src.UserInfoId));

        }
    }
}

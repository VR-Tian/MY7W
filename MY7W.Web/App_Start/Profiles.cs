using AutoMapper;
using MY7W.ModelDto.Dto;
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
            base.CreateMap<MY7W.Domain.RBACModel.SysUser, MY7W.ModelDto.Dto.SysUserDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
                 //.ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID));

            base.CreateMap<MY7W.ModelDto.Dto.SysUserDto, MY7W.Domain.RBACModel.SysUser>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
            //.ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID));

            //TODO:如果使用ProjectTo拓展方法转换复杂类型，源类型中复杂类型属性不能转到目标类型的复杂类型属性（需要在目标类型列出其复杂类型的各个属性）
            base.CreateMap<MY7W.Domain.Model.UserInfo, MY7W.ModelDto.Dto.UserInfoDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
                //.ForMember(dest => dest.OrderInfo, opt => opt.MapFrom(src => src.OrderInfo))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.SysUserID, opt => opt.MapFrom(src => src.SysUser.ID))
            .ForMember(dest => dest.SysUserState, opt => opt.MapFrom(src => src.SysUser.State));

            base.CreateMap<MY7W.ModelDto.Dto.UserInfoDto, MY7W.Domain.Model.UserInfo>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
               //.ForMember(dest => dest.OrderInfo, opt => opt.MapFrom(src => src.OrderInfo))
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id));

            base.CreateMap<MY7W.ModelDto.Dto.UserInfoDto, MY7W.Web.Models.UserInfoViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            base.CreateMap<MY7W.Web.Models.UserInfoViewModel, MY7W.ModelDto.Dto.UserInfoDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            base.CreateMap<MY7W.Domain.Model.OrderInfo, MY7W.ModelDto.Dto.OrderInfoDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime))
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.UserInfoId, opt => opt.MapFrom(src => src.UserInfoId));

            base.CreateMap<MY7W.ModelDto.Dto.OrderInfoDto, MY7W.Domain.Model.OrderInfo>().ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.IsDelete))
            .ForMember(dest => dest.UserInfoId, opt => opt.MapFrom(src => src.UserInfoId));

        }
    }
}

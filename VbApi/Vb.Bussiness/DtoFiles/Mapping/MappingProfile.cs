using AutoMapper;
using Vb.Base.Entity;
using Vb.Bussiness.DtoFiles;
using Vb.Data.Entity;

namespace PatikaGenelWepApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<BaseEntityDTO, BaseEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 1));
            CreateMap<CustomerDTO, Customer>();
            CreateMap<AddressDTO, Address>();
        }
    }
}

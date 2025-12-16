using AutoMapper;
using WeddingHall.Application.DTOs.Hall;
using WeddingHall.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.Mappings
{
    public class HallProfile : Profile
    {
        public HallProfile()
        {
            //Create Hall
            CreateMap<HallCreateRequest, HallMaster>()
                .ForMember(d => d.GUID, o => o.MapFrom(_ => Guid.NewGuid()))
                .ForMember(d => d.Inserted_Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.isActive, o => o.MapFrom(_ => true));

           //Update Hall
            CreateMap<HallUpdateRequest, HallMaster>();

           //Get Hall
            CreateMap<HallMaster, HallResponse>()
                .ForMember(d => d.CityName,
                    o => o.MapFrom(s => s.City != null ? s.City.CityName : string.Empty))
                .ForMember(d => d.DistrictName,
                    o => o.MapFrom(s => s.District != null ? s.District.DistrictName : string.Empty));





        }
    }
}

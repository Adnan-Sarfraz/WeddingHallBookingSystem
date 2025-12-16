using AutoMapper;
using WeddingHall.Application.DTOs.SubHall;
using WeddingHall.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.Mappings
{
    public class SubHallProfile : Profile 
    {
        public SubHallProfile()
        {
            // Create SubHall
            CreateMap<SubHallCreateRequest, SubHallDetail>()
                .ForMember(d => d.GUID, o => o.MapFrom(_ => Guid.NewGuid()))
                .ForMember(d => d.Inserted_Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.isActive, o => o.MapFrom(_ => true));

            // Update SubHall
            CreateMap<SubHallUpdateRequest, SubHallDetail>();

            // Get SubHall
            CreateMap<SubHallDetail, SubHallResponse>();


        }

    }

}

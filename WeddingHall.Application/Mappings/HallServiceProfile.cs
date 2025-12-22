using AutoMapper;
using WeddingHall.Application.DTOs.HallService;
using WeddingHall.Domain;
using WeddingHall.Application.Interfaces;

public class HallServiceProfile : Profile
{
    public HallServiceProfile()
    {
        // Dto → Domain
        CreateMap<HallServiceCreateRequest, HallServices>();
        CreateMap<HallServiceUpdateRequest, HallServices>();

        // Domain → Dto
        CreateMap<HallServices, HallServiceResponse>();

    }
}

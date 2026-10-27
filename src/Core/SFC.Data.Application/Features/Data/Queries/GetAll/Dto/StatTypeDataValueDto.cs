using AutoMapper;

using SFC.Data.Application.Common.Mappings.Interfaces;
using SFC.Data.Domain.Entities.Data;

namespace SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
public class StatTypeDataValueDto : DataValueDto, IMapFrom<StatType>
{
    public int CategoryId { get; set; }

    public int SkillId { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<StatType, StatTypeDataValueDto>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));
}
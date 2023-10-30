using AutoMapper;

using SFC.Data.Application.Common.Extensions;
using SFC.Data.Application.Common.Mappings;
using SFC.Data.Domain.Entities;

namespace SFC.Data.Application.Models.Data.Common;
public class StatTypeDataValueDto : DataValueDto, IMapFrom<StatType>
{
    public int Category { get; set; }

    public int Skill { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<StatType, StatTypeDataValueDto>()
                                                   .ForMember(p => p.Category, d => d.MapFrom(z => z.CategoryId))
                                                   .ForMember(p => p.Skill, d => d.MapFrom(z => z.SkillId));
}

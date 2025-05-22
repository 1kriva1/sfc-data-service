using AutoMapper;

using SFC.Data.Application.Common.Mappings.Interfaces;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;

namespace SFC.Data.Api.Infrastructure.Models.Data.Common;

/// <summary>
/// **Stat type** data value.
/// </summary>
public class StatTypeDataValueModel : DataValueModel, IMapFrom<StatTypeDataValueDto>
{
    /// <summary>
    /// Category of **stat type**.
    /// </summary>
    public int Category { get; set; }

    /// <summary>
    /// Skill of **stat type**.
    /// </summary>
    public int Skill { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<StatTypeDataValueDto, StatTypeDataValueModel>()
                                                   .ForMember(p => p.Category, d => d.MapFrom(z => z.CategoryId))
                                                   .ForMember(p => p.Skill, d => d.MapFrom(z => z.SkillId))
                                                   .IncludeBase<DataValueDto, DataValueModel>();
}

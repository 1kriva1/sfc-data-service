using AutoMapper;

using SFC.Data.Application.Common.Mappings;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;

namespace SFC.Data.Application.Models.Data.GetAll.Result;

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
                                                   .IncludeBase<DataValueDto, DataValueModel>();
}

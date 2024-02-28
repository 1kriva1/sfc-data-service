using AutoMapper;

using SFC.Data.Application.Common.Mappings;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;

namespace SFC.Data.Application.Models.Data.GetAll.Result;
public class StatTypeDataValueModel : DataValueModel, IMapFrom<StatTypeDataValueDto>
{
    public int Category { get; set; }

    public int Skill { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<StatTypeDataValueDto, StatTypeDataValueModel>()
                                                   .IncludeBase<DataValueDto, DataValueModel>();
}

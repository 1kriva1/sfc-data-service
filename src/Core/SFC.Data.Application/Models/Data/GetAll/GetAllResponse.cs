using AutoMapper;

using SFC.Data.Application.Common.Extensions;
using SFC.Data.Application.Common.Mappings;
using SFC.Data.Application.Common.Models;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Models.Data.Common;

namespace SFC.Data.Application.Models.Data.GetAll;

public class GetAllResponse : BaseErrorResponse, IMapFrom<GetAllViewModel>
{
    public IEnumerable<DataValueDto> FootballPositions { get; init; } = Enumerable.Empty<DataValueDto>();

    public IEnumerable<DataValueDto> GameStyles { get; init; } = Enumerable.Empty<DataValueDto>();

    public IEnumerable<DataValueDto> StatCategories { get; init; } = Enumerable.Empty<DataValueDto>();

    public IEnumerable<DataValueDto> StatSkills { get; init; } = Enumerable.Empty<DataValueDto>();

    public IEnumerable<StatTypeDataValueDto> StatTypes { get; init; } = Enumerable.Empty<StatTypeDataValueDto>();

    public IEnumerable<DataValueDto> WorkingFoots { get; init; } = Enumerable.Empty<DataValueDto>();

    public void Mapping(Profile profile) => profile.CreateMap<GetAllViewModel, GetAllResponse>()
                                                   .IgnoreAllNonExisting();
}

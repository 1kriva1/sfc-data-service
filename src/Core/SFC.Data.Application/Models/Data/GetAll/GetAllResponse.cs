using AutoMapper;

using SFC.Data.Application.Common.Extensions;
using SFC.Data.Application.Common.Mappings;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Models.Base;
using SFC.Data.Application.Models.Data.GetAll.Result;

namespace SFC.Data.Application.Models.Data.GetAll;

public class GetAllResponse : BaseErrorResponse, IMapFrom<GetAllViewModel>
{
    public IEnumerable<DataValueModel> FootballPositions { get; init; } = Enumerable.Empty<DataValueModel>();

    public IEnumerable<DataValueModel> GameStyles { get; init; } = Enumerable.Empty<DataValueModel>();

    public IEnumerable<DataValueModel> StatCategories { get; init; } = Enumerable.Empty<DataValueModel>();

    public IEnumerable<DataValueModel> StatSkills { get; init; } = Enumerable.Empty<DataValueModel>();

    public IEnumerable<StatTypeDataValueModel> StatTypes { get; init; } = Enumerable.Empty<StatTypeDataValueModel>();

    public IEnumerable<DataValueModel> WorkingFoots { get; init; } = Enumerable.Empty<DataValueModel>();

    public void Mapping(Profile profile) => profile.CreateMap<GetAllViewModel, GetAllResponse>()
                                                   .IgnoreAllNonExisting();
}

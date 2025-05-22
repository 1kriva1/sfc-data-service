using AutoMapper;

using SFC.Data.Application.Common.Extensions;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Common.Mappings.Interfaces;
using SFC.Data.Api.Infrastructure.Models.Base;
using SFC.Data.Api.Infrastructure.Models.Data.Common;

namespace SFC.Data.Api.Infrastructure.Models.Data.GetAll;

/// <summary>
/// Contain all available **data types**.
/// </summary>
public class GetAllDataResponse : BaseErrorResponse, IMapFrom<GetAllDataViewModel>
{
    /// <summary>
    /// Football positions.
    /// </summary>
    public IEnumerable<DataValueModel> FootballPositions { get; init; } = [];

    /// <summary>
    /// Game styles.
    /// </summary>
    public IEnumerable<DataValueModel> GameStyles { get; init; } = [];

    /// <summary>
    /// Stat categories.
    /// </summary>
    public IEnumerable<DataValueModel> StatCategories { get; init; } = [];

    /// <summary>
    /// Stat skills.
    /// </summary>
    public IEnumerable<DataValueModel> StatSkills { get; init; } = [];

    /// <summary>
    /// Stat types.
    /// </summary>
    public IEnumerable<StatTypeDataValueModel> StatTypes { get; init; } = [];

    /// <summary>
    /// Working foots.
    /// </summary>
    public IEnumerable<DataValueModel> WorkingFoots { get; init; } = [];

    /// <summary>
    /// Shirts (can be used for team, player and game).
    /// </summary>
    public IEnumerable<DataValueModel> Shirts { get; init; } = [];

    public void Mapping(Profile profile) => profile.CreateMap<GetAllDataViewModel, GetAllDataResponse>()
                                                   .IgnoreAllNonExisting();
}

using AutoMapper;

using SFC.Data.Application.Common.Extensions;
using SFC.Data.Application.Common.Mappings;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Models.Base;
using SFC.Data.Application.Models.Data.GetAll.Result;

namespace SFC.Data.Application.Models.Data.GetAll;

/// <summary>
/// Contain all available **data types**.
/// </summary>
public class GetAllResponse : BaseErrorResponse, IMapFrom<GetAllViewModel>
{
    /// <summary>
    /// Football positions.
    /// </summary>
    public IEnumerable<DataValueModel> FootballPositions { get; init; } = Enumerable.Empty<DataValueModel>();

    /// <summary>
    /// Game styles.
    /// </summary>
    public IEnumerable<DataValueModel> GameStyles { get; init; } = Enumerable.Empty<DataValueModel>();

    /// <summary>
    /// Stat categories.
    /// </summary>
    public IEnumerable<DataValueModel> StatCategories { get; init; } = Enumerable.Empty<DataValueModel>();

    /// <summary>
    /// Stat skills.
    /// </summary>
    public IEnumerable<DataValueModel> StatSkills { get; init; } = Enumerable.Empty<DataValueModel>();

    /// <summary>
    /// Stat types.
    /// </summary>
    public IEnumerable<StatTypeDataValueModel> StatTypes { get; init; } = Enumerable.Empty<StatTypeDataValueModel>();

    /// <summary>
    /// Working foots.
    /// </summary>
    public IEnumerable<DataValueModel> WorkingFoots { get; init; } = Enumerable.Empty<DataValueModel>();

    public void Mapping(Profile profile) => profile.CreateMap<GetAllViewModel, GetAllResponse>()
                                                   .IgnoreAllNonExisting();
}

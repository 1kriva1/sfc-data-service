using AutoMapper;

using MediatR;

using SFC.Data.Application.Common.Extensions;
using SFC.Data.Application.Features.Common.Models;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
using SFC.Data.Application.Interfaces.Initialization;

namespace SFC.Data.Application.Features.Data.Queries.GetAll;

public record GetAllQueryHandler(
        IMapper Mapper,
        IDataService DataService) : IRequestHandler<GetAllQuery, GetAllViewModel>
{
    public async Task<GetAllViewModel> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        DataModel model = await DataService.GetAsync();

        return new GetAllViewModel
        {
            FootballPositions = Mapper.Map<IEnumerable<DataValueDto>>(model.FootballPositions).Localize(),
            GameStyles = Mapper.Map<IEnumerable<DataValueDto>>(model.GameStyles).Localize(),
            StatCategories = Mapper.Map<IEnumerable<DataValueDto>>(model.StatCategories).Localize(),
            StatSkills = Mapper.Map<IEnumerable<DataValueDto>>(model.StatSkills).Localize(),
            StatTypes = Mapper.Map<IEnumerable<StatTypeDataValueDto>>(model.StatTypes).Localize(),
            WorkingFoots = Mapper.Map<IEnumerable<DataValueDto>>(model.WorkingFoots).Localize()
        };
    }
}

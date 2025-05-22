using AutoMapper;

using MediatR;

using SFC.Data.Application.Common.Extensions;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Application.Interfaces.Data.Models;

namespace SFC.Data.Application.Features.Data.Queries.GetAll;

public class GetAllDataQueryHandler(IMapper mapper, IDataService dataService)
    : IRequestHandler<GetAllDataQuery, GetAllDataViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDataService _dataService = dataService;

    public async Task<GetAllDataViewModel> Handle(GetAllDataQuery request, CancellationToken cancellationToken)
    {
        GetAllDataModel model = await _dataService.GetAllDataAsync().ConfigureAwait(true);

        return new GetAllDataViewModel
        {
            FootballPositions = _mapper.Map<IEnumerable<DataValueDto>>(model.FootballPositions.Localize()),
            GameStyles = _mapper.Map<IEnumerable<DataValueDto>>(model.GameStyles.Localize()),
            StatCategories = _mapper.Map<IEnumerable<DataValueDto>>(model.StatCategories.Localize()),
            StatSkills = _mapper.Map<IEnumerable<DataValueDto>>(model.StatSkills.Localize()),
            StatTypes = _mapper.Map<IEnumerable<StatTypeDataValueDto>>(model.StatTypes.Localize()),
            WorkingFoots = _mapper.Map<IEnumerable<DataValueDto>>(model.WorkingFoots.Localize()),
            Shirts = _mapper.Map<IEnumerable<DataValueDto>>(model.Shirts.Localize())
        };
    }
}
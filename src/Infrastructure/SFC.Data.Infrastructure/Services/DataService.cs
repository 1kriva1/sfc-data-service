using MassTransit;

using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Application.Interfaces.Persistence;
using SFC.Data.Domain.Entities;
using SFC.Data.Messages.Messages;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Application.Features.Common.Models;
using SFC.Data.Messages.Enums;

namespace SFC.Data.Infrastructure.Services;
public class DataService : IDataService
{
    private readonly IPublishEndpoint _publisher;
    private readonly IRepository<FootballPosition> _positionsRepository;
    private readonly IRepository<GameStyle> _gameStylesRepository;
    private readonly IRepository<StatCategory> _statCategoriesRepository;
    private readonly IRepository<StatSkill> _statSkillTypesRepository;
    private readonly IRepository<StatType> _statTypesRepository;
    private readonly IRepository<WorkingFoot> _workingFootsRepository;

    public DataService(
        IPublishEndpoint publisher,
        IRepository<FootballPosition> positionsRepository,
        IRepository<GameStyle> gameStylesRepository,
        IRepository<StatCategory> statCategoriesRepository,
        IRepository<StatSkill> statSkillTypesRepository,
        IRepository<StatType> statTypesRepository,
        IRepository<WorkingFoot> workingFootsRepository)
    {
        _publisher = publisher;
        _positionsRepository = positionsRepository;
        _gameStylesRepository = gameStylesRepository;
        _statCategoriesRepository = statCategoriesRepository;
        _statSkillTypesRepository = statSkillTypesRepository;
        _statTypesRepository = statTypesRepository;
        _workingFootsRepository = workingFootsRepository;
    }

    public async Task<DataModel> GetAsync()
    {
        return new()
        {
            FootballPositions = await _positionsRepository.ListAllAsync(),
            GameStyles = await _gameStylesRepository.ListAllAsync(),
            StatCategories = await _statCategoriesRepository.ListAllAsync(),
            StatSkills = await _statSkillTypesRepository.ListAllAsync(),
            StatTypes = await _statTypesRepository.ListAllAsync(),
            WorkingFoots = await _workingFootsRepository.ListAllAsync()
        };
    }

    public async Task InitAsync(DataInitiator initiator)
    {
        DataModel model = await GetAsync();

        DataInitializationMessage message = new()
        {
            FootballPositions = model.FootballPositions.Select(entity => entity.MapToDataValue()),
            GameStyles = model.GameStyles.Select(entity => entity.MapToDataValue()),
            StatCategories = model.StatCategories.Select(entity => entity.MapToDataValue()),
            StatSkills = model.StatSkills.Select(entity => entity.MapToDataValue()),
            StatTypes = model.StatTypes.Select(entity => entity.MapToDataValue()),
            WorkingFoots = model.WorkingFoots.Select(entity => entity.MapToDataValue()),
            Initiator = initiator
        };

        await _publisher.Publish(message);
    }
}

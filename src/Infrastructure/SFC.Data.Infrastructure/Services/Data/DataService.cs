using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Application.Interfaces.Data.Models;
using SFC.Data.Application.Interfaces.Persistence.Repository.Data;

namespace SFC.Data.Infrastructure.Services.Data;
public class DataService(
    IFootballPositionRepository positionsRepository,
    IGameStyleRepository gameStylesRepository,
    IStatCategoryRepository statCategoriesRepository,
    IStatSkillRepository statSkillTypesRepository,
    IStatTypeRepository statTypesRepository,
    IWorkingFootRepository workingFootsRepository,
    IShirtRepository shirtsRepository) : IDataService
{
    private readonly IFootballPositionRepository _positionsRepository = positionsRepository;
    private readonly IGameStyleRepository _gameStylesRepository = gameStylesRepository;
    private readonly IStatCategoryRepository _statCategoriesRepository = statCategoriesRepository;
    private readonly IStatSkillRepository _statSkillTypesRepository = statSkillTypesRepository;
    private readonly IStatTypeRepository _statTypesRepository = statTypesRepository;
    private readonly IWorkingFootRepository _workingFootsRepository = workingFootsRepository;
    private readonly IShirtRepository _shirtsRepository = shirtsRepository;

    public async Task<GetAllDataModel> GetAllDataAsync()
    {
        return new()
        {
            FootballPositions = await _positionsRepository.ListAllAsync().ConfigureAwait(true),
            GameStyles = await _gameStylesRepository.ListAllAsync().ConfigureAwait(true),
            StatCategories = await _statCategoriesRepository.ListAllAsync().ConfigureAwait(true),
            StatSkills = await _statSkillTypesRepository.ListAllAsync().ConfigureAwait(true),
            StatTypes = await _statTypesRepository.ListAllAsync().ConfigureAwait(true),
            WorkingFoots = await _workingFootsRepository.ListAllAsync().ConfigureAwait(true),
            Shirts = await _shirtsRepository.ListAllAsync().ConfigureAwait(true)
        };
    }

    public async Task<GetPlayerDataModel> GetPlayerDataAsync()
    {
        return new()
        {
            FootballPositions = await _positionsRepository.ListAllAsync().ConfigureAwait(true),
            GameStyles = await _gameStylesRepository.ListAllAsync().ConfigureAwait(true),
            StatCategories = await _statCategoriesRepository.ListAllAsync().ConfigureAwait(true),
            StatSkills = await _statSkillTypesRepository.ListAllAsync().ConfigureAwait(true),
            StatTypes = await _statTypesRepository.ListAllAsync().ConfigureAwait(true),
            WorkingFoots = await _workingFootsRepository.ListAllAsync().ConfigureAwait(true)
        };
    }

    public async Task<GetTeamDataModel> GetTeamDataAsync()
    {
        return new()
        {
            FootballPositions = await _positionsRepository.ListAllAsync().ConfigureAwait(true),
            GameStyles = await _gameStylesRepository.ListAllAsync().ConfigureAwait(true),
            StatCategories = await _statCategoriesRepository.ListAllAsync().ConfigureAwait(true),
            StatSkills = await _statSkillTypesRepository.ListAllAsync().ConfigureAwait(true),
            StatTypes = await _statTypesRepository.ListAllAsync().ConfigureAwait(true),
            WorkingFoots = await _workingFootsRepository.ListAllAsync().ConfigureAwait(true),
            Shirts = await _shirtsRepository.ListAllAsync().ConfigureAwait(true)
        };
    }

    public async Task<GetInviteDataModel> GetInviteDataAsync()
    {
        return new()
        {
            FootballPositions = await _positionsRepository.ListAllAsync().ConfigureAwait(true),
            GameStyles = await _gameStylesRepository.ListAllAsync().ConfigureAwait(true),
            StatCategories = await _statCategoriesRepository.ListAllAsync().ConfigureAwait(true),
            StatSkills = await _statSkillTypesRepository.ListAllAsync().ConfigureAwait(true),
            StatTypes = await _statTypesRepository.ListAllAsync().ConfigureAwait(true),
            WorkingFoots = await _workingFootsRepository.ListAllAsync().ConfigureAwait(true),
            Shirts = await _shirtsRepository.ListAllAsync().ConfigureAwait(true)
        };
    }

    public async Task<GetRequestDataModel> GetRequestDataAsync()
    {
        return new()
        {
            FootballPositions = await _positionsRepository.ListAllAsync().ConfigureAwait(true),
            GameStyles = await _gameStylesRepository.ListAllAsync().ConfigureAwait(true),
            StatCategories = await _statCategoriesRepository.ListAllAsync().ConfigureAwait(true),
            StatSkills = await _statSkillTypesRepository.ListAllAsync().ConfigureAwait(true),
            StatTypes = await _statTypesRepository.ListAllAsync().ConfigureAwait(true),
            WorkingFoots = await _workingFootsRepository.ListAllAsync().ConfigureAwait(true),
            Shirts = await _shirtsRepository.ListAllAsync().ConfigureAwait(true)
        };
    }

    public async Task<GetSchemeDataModel> GetSchemeDataAsync()
    {
        return new()
        {
            FootballPositions = await _positionsRepository.ListAllAsync().ConfigureAwait(true),
            GameStyles = await _gameStylesRepository.ListAllAsync().ConfigureAwait(true),
            StatCategories = await _statCategoriesRepository.ListAllAsync().ConfigureAwait(true),
            StatSkills = await _statSkillTypesRepository.ListAllAsync().ConfigureAwait(true),
            StatTypes = await _statTypesRepository.ListAllAsync().ConfigureAwait(true),
            WorkingFoots = await _workingFootsRepository.ListAllAsync().ConfigureAwait(true),
            Shirts = await _shirtsRepository.ListAllAsync().ConfigureAwait(true)
        };
    }
}
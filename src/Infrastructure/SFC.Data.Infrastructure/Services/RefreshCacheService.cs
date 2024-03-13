using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Persistence.Repositories;

namespace SFC.Data.Infrastructure.Services;
public class RefreshCacheService: IRefreshCache
{
    private readonly ICache _cache;
    private readonly Repository<FootballPosition> _positionsRepository;
    private readonly Repository<GameStyle> _gameStylesRepository;
    private readonly Repository<StatCategory> _statCategoriesRepository;
    private readonly Repository<StatSkill> _statSkillTypesRepository;
    private readonly Repository<StatType> _statTypesRepository;
    private readonly Repository<WorkingFoot> _workingFootsRepository;

    public RefreshCacheService(
        ICache cache,
        Repository<FootballPosition> positionsRepository,
        Repository<GameStyle> gameStylesRepository,
        Repository<StatCategory> statCategoriesRepository,
        Repository<StatSkill> statSkillTypesRepository,
        Repository<StatType> statTypesRepository,
        Repository<WorkingFoot> workingFootsRepository)
    {
        _cache = cache;
        _positionsRepository = positionsRepository;
        _gameStylesRepository = gameStylesRepository;
        _statCategoriesRepository = statCategoriesRepository;
        _statSkillTypesRepository = statSkillTypesRepository;
        _statTypesRepository = statTypesRepository;
        _workingFootsRepository = workingFootsRepository;
    }
    
    public async Task RefreshAsync(CancellationToken token = default)
    {
        IReadOnlyList<FootballPosition> footballPositions = await _positionsRepository.ListAllAsync();
        await Refresh(footballPositions, token);

        IReadOnlyList<GameStyle> gameStyles = await _gameStylesRepository.ListAllAsync();
        await Refresh(gameStyles, token);

        IReadOnlyList<StatCategory> statCategories = await _statCategoriesRepository.ListAllAsync();
        await Refresh(statCategories, token);

        IReadOnlyList<StatSkill> statSkills = await _statSkillTypesRepository.ListAllAsync();
        await Refresh(statSkills, token);

        IReadOnlyList<StatType> statTypes = await _statTypesRepository.ListAllAsync();
        await Refresh(statTypes, token);

        IReadOnlyList<WorkingFoot> workingFoots = await _workingFootsRepository.ListAllAsync();
        await Refresh(workingFoots, token);
    }

    private Task Refresh<T>(IReadOnlyList<T> entities, CancellationToken token = default)
    {
        _cache.DeleteAsync($"{typeof(T).Name}", token);
        return _cache.SetAsync($"{typeof(T).Name}", entities, null, token);
    }
}
